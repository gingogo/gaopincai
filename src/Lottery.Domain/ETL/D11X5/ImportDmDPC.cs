using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.ETL.D11X5
{
	using Model.Common;
	using Model.D11X5;
	using Data.SQLServer;
	using Data.SQLServer.D11X5;
	using Data.SQLServer.Common;
	using Utils;

	/// <summary>
	/// 导入11选5彩种所有玩法号码组合。
	/// </summary>
	public class ImportDmDPC
	{
		public static void Add(string output)
		{
			List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("11X5");
			foreach (var category in categories)
			{
				P(category.DbName, "DX", 1, output);
				P(category.DbName, "P2", 2, output);
				P(category.DbName, "P3", 3, output);
				P(category.DbName, "P4", 4, output);
				P(category.DbName, "P5", 5, output);
				C(category.DbName, "C2", 2, output);
				C(category.DbName, "C3", 3, output);
				C(category.DbName, "C4", 4, output);
				C(category.DbName, "C5", 5, output);
				C(category.DbName, "C6", 6, output);
				C(category.DbName, "C7", 7, output);
				C(category.DbName, "C8", 8, output);

				C5CX(category.DbName, "C2", 2, output);
				C5CX(category.DbName, "C3", 3, output);
				C5CX(category.DbName, "C4", 4, output);
				C5CX(category.DbName, "C6", 6, output);
				C5CX(category.DbName, "C7", 7, output);
				C5CX(category.DbName, "C8", 8, output);
			}
		}

		public static void P(string name, string type, int length, string output)
		{
			var p = new Permutations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, length);
			if (output.Equals("txt"))
			{
				SaveToText(name, type, p);
				return;
			}
			SaveToDB(name, type, p);
		}

		public static void C(string name, string type, int length, string output)
		{
			var c = new Combinations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, length);
			if (output.Equals("txt"))
			{
				SaveToText(name, type, c);
				return;
			}
			SaveToDB(name, type, c);
		}

		public static void C5CX(string name, string type, int length, string output)
		{
			List<DmDPC> srcNumbers = null;
			if (length > 5)
			{
				srcNumbers = NumberCache.Instance.GetNumberList(type);
			}
			else
			{
				srcNumbers = NumberCache.Instance.GetNumberList("C5");
			}

			DmC5CXBiz biz = new DmC5CXBiz(name);
			List<DmC5CX> entities = new List<DmC5CX>(srcNumbers.Count * 56);
			foreach (var srcNumber in srcNumbers)
			{
				string number = srcNumber.Number.Replace(' ', ',');
				var cxNumbers = new Combinations<int>(number.ToList(), length > 5 ? 5 : length);
				foreach (var cxNumber in cxNumbers)
				{
					string cx = NumberCache.Instance.GetNumberId(length > 5 ? "C5" : type, cxNumber.Format("D2", ","));
					DmC5CX entity = new DmC5CX();
					entity.C5 = (length > 5) ? cx : srcNumber.Id;
					entity.CX = (length > 5) ? srcNumber.Id : cx;
					entity.C5Number = (length > 5) ? cx.ToString(2, " ") : srcNumber.Number;
					entity.CXNumber = (length > 5) ? srcNumber.Number : cx.ToString(2, " ");
					entity.NumberType = type;
					entities.Add(entity);
				}
			}
			
			biz.DataAccessor.Truncate();
			biz.DataAccessor.Insert(entities, SqlInsertMethod.SqlBulkCopy);
		}

		private static void SaveToText(string name, string type, IEnumerable<IList<int>> lists)
		{
			string fileName = string.Format(@"d:\{0}_{1}.txt", name, type);
			StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
			foreach (var list in lists)
			{
				var dto = GetDmDPC(list, type);
				writer.WriteLine(dto.ToString());
			}
			writer.Close();
		}

		private static void SaveToDB(string name, string type, IEnumerable<IList<int>> lists)
		{
			DmDPCBiz biz = new DmDPCBiz(name, type);
			List<DmDPC> entities = new List<DmDPC>(lists.Count());
			foreach (var list in lists)
			{
				entities.Add(GetDmDPC(list, type));
			}
			
			biz.DataAccessor.Truncate();
			biz.DataAccessor.Insert(entities, SqlInsertMethod.SqlBulkCopy);
		}

		private static DmDPC GetDmDPC(IList<int> list, string type)
		{
			DmDPC dto = new DmDPC();
			dto.Id = list.Format();
			dto.Number = list.Format("D2", " ");
			dto.DaXiao = list.GetDaXiao(5);
			dto.DanShuang = list.GetDanShuang();
			dto.ZiHe = list.GetZiHe();
			dto.Lu012 = list.GetLu012();
			dto.He = list.GetHe();
			dto.HeWei = dto.He.GetWei();
			dto.DaCnt = dto.DaXiao.Count("1");
			dto.XiaoCnt = dto.DaXiao.Count("0");
			dto.DanCnt = dto.DanShuang.Count("1");
			dto.ShuangCnt = dto.DanShuang.Count("0");
			dto.ZiCnt = dto.ZiHe.Count("1");
			dto.HeCnt = dto.ZiHe.Count("0");
			dto.Lu0Cnt = dto.Lu012.Count("0");
			dto.Lu1Cnt = dto.Lu012.Count("1");
			dto.Lu2Cnt = dto.Lu012.Count("2");
			dto.Ji = list.GetJi();
			dto.JiWei = dto.Ji.GetWei();
			dto.KuaDu = list.GetKuaDu();
			dto.AC = list.GetAC();
			dto.DaXiaoBi = list.GetDaXiaoBi(5);
			dto.ZiHeBi = list.GetZiHeBi();
			dto.DanShuangBi = list.GetDanShuangBi();
			dto.Lu012Bi = list.GetLu012Bi();
			dto.NumberType = type;

			return dto;
		}
		
		public static void Update()
		{
			List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("11X5");
			foreach (var category in categories)
			{
				Modify(category.DbName, "DX");
				Modify(category.DbName, "P2");
				Modify(category.DbName, "C2");
				Modify(category.DbName, "P3");
				Modify(category.DbName, "C3");
				Modify(category.DbName, "P4");
				Modify(category.DbName, "C4");
				Modify(category.DbName, "P5");
				Modify(category.DbName, "C5");
			}
		}

		private static void Modify(string name, string type)
		{
			DmDPCBiz biz = new DmDPCBiz(name, type);
			var numbers = biz.GetAll("Id", "Number");
			foreach (var number in numbers)
			{
				List<int> digits = number.Number.ToList(' ');
				number.Ji = digits.GetJi();
				number.JiWei = number.Ji.GetWei();
				number.KuaDu = digits.GetKuaDu();
				number.AC = digits.GetAC();

				//biz.Modify(number, number.Id, DmDPC.C_Ji, DmDPC.C_JiWei, DmDPC.C_KuaDu, DmDPC.C_AC);
			}
		}
	}
}

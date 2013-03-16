using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL.D11X5
{
	using Model.Common;
	using Model.D11X5;
	using Data;
	using Lottery.Data.Biz.Common;
	using Lottery.Data.Biz.D11X5;
	using Utils;

	public class ImportDwNumber
	{
		public static void Insert(int categoryId, string speroid, string code, string sdate)
		{
			string no = code.Replace(" ", ",");
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			int p = 2000000000 + int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 2));

			Category category = CategoryBiz.Instance.GetById(categoryId);
			DwNumberBiz biz = new DwNumberBiz(category.DbName);

			//select MAX(seq) seq from DwNumber where P < p;
			int seq = biz.DataAccessor.SelectMaxWithCondition(DwNumber.C_Seq, 10, "where P <" + p);
			DwNumber number = biz.Create(p, n, no, dateint, sdate);
			number.Seq = seq + 1;

			//UPDATE DwNumber set Seq=seq+ 1 where P > p;
			biz.Add(number);
			biz.DataAccessor.UpdateSeq(1, p);
		}
		
		public static void Update(int categoryId, string p, string code)
		{
			Category category = CategoryBiz.Instance.GetById(categoryId);
			DwNumberBiz biz = new DwNumberBiz(category.DbName);
			DwNumber number = biz.GetById(p);
			DwNumber newNumber = biz.Create(number.P, number.N, code, number.Date, number.Created.ToString());
			newNumber.Seq = number.Seq;
			biz.Modify(newNumber, newNumber.P.ToString());
		}
	}
}

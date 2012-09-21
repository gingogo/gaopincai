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

    public class ImportDmDPC
    {
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

                //biz.Modify(number, number.Id, DmFCAn.C_Ji, DmFCAn.C_JiWei, DmFCAn.C_KuaDu, DmFCAn.C_AC);
            }
        }

        /// <summary>
        /// 导入11选5所有玩法的号码及相关属性到指定输出设备
        /// </summary>
        /// <param name="output">db|txt</param>
        public static void Add(string output)
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("11X5");
            foreach (var category in categories)
            {
                //P(category.DbName, "Dx", 1, output);
                //P(category.DbName, "F2", 2, output);
                //P(category.DbName, "F3", 3, output);
                //P(category.DbName, "P4", 4, output);
                //P(category.DbName, "P5", 5, output);
                //C(category.DbName, "C2", 2, output);
                //C(category.DbName, "C3", 3, output);
                //C(category.DbName, "C4", 4, output);
                //C(category.DbName, "C5", 5, output);
                //C(category.DbName, "C6", 6, output);
                //C(category.DbName, "C7", 7, output);
                //C(category.DbName, "C8", 8, output);
                //break;
            }
        }

        public static void P(string name,string type, int length,string output)
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

        private static void SaveToText(string name, string type, IEnumerable<IList<int>> lists)
        {
            string fileName = string.Format(@"d:\{0}_{1}.txt", name, type);
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            foreach (var list in lists)
            {
                var dto = GetDmFCAn(list);
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
                entities.Add(GetDmFCAn(list));
                //biz.Add(GetDmFCAn(list));
            }
            biz.DataAccessor.Insert(entities, SqlInsertMethod.SqlBulkCopy);
        }

        private static DmDPC GetDmFCAn(IList<int> list)
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

            return dto;
        }
    }
}

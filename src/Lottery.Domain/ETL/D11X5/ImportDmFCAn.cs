using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.ETL.D11X5
{
    using Model.Common;
    using Model.D11X5;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    public class ImportDmFCAn
    {
        public static void Update()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("11X5");
            foreach (var category in categories)
            {
                Modify(category.DbName, "D1");
                Modify(category.DbName, "F2");
                Modify(category.DbName, "F3");
                Modify(category.DbName, "C2");
                Modify(category.DbName, "C3");
                Modify(category.DbName, "A4");
                Modify(category.DbName, "A5");
                Modify(category.DbName, "A6");
                Modify(category.DbName, "A7");
                Modify(category.DbName, "A8");
            }
        }

        private static void Modify(string name, string type)
        {
            DmFCAnBiz biz = new DmFCAnBiz(name, type);
            var numbers = biz.GetAll("Id", "Number");
            foreach (var number in numbers)
            {
                string[] arr = number.Number.Split(' ');
                List<int> digits = new List<int>();
                foreach (string str in arr)
                    digits.Add(int.Parse(str));

                //string[] ziHe = NumberHelper.GetZiHe(digits).Split(',');
                //number.ZiHe = ziHe[0];
                //number.ZiCnt = int.Parse(ziHe[1]);
                //number.HeCnt = int.Parse(ziHe[2]);
                number.Ji = NumberHelper.GetJi(digits);
                number.JiWei = NumberHelper.GetWei(number.Ji.ToString());
                number.KuaDu = NumberHelper.GetKuaDu(digits);
                number.AC = type.Equals("D1") ? 0 : NumberHelper.GetAC(digits);

                biz.Modify(number, number.Id, DmFCAn.C_Ji, DmFCAn.C_JiWei, DmFCAn.C_KuaDu, DmFCAn.C_AC);
            }
        }

        public static void Start()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("11X5");
            foreach (var category in categories)
            {
                P(category.DbName, "D1", 1, "db");
                P(category.DbName, "F2", 2, "db");
                P(category.DbName, "F3", 3, "db");
                C(category.DbName, "C2", 2, "db");
                C(category.DbName, "C3", 3, "db");
                C(category.DbName, "A4", 4, "db");
                C(category.DbName, "A5", 5, "db");
                C(category.DbName, "A6", 6, "db");
                C(category.DbName, "A7", 7, "db");
                C(category.DbName, "A8", 8, "db");
            }
        }

        public static void P(string name,string type, int length,string output)
        {
            var c = new Utils.Permutations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, length);
            var list = c.Get(",");

            if (output.Equals("txt"))
            {
                SaveToText(name,type, list);
                return;
            }

            SaveToDB(name, type, list);
        }

        public static void C(string name, string type, int length, string output)
        {
            var c = new Utils.Combinations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, length);
            var list = c.Get(",");

            if (output.Equals("txt"))
            {
                SaveToText(name, type, list);
                return;
            }

            SaveToDB(name, type, list);
        }

        private static void SaveToText(string name, string type, List<string> list)
        {
            string fileName = string.Format(@"d:\{0}_{1}.txt", name, type);
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            List<string> results = NumberHelper.GetComputeResult(list, 5);
            results.ForEach(writer.WriteLine);
            writer.Close();
        }

        private static void SaveToDB(string name, string type, List<string> list)
        {
            DmFCAnBiz biz = new DmFCAnBiz(name, type);
            List<string> results = NumberHelper.GetComputeResult(list, 5);
            foreach (string result in results)
            {
                string[] arr = result.Split(',');
                DmFCAn dto = new DmFCAn();
                dto.Id = arr[0];
                dto.Number = arr[1];
                dto.He = int.Parse(arr[2]);
                dto.HeWei = int.Parse(arr[3]);
                dto.DaXiao = arr[4];
                dto.DaCnt = int.Parse(arr[5]);
                dto.XiaoCnt = int.Parse(arr[6]);
                dto.DanShuang = arr[7];
                dto.DanCnt = int.Parse(arr[8]);
                dto.ShuangCnt = int.Parse(arr[9]);
                dto.ZiHe = arr[10];
                dto.ZiCnt = int.Parse(arr[11]);
                dto.HeCnt = int.Parse(arr[12]);
                dto.Lu012 = arr[13];
                dto.Lu0Cnt = int.Parse(arr[14]);
                dto.Lu1Cnt = int.Parse(arr[15]);
                dto.Lu2Cnt = int.Parse(arr[16]);
                dto.Ji = int.Parse(arr[17]);
                dto.JiWei = int.Parse(arr[18]);
                dto.KuaDu = int.Parse(arr[19]);
                dto.AC = int.Parse(arr[20]);

                biz.Add(dto);
            }
        }

    }
}

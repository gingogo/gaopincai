using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.ETL.SCC
{
    using Model.Common;
    using Model.SSC;
    using Data.SQLServer.SSC;
    using Data.SQLServer.Common;
    using Utils;

    public class ImportDmFCAn
    {
        public static void Start()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("SSC");
            foreach (var category in categories)
            {
                P(category.DbName, "D1", 1, "db");
                P(category.DbName, "P2", 2, "db");
                P(category.DbName, "P3", 3, "db");
                P(category.DbName, "P4", 4, "db");
                P(category.DbName, "P5", 5, "db");
                C(category.DbName, "C2", 2, "db");
                C(category.DbName, "C3", 3, "db");
                C(category.DbName, "C33", 3, "db");
                C(category.DbName, "C36", 3, "db");
            }
        }

        public static void P(string name, string type, int length, string output)
        {
            int count = (int)Math.Pow(10, length);
            List<string> list = new List<string>(count);
            string format = "D" + length;
            for (int i = 0; i < count; i++)
            {
                string number = string.Join(",",i.ToString(format).ToArray());
                list.Add(number);
            }

            if (output.Equals("txt"))
            {
                SaveToText(name,type, list);
                return;
            }

            SaveToDB(name, type, list);
        }

        public static void C(string name, string type, int length, string output)
        {
            int count = (int)Math.Pow(10, length);
            List<string> list = new List<string>(500);
            string format = "D" + length;
            for (int i = 0; i < count; i++)
            {
                var digits = i.ToString(format).ToArray();
                if (type.Equals("C33") && digits.Distinct().Count() != 2)
                    continue;
                if (type.Equals("C36") && digits.Distinct().Count() != 3)
                    continue;

                Permutations<char> p = new Permutations<char>(digits, length);
                List<string> pn = p.Get(",");
                if (pn.Exists(x => list.Contains(x))) continue;
                string number = string.Join(",", i.ToString(format).ToArray());
                list.Add(number);
            }

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
            List<string> results = GetComputeResult(list);
            results.ForEach(writer.WriteLine);
            writer.Close();
        }

        private static void SaveToDB(string name, string type, List<string> list)
        {
            DmFCAnBiz biz = new DmFCAnBiz(name, type);
            List<string> results = GetComputeResult(list);
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
               
                biz.Add(dto);
            }
        }

        private static List<string> GetComputeResult(List<string> list)
        {
            List<string> results = new List<string>();
            foreach (string e in list)
            {
                string[] arr = e.Split(',');
                List<int> el = new List<int>();

                foreach (string str in arr) 
                    el.Add(int.Parse(str));

                string id = e.Replace(",", "");
                string num = e.Replace(",", " ");
                int s = el.Sum();
                string hw = s.ToString().Substring(s.ToString().Length - 1);
                string dx = GetDaXiao(el);
                string ds = GetDanShuang(el);
                string zh = GetZiHe(el);
                string m3 = Get012(el);

                string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", id, num, s, hw, dx, ds, zh, m3);
                results.Add(line);
            }

            return results;
        }

        private static string GetDaXiao(List<int> list)
        {
            List<string> result = new List<string>(list.Count);
            foreach (int e in list)
            {
                result.Add(e > 4 ? "1" : "0");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        private static string GetDanShuang(List<int> list)
        {
            List<string> result = new List<string>(list.Count);
            foreach (int e in list)
            {
                result.Add(e % 2 == 0 ? "0" : "1");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        private static string GetZiHe(List<int> list)
        {
            List<string> result = new List<string>(list.Count);
            foreach (int e in list)
            {
                result.Add((e == 4 ||
                    e == 6 ||
                    e == 8 ||
                    e == 9 ||
                    e == 10) ? "0" : "1");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        private static string Get012(List<int> list)
        {
            List<string> result = new List<string>(list.Count);
            foreach (int e in list)
            {
                result.Add((e % 3).ToString());
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("0")).ToString());
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("2")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.ETL.D12X3
{
    using Model.Common;
    using Model.D12X3;
    using Data.SQLServer;
    using Data.SQLServer.D12X3;
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
        /// 导入湖南幸运赛车所有玩法的号码及相关属性到指定输出设备
        /// </summary>
        /// <param name="output">db|txt</param>
        public static void Add(string output)
        {
            List<Category> categories = CategoryBiz.Instance.GetCategories().Where(x => x.Type.Equals("12X3")).ToList();
            foreach (var category in categories)
            {
                P(category.DbName, "DX", 1, output);
                P(category.DbName, "P2", 2, output);
                P(category.DbName, "P3", 3, output);
                C(category.DbName, "C2", 2, output);
                C(category.DbName, "C3", 3, output);
                Pr(category.DbName, "G2", 2, output);
                Pr(category.DbName, "G3", 3, output);
                Cr(category.DbName, "Z2", 2, output);
                Cr(category.DbName, "Z3", 3, output);
            }
        }

        public static void P(string name,string type, int length,string output)
        {
            var p = new Permutations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12 }, length);
            if (output.Equals("txt"))
            {
                SaveToText(name, type, p);
                return;
            }
            SaveToDB(name, type, p);
        }

        public static void C(string name, string type, int length, string output)
        {
            var c = new Combinations<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, length);
            if (output.Equals("txt"))
            {
                SaveToText(name, type, c);
                return;
            }
            SaveToDB(name, type, c);
        }

        /// <summary>
        /// 可重复排列
        /// </summary>
        public static void Pr(string name, string type, int length, string output)
        {
            List<List<int>> lists = length == 2 ? GetPr2() : GetPr3();
            if (output.Equals("txt"))
            {
                SaveToText(name, type, lists);
                return;
            }
            SaveToDB(name, type, lists);
        }

        /// <summary>
        /// 可重复组合
        /// </summary>
        public static void Cr(string name, string type, int length, string output)
        {
            List<List<int>> lists = length == 2 ? GetPr2() : GetPr3();
            List<string> clist = new List<string>(360);
            foreach (var list in lists)
            {
                Permutations<int> p = new Permutations<int>(list, length);
                List<string> pn = p.Get(",");
                if (pn.Exists(x => clist.Contains(x))) continue;

                clist.Add(list.Format(","));
            }

            if (output.Equals("txt"))
            {
                SaveToText(name, type, clist);
                return;
            }

            SaveToDB(name, type, clist);
        }

        private static void SaveToText(string name, string type, IEnumerable<IList<int>> lists)
        {
            string fileName = string.Format(@"d:\{0}_{1}.txt", name, type);
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            foreach (var list in lists)
            {
                var dto = GetDmFCAn(list,type);
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
                entities.Add(GetDmFCAn(list,type));
            }
            biz.DataAccessor.Insert(entities, SqlInsertMethod.SqlBulkCopy);
        }

        private static void SaveToText(string name, string type, List<string> list)
        {
            string fileName = string.Format(@"d:\{0}_{1}.txt", name, type);
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);
            foreach (var str in list)
            {
                var dto = GetDmFCAn(str.ToList(),type);
                writer.WriteLine(dto.ToString());
            }
            writer.Close();
        }

        private static void SaveToDB(string name, string type, List<string> list)
        {
            DmDPCBiz biz = new DmDPCBiz(name, type);
            List<DmDPC> entities = new List<DmDPC>(list.Count);
            foreach (string str in list)
            {
                entities.Add(GetDmFCAn(str.ToList(),type));
            }
            biz.DataAccessor.Insert(entities, SqlInsertMethod.SqlBulkCopy);
        }

        private static DmDPC GetDmFCAn(IList<int> list,string type)
        {
            DmDPC dto = new DmDPC();
            dto.NumberType = type.Contains("Z") ? GetNumberType(list) : type;
            dto.Id = list.Format();
            dto.Number = list.Format("D2", " ");
            dto.DaXiao = list.GetDaXiao(6);
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
            dto.DaXiaoBi = list.GetDaXiaoBi(6);
            dto.ZiHeBi = list.GetZiHeBi();
            dto.DanShuangBi = list.GetDanShuangBi();
            dto.Lu012Bi = list.GetLu012Bi();

            return dto;
        }

        private static string GetNumberType(IList<int> list)
        {
            int digits = 0;
            if (list.Count == 2)
            {
                digits = list.Distinct().Count();
                return (digits == 2) ? "Z2" : "B2";
            }

            digits = list.Distinct().Count();
            if (digits == 3) return "Z36";
            return (digits == 2) ? "Z33" : "B3";
        }

        private static List<List<int>> GetPr2()
        {
            List<List<int>> pr2List = new List<List<int>>(12 * 12);
            var digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = 0; j < digits.Length; j++)
                {
                    var pr2 = new List<int>();
                    pr2.Add(digits[i]);
                    pr2.Add(digits[j]);
                    pr2List.Add(pr2);
                }
            }

            return pr2List;
        }

        private static List<List<int>> GetPr3()
        {
            List<List<int>> pr3List = new List<List<int>>(12 * 12 * 12);
            var digits = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            for (int i = 0; i < digits.Length; i++)
            {
                for (int j = 0; j < digits.Length; j++)
                {
                    for (int k = 0; k < digits.Length; k++)
                    {
                        var pr3 = new List<int>();
                        pr3.Add(digits[i]);
                        pr3.Add(digits[j]);
                        pr3.Add(digits[k]);
                        pr3List.Add(pr3);
                    }
                }
            }

            return pr3List;
        }
    }
}

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
    using Lottery.Data.SQLServer.Common;
    using Lottery.Data.SQLServer.D11X5;
    using Utils;

    public class ImportDwNumber
    {
        public static void Start()
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("11X5");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Extract");

            foreach (Category category in categories)
            {
                string dataFileName = string.Format(@"{0}\{1}.txt", path, category.Name);
                if (!File.Exists(dataFileName)) continue;
                StreamReader reader = new StreamReader(dataFileName, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line) ||
                        line.Trim().Length == 0) continue;
                    ImportD11X5(line, category.Name);
                }
                reader.Close();
            }
            Console.WriteLine("Finished!");
        }

        private static void ImportD11X5(string line, string name)
        {
            DwNumberBiz biz = null;
            if (name.Equals("江西多乐彩")) biz = new DwNumberBiz("jiangx11x5");
            if (name.Equals("广东11选5")) biz = new DwNumberBiz("guangd11x5");
            if (name.Equals("山东十一运夺金")) biz = new DwNumberBiz("shand11x5");
           
            //biz.Add(dto);
            //writer.WriteLine(dto.ToString());
        }

        public static void UpdateP(int categoryId, string p, string code)
        {
            Category category = CategoryBiz.Instance.GetById(categoryId);
            DwNumberBiz biz = new DwNumberBiz(category.DbName);
            DwNumber number = biz.GetById(p);
            DwNumber newNumber = biz.Create(number.P, number.N, code, number.Date, number.Created.ToString());
            newNumber.Seq = number.Seq;
            biz.Modify(newNumber, newNumber.P.ToString());
        }

        public static void InsertP(int categoryId, string speroid, string code, string sdate)
        {
            string no = code.Replace(" ", ",");
            DateTime datetime = DateTime.Parse(sdate);
            int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
            int p = 2000000000 + int.Parse(speroid);
            int n = int.Parse(speroid.Substring(speroid.Length - 2));

            Category category = CategoryBiz.Instance.GetById(categoryId);
            DwNumberBiz biz = new DwNumberBiz(category.DbName);

            //select MAX(seq) seq from DwNumber where P < 2012073084;
            int seq = biz.DataAccessor.GetMaxValue(DwNumber.C_Seq, 10, "where P <" + p);
            DwNumber number = biz.Create(p, n, no, dateint, sdate);
            number.Seq = seq + 1;
            //biz.AddC5CXSpan(number);
            //biz.Add(number);

            //UPDATE DwNumber set Seq=seq+ 1 where P > 2012073084;
            //biz.DataAccessor.UpdateSeq(1, p);
        }
    }
}

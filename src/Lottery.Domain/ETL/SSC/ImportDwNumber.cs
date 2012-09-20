using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL.SSC
{
    using Model.Common;
    using Model.SSC;
    using Lottery.Data.SQLServer.Common;
    using Lottery.Data.SQLServer.SSC;
    using Utils;

    public class ImportDwNumber
    {
        public static void Start()
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("SSC");
            foreach (Category category in categories)
            {
                string dataFileName = string.Format(@"{0}\{1}.txt", @"G:\LotteryData", category.Name);
                if (!File.Exists(dataFileName)) continue;
                StreamReader reader = new StreamReader(dataFileName, Encoding.UTF8);
                int index = 1;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line) ||
                        line.Trim().Length == 0) continue;
                    ImportSSC(line, category.Name,index);
                    index ++;
                }
                reader.Close();
            }
            Console.WriteLine("Finished!");
        }

        private static void ImportSSC(string line, string name,int index)
        {
            DwNumberBiz biz = null;
            if (name.Equals("江西时时彩")) biz = new DwNumberBiz("JiangXSSC");
            if (name.Equals("重庆时时彩")) biz = new DwNumberBiz("ChongQSSC");

            //biz.Add(dto);
        }

        public static void UpdateC45()
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("SSC");
            foreach (Category category in categories)
            {
                DwNumberBiz biz = new DwNumberBiz(category.DbName);
                List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty,
                    "Seq", Data.SortTypeEnum.ASC, null, "P", "P4", "P5");

                foreach (var number in numbers)
                {
                    string c4 = NumberCache.Instance.GetNumberId("C4", number.P4);
                    string c5 = NumberCache.Instance.GetNumberId("C5", number.P5);
                    string sql = string.Format("update {0} set {1} = '{2}',{3} = '{4}' where P = {5}",
                        DwNumber.ENTITYNAME, "C4", c4, "C5", c5, number.P);
                    Data.SqlHelper.ExecuteNonQuery(biz.DataAccessor.ConnectionString, System.Data.CommandType.Text, sql);
                }
            }
        }
    }
}

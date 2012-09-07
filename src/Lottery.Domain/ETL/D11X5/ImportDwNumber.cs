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
    using Lottery.Data.SQLServer.Common;
    using Lottery.Data.SQLServer.D11X5;

    public class ImportDwNumber
    {
        public static void Start()
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("11X5");
            foreach (Category category in categories)
            {
                //StreamWriter writer = new StreamWriter(string.Format(@"G:\LotteryData\{0}_1.txt", category.Name));
                string dataFileName = string.Format(@"{0}\{1}.txt", @"G:\LotteryData", category.Name);
                if (!File.Exists(dataFileName)) continue;
                StreamReader reader = new StreamReader(dataFileName, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line) ||
                        line.Trim().Length == 0) continue;
                    ImportD11X5(line, category.Name
                        //,writer
                        );
                }
                reader.Close();
                //writer.Close();
            }
            Console.WriteLine("Finished!");
        }

        private static void ImportD11X5(string line, string name
            //,StreamWriter writer
            )
        {
            DwNumberBiz biz = null;
            if (name.Equals("江西多乐彩")) biz = new DwNumberBiz("jiangx11x5");
            if (name.Equals("广东11选5")) biz = new DwNumberBiz("guangd11x5");
            if (name.Equals("山东十一运夺金")) biz = new DwNumberBiz("shand11x5");

            string[] arr = line.Trim().Split(',');
            DwNumber dto = new DwNumber();
            dto.D1 = int.Parse(arr[0]);
            dto.D2 = int.Parse(arr[1]);
            dto.D3 = int.Parse(arr[2]);
            dto.D4 = int.Parse(arr[3]);
            dto.D5 = int.Parse(arr[4]);
            dto.F2 = arr[5];
            dto.F3 = arr[6];
            dto.F5 = arr[7];
            dto.P = int.Parse(arr[8]);
            dto.N = int.Parse(arr[9]);
            dto.Date = int.Parse(arr[10]);
            dto.Created = DateTime.Parse(arr[11]);
            dto.C2 = NumberBiz.Instance.GetC2Id(string.Format("{0},{1}", arr[0], arr[1]));
            dto.C3 = NumberBiz.Instance.GetC3Id(string.Format("{0},{1},{2}", arr[0], arr[1],arr[2]));
            dto.A5 = NumberBiz.Instance.GetA5Id(string.Format("{0},{1},{2},{3},{4}", arr[0], arr[1], arr[2], arr[3], arr[4]));

            //biz.Add(dto);
            //writer.WriteLine(dto.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL.SCC
{
    using Model.Common;
    using Model.SSC;
    //using Model.D11X5;
    using Lottery.Data.SQLServer.Common;
    //using Lottery.Data.SQLServer.D11X5;
    using Lottery.Data.SQLServer.SSC;
    using Utils;

    public class ImportDwNumber
    {
        public static void Start()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("ssc");
            foreach (DmCategory category in categories)
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

        private static void ImportD11X5(string line, string name )
        {
            //DwNumberBiz biz = null;
            //if (name.Equals("江西多乐彩")) biz = new DwNumberBiz("jiangx11x5");
            //if (name.Equals("广东11选5")) biz = new DwNumberBiz("guangd11x5");
            //if (name.Equals("山东十一运夺金")) biz = new DwNumberBiz("shand11x5");

            //string[] arr = line.Trim().Split(',');
            //DwNumber dto = new DwNumber();
            //dto.D1 = int.Parse(arr[0]);
            //dto.D2 = int.Parse(arr[1]);
            //dto.D3 = int.Parse(arr[2]);
            //dto.D4 = int.Parse(arr[3]);
            //dto.D5 = int.Parse(arr[4]);
            //dto.F2 = arr[5];
            //dto.F3 = arr[6];
            //dto.F5 = arr[7];
            //dto.P = int.Parse(arr[8]);
            //dto.N = int.Parse(arr[9]);
            //dto.Date = int.Parse(arr[10]);
            //dto.Created = DateTime.Parse(arr[11]);
            //dto.C2 = NumberBiz.Instance.GetC2Id(string.Format("{0},{1}", arr[0], arr[1]));
            //dto.C3 = NumberBiz.Instance.GetC3Id(string.Format("{0},{1},{2}", arr[0], arr[1],arr[2]));
            //dto.A5 = NumberBiz.Instance.GetA5Id(string.Format("{0},{1},{2},{3},{4}", arr[0], arr[1], arr[2], arr[3], arr[4]));

            //biz.Add(dto);
            //writer.WriteLine(dto.ToString());
        }

        private static void ImportSSC(string line, string name,int index)
        {
            DwNumberBiz biz = null;
            if (name.Equals("江西时时彩")) biz = new DwNumberBiz("JiangXSSC");
            if (name.Equals("重庆时时彩")) biz = new DwNumberBiz("ChongQSSC");

            string[] arr = line.Trim().Split(',');
            DwNumber dto = new DwNumber();
            dto.Date = ConvertHelper.GetInt32(arr[11]);
            dto.P = ConvertHelper.GetInt64(arr[0]);
            dto.N = ConvertHelper.GetInt32(arr[10]);
            dto.Seq = index;
            dto.D5 = ConvertHelper.GetInt32(arr[1]);
            dto.D4 = ConvertHelper.GetInt32(arr[2]);
            dto.D3 = ConvertHelper.GetInt32(arr[3]);
            dto.D2 = ConvertHelper.GetInt32(arr[4]);
            dto.D1 = ConvertHelper.GetInt32(arr[5]);
            dto.Created = ConvertHelper.GetDateTime(arr[12]);
            dto.P5 = arr[9];
            dto.P4 = arr[8];
            dto.P3 = arr[7];
            dto.P2 = arr[6];
            dto.C2 = NumberBiz.Instance.GetC2Id(dto.P2);
            dto.C3 = NumberBiz.Instance.GetC3Id(dto.P3);
            //dto.C33 = NumberBiz.Instance.GetC33Id(dto.P3);
            //dto.C36 = NumberBiz.Instance.GetC36Id(dto.P3);

            biz.Add(dto);
        }
    }
}

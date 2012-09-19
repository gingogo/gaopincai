using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data.SQLServer.Common;
    using Utils;

    public class ImportDimension
    {
        public static void Import()
        {
            ImportD5();
        }

        private static void ImportD5()
        {
            Dictionary<string,string> dict =  new Dictionary<string,string>(11);
            dict.Add("Peroid","期");
            dict.Add("DaXiao","大小");
            dict.Add("DanShuang","单双");
            dict.Add("ZiHe","质合");
            dict.Add("Lu012","012路");
            dict.Add("He","和");
            dict.Add("HeWei","和尾");
            dict.Add("Ji","积");
            dict.Add("JiWei","积尾");
            dict.Add("KuaDu","跨度");
            dict.Add("AC","AC");

            foreach (var kp in dict)
            {
                Dimension dim = new Dimension();
                dim.Name = kp.Value;
                dim.Code = kp.Key;
                dim.Type = "D5";
                dim.Seq = 10;
                DimensionBiz.Instance.Add(dim);
            }
        }

        private static void LoadData()
        {
            Dictionary<string, Dictionary<string, string[]>> dictCaching = new Dictionary<string, Dictionary<string, string[]>>(5);
            string[] d3NumberTypes1 = new string[] { "D1", "D2", "D3", "P2", "C2", "P3", "C3" };
            string[] d3NumberTypes2 = new string[] { "P2", "C2", "P3", "C3" };
            string[] d3NumberTypes3 = new string[] { "P3", "C3" };

            string[] d5NumberTypes1 = new string[] { "D1", "D2", "D3", "D4", "D5", "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };
            string[] d5NumberTypes2 = new string[] { "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };
            string[] d5NumberTypes3 = new string[] { "P3", "C3", "P4", "C4", "P5", "C5" };

            Dictionary<string, string[]> d3DimNumberTypes = new Dictionary<string, string[]>(11);
            d3DimNumberTypes.Add("Peroid", d3NumberTypes1);
            d3DimNumberTypes.Add("DaXiao", d3NumberTypes1);
            d3DimNumberTypes.Add("DanShuang", d3NumberTypes1);
            d3DimNumberTypes.Add("ZiHe", d3NumberTypes1);
            d3DimNumberTypes.Add("Lu012", d3NumberTypes1);
            d3DimNumberTypes.Add("He", d3NumberTypes2);
            d3DimNumberTypes.Add("HeWei", d3NumberTypes2);
            d3DimNumberTypes.Add("Ji", d3NumberTypes2);
            d3DimNumberTypes.Add("JiWei", d3NumberTypes2);
            d3DimNumberTypes.Add("KuaDu", d3NumberTypes2);
            d3DimNumberTypes.Add("AC", d3NumberTypes3);

            Dictionary<string, string[]> d5DimNumberTypes = new Dictionary<string, string[]>(11);
            d5DimNumberTypes.Add("Peroid", d5NumberTypes1);
            d5DimNumberTypes.Add("DaXiao", d5NumberTypes1);
            d5DimNumberTypes.Add("DanShuang", d5NumberTypes1);
            d5DimNumberTypes.Add("ZiHe", d5NumberTypes1);
            d5DimNumberTypes.Add("Lu012", d5NumberTypes1);
            d5DimNumberTypes.Add("He", d5NumberTypes2);
            d5DimNumberTypes.Add("HeWei", d5NumberTypes2);
            d5DimNumberTypes.Add("Ji", d5NumberTypes2);
            d5DimNumberTypes.Add("JiWei", d5NumberTypes2);
            d5DimNumberTypes.Add("KuaDu", d5NumberTypes2);
            d5DimNumberTypes.Add("AC", d5NumberTypes3);

            dictCaching.Add("D3", d3DimNumberTypes);
            dictCaching.Add("D5", d5DimNumberTypes);
        }
    }
}

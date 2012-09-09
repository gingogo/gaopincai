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
    }
}

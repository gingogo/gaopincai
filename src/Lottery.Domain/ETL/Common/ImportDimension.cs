using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data.Biz.Common;
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
            //dict.Add("Peroid","期");
            //dict.Add("DaXiao","大小");
            //dict.Add("DanShuang","单双");
            //dict.Add("ZiHe","质合");
            //dict.Add("Lu012","012路");
            //dict.Add("He","和");
            //dict.Add("HeWei","和尾");
            //dict.Add("Ji","积");
            //dict.Add("JiWei","积尾");
            //dict.Add("KuaDu","跨度");
            //dict.Add("AC","AC");
            //dict.Add("DaXiaoBi", "大小比");
            //dict.Add("ZiHeBi", "质合比");
            //dict.Add("DanShuangBi", "单双比");
            //dict.Add("Lu012Bi", "012路比");

            foreach (var kp in dict)
            {
                Dimension dim = new Dimension();
                dim.Name = kp.Value;
                dim.Code = kp.Key;
                dim.Seq = 100;
                DimensionBiz.Instance.Add(dim);
            }
        }
    }
}

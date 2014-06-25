using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.Test.D11X5
{
    using Data.D11X5;
    using Configuration;
    using Logging;
    using Model.D11X5;
    using Utils;
    using Data.Biz.D11X5;
    using Data;

    public class AvgSpan
    {
        public static void ComputeAvg()
        {
            Dictionary<string, List<int>> numberSpanDict = new Dictionary<string, List<int>>(110);
            DwNumberBiz biz = new DwNumberBiz("shand11x5");
            DwSpanBiz spanBiz = new DwSpanBiz("shand11x5", "peroid");
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, DwNumber.C_P, SortTypeEnum.ASC, null, DwNumber.C_P, DwNumber.C_P2);
            List<DwSpan> periodSpans = spanBiz.DataAccessor.SelectWithCondition(string.Empty, DwSpan.C_P, SortTypeEnum.ASC, null, DwSpan.C_P, DwSpan.C_P2Spans);

            var spanDict = periodSpans.ToDictionary(x => x.P, y => y.P2Spans);
            foreach (var number in numbers)
            {
                if (!numberSpanDict.ContainsKey(number.P2))
                {
                    numberSpanDict.Add(number.P2, new List<int>(10000));
                }
                numberSpanDict[number.P2].Add(spanDict[number.P]);
            }

            StreamWriter sw = new StreamWriter(@"E:\avgSpan.txt", false, Encoding.UTF8);
            foreach (var kv in numberSpanDict)
            {
                int total = 0;
                for (var i = 0; i < kv.Value.Count; i++)
                {
                    total += kv.Value[i];
                    sw.WriteLine("{0},{1},{2},{3}", kv.Key, i + 1, (total * 1.0) / ((i + 1) * 1.0), kv.Value[i]);
                }
            }
            sw.Close();
        }
    }
}

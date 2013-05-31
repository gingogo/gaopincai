using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.D11X5
{
    using Configuration;
    using Data;
    using Data.Biz;
    using Data.D11X5;
    using Data.Biz.Common;
    using Data.Biz.D11X5;
    using Model.D11X5;
    using Utils;

    public class C1Stat
    {
        public void C1StatMain(string dbName)
        {
            DwNumberBiz biz = new DwNumberBiz(dbName);
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);
            Span(numbers);
        }

        private void Span(List<DwNumber> numbers)
        {
            string[] dxs = { "D1", "D2", "D3", "D4", "D5" };
            var spanDict = new Dictionary<int, int>(11);
            StreamWriter sw = new StreamWriter(@"d:\c1span.txt", false, Encoding.UTF8);
            foreach (var number in numbers)
            {
                foreach (var dx in dxs)
                {
                    int spans = number.Seq - 1;
                    int dxValue = ConvertHelper.GetInt32(number[dx].ToString());
                    if (spanDict.ContainsKey(dxValue))
                    {
                        spans = number.Seq - spanDict[dxValue] - 1;
                        spanDict[dxValue] = number.Seq;
                    }
                    else
                    {
                        spanDict.Add(dxValue, -1);
                    }
                    sw.WriteLine("{0},{1},{2}", number.P, dxValue, spans);
                }
            }
            sw.Close();
        }

        private void PeriodSpan(List<DwNumber> numbers)
        {

        }

        private void ContiniousSpan(List<DwNumber> numbers)
        {
        }
    }
}

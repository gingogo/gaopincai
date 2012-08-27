using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lottery.Statistics.SSC
{
    using Data;
    using Data.SQLServer.Common;
    using Data.SQLServer.SSC;
    using Model.Common;
    using Model.SSC;

    /// <summary>
    /// 统计期数间隔的分布。
    /// Field:DwPeroidSpan表中的字段
    /// </summary>
    public class PeroidSpan : BaseSSCStatistics
    {
        protected override void Stat(object dbName)
        {
            DwNumberBiz biz = new DwNumberBiz(dbName.ToString());
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null);
            //List<DwNumber> allNumbers = biz.DataAccessor.SelectTopN(10, string.Empty, "P", SortTypeEnum.ASC, null);
            //string[] rules = new string[] { "D1", "P2", "C2", "P3", "C3", "C33", "C36", "P4", "P5" };
            string[] rules = new string[] { "P5" };

            foreach (string rule in rules)
            {
                //this.Stat(allNumbers, rule, dbName.ToString());
                Console.WriteLine("{0} {1} Finished", dbName, rule);
            }
        }

        //private void Stat(List<DwNumber> allNumbers, string rule,string dbName)
        //{
        //    if (rule.Equals("P4") || rule.Equals("P5"))
        //    {
        //        this.StatP4P5(allNumbers, dbName, rule);
        //        return;
        //    }

        //    DwPeroidSpanBiz biz = new DwPeroidSpanBiz(dbName, rule);
        //    string propertyName = (rule.Equals("C33") || rule.Equals("C36")) ? "C3" : rule;
        //    var ruleNumberDict = NumberBiz.Instance.GetNumberIds(rule);
        //    foreach (string numberId in ruleNumberDict.Keys)
        //    {
        //        var numbers = allNumbers.Where(x => x[propertyName].ToString().Equals(numberId)).OrderBy(x => x.Seq).ToArray();
        //        for (int j = 0; j < numbers.Length; j++)
        //        {
        //            int spans = -1;
        //            int lastN = 0;
        //            if (j > 0)
        //            {
        //                spans = numbers[j].Seq - numbers[j - 1].Seq - 1;
        //                lastN = numbers[j - 1].N;
        //            }
        //            DwPeroidSpan ps = new DwPeroidSpan();
        //            ps.P = numbers[j].P;
        //            ps.NumberId = numberId;
        //            ps.Spans = spans;
        //            ps.LastN = lastN;
        //            biz.Add(ps);
        //        }
        //    }
        //}

        //private void StatP4P5(List<DwNumber> allNumbers, string dbName,string rule)
        //{
        //    DwPeroidSpanBiz biz = new DwPeroidSpanBiz(dbName, rule);
        //    Dictionary<string, DwNumber> mappingTable = new Dictionary<string, DwNumber>(allNumbers.Count);
        //    foreach (var number in allNumbers)
        //    {
        //        int spans = -1;
        //        int lastN = 0;
        //        string key = number[rule].ToString();

        //        if (!mappingTable.ContainsKey(key))
        //        {
        //            mappingTable.Add(key, number);
        //        }
        //        else
        //        {
        //            spans = number.Seq - mappingTable[key].Seq - 1;
        //            lastN = mappingTable[key].N;
        //            mappingTable[key] = number;
        //        }

        //        DwPeroidSpan ps = new DwPeroidSpan();
        //        ps.P = number.P;
        //        ps.NumberId = key;
        //        ps.Spans = spans;
        //        ps.LastN = lastN;
        //        biz.Add(ps);
        //    }
        //}
    }
}

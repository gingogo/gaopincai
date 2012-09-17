using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lottery.Statistics.D11X5
{
    using Data;
    using Model.D11X5;
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 统计N期内每个号出现次数的分布。
    /// </summary>
    public class NPeroidNumberCount : Base11X5Statistics
    {
        protected override void Stat(string dbName, OutputType outputType)
        {
            DwNumberBiz biz = new DwNumberBiz(dbName.ToString());
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null);
            //List<DwNumber> allNumbers = biz.DataAccessor.SelectTopN(10, string.Empty, "P", SortTypeEnum.ASC, null);
            //string[] rules = new string[] { "D1", "F2", "C2", "F3", "C3", "A5"};
            string[] rules = new string[] {"F2" };
            foreach (string rule in rules)
            {
                this.Stat(allNumbers, rule, dbName.ToString());
                Console.WriteLine("{0} {1} Finished", dbName, rule);
            }
        }

        private void Stat(List<DwNumber> allNumbers, string rule, string dbName)
        {
            string fileName = string.Format("Dw{0}_{1}_{2}.txt", dbName.ToString(), rule, "Peroid1008Count");
            string filePath = string.Empty;//string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);

            for (int i = 0; i < allNumbers.Count; i++)
            {
                if (i + 1008 >= allNumbers.Count) break;
                var group = allNumbers.GetRange(i, 1008).GroupBy(x => x.P2);
                foreach (var g in group)
                {
                    string line = string.Format("{0},{1},{2}", allNumbers[i].P, g.Key, g.Count());
                    writer.WriteLine(line);
                }
            }
            writer.Close();
        }
    }
}

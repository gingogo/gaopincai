using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lottery.Statistics.D11X5.F3
{
    using Model.D11X5;
    using Model.Common;
    using Data;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 统计F3期数间隔的收敛。
    /// </summary>
    public class F3PeroidSpanLimit : BaseStatistics, IStatistics
    {
        public void StatAll()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("11X5");
            Thread[] threads = new Thread[categories.Count];
            for (int i = 0; i < categories.Count; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(this.Stat));
                threads[i].Start(categories[i].DbName);
                //this.Stat(categories[i].dbName);
            }
        }

        private void Stat(object dbName)
        {
            string name = dbName.ToString();
            DwPeroidSpanBiz biz = new DwPeroidSpanBiz(name, "F3");
            List<DwPeroidSpan> allNumbers = biz.GetAll("NumberId","P", "Spans");
            string[] numberIds = NumberBiz.Instance.F3.Keys.ToArray();

            string fileName = string.Format("Dw{0}_{1}.txt", name, "F3_PeroidSpanLimit");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (string numberId in numberIds)
            {
                var numbers = allNumbers
                    .Where(x => x.NumberId.Trim().Equals(numberId) && x.Spans > -1)
                    .OrderBy(x => x.P)
                    .ToList();
                if (numbers.Count == 0) continue;
                int tAvg = Convert.ToInt32(numbers.Average(x => x.Spans));

                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int n = 3; n < numbers.Count; n++)
                    {
                        if (i + n >= numbers.Count) break;
                        var avg = Convert.ToInt32(numbers.GetRange(i, n).Average(x => x.Spans));
                        int absAvg = Convert.ToInt32(Math.Abs(tAvg - avg));
                        if (absAvg > 1) continue;
                        string line = string.Format("{0},{1}", numbers[i].NumberId, n);
                        writer.WriteLine(line);
                        break;
                    }
                }
            }

            writer.Close();
            Console.WriteLine("{0},F3PeroidSpanLimit,Finished", dbName);
        }
    }
}

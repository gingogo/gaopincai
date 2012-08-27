using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lottery.Statistics.D11X5.F3
{
    using Data;
    using Model.D11X5;
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 统计F3期数间隔的分布。
    /// Field:{Number:任五,Spans:与上次之间的间隔期数,N:当前所在期，LastN:前一次所在期}
    /// </summary>
    public class F3PeroidSpan : BaseStatistics, IStatistics
    {
        public void StatAll()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("11X5");
            Thread[] threads = new Thread[categories.Count];
            for (int i = 0; i < categories.Count; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(this.Stat));
                threads[i].Start(categories[i].DbName);
                //this.Stat(categories[j].dbName);
            }
        }

        private void Stat(object dbName)
        {
            DwNumberBiz biz = new DwNumberBiz(dbName.ToString());
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null, "F3", "P", "N", "Date");
            for (int i = 0; i < allNumbers.Count; i++) allNumbers[i].Seq = i+1;
            HashSet<string> allF3Numbers = this.GetAllF3Numbers(dbName.ToString());

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "F3_PeroidSpan");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (string numberId in allF3Numbers)
            {
                var numbers = allNumbers.Where(x => x.F3.Trim().Equals(numberId)).OrderBy(x => x.Seq).ToArray();
                for (int j = 0; j < numbers.Length; j++)
                {
                    int spans = -1;
                    int lastN = 0;
                    if (j > 0)
                    {
                        spans = numbers[j].Seq - numbers[j - 1].Seq - 1;
                        lastN = numbers[j - 1].N;
                    }
                    string line = string.Format("{0},{1},{2},{3}", numbers[j].P, numberId, spans, lastN);
                    writer.WriteLine(line);
                }
            }

            writer.Close();
            Console.WriteLine("{0},F3PeroidSpan,Finished", dbName);
        }
    }
}

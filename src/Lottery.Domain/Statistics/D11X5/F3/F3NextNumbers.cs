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
    /// 统计F3下一个号码分布。
    /// Field:{F3:前三,Next:下一个号,C:出现次数}
    /// </summary>
    public class F3NextNumbers : BaseStatistics, IStatistics
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
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null, "F3");
            for (int i = 0; i < allNumbers.Count; i++) allNumbers[i].Seq = i;

            int numberCount = allNumbers.Count;
            Dictionary<string, int> nextDict = new Dictionary<string, int>(990*990);
            string[] f3Numbers = null; // biz.DataAccessor.SelectDistinctF3();
            foreach (string f3 in f3Numbers)
            {
                foreach (string f31 in f3Numbers)
                {
                    nextDict.Add(string.Format("{0},{1}", f3.Trim(), f31.Trim()), 0);
                }
            }

            foreach (string f3 in f3Numbers)
            {
                var numbers = allNumbers.Where(x => x.F3.Trim().Equals(f3.Trim()));
                foreach (var number in numbers)
                {
                    int nextIndex = number.Seq + 1;
                    if (nextIndex >= allNumbers.Count) continue;
                    string key = string.Format("{0},{1}", f3.Trim(), allNumbers[nextIndex].F3.Trim());
                    nextDict[key]++;
                }
            }

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "F3_NextNumbers");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (var kp in nextDict)
            {
                string line = string.Format("{0},{1}", kp.Key, kp.Value);
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("{0},F3NextNumbers,Finished", dbName);
        }
    }
}

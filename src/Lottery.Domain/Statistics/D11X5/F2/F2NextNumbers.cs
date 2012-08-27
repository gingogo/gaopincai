using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace Lottery.Statistics.D11X5.F2
{
    using Data;
    using Model.D11X5;
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 统计F2下一个号码分布。Field:{F2:前二,Next:下一个号,C:出现次数}
    /// </summary>
    public class F2NextNumbers : BaseStatistics, IStatistics
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
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null, "F2");
            for (int i = 0; i < allNumbers.Count; i++) allNumbers[i].Seq = i;

            Dictionary<string, int> nextDict = new Dictionary<string, int>(110*110);
            string[] f2Numbers = null;// biz.DataAccessor.SelectDistinctF2();
            foreach (string f2 in f2Numbers)
            {
                foreach (string f21 in f2Numbers)
                {
                    nextDict.Add(string.Format("{0},{1}", f2.Trim(), f21.Trim()), 0);
                }
            }

            foreach (string f2 in f2Numbers)
            {
                var numbers = allNumbers.Where(x => x.F2.Trim().Equals(f2.Trim()));
                foreach (var number in numbers)
                {
                    int nextIndex = number.Seq + 1;
                    if (nextIndex >= allNumbers.Count) continue;
                    string key = string.Format("{0},{1}", f2.Trim(), allNumbers[nextIndex].F2.Trim());
                    nextDict[key]++;
                }
            }

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "F2_NextNumbers");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (var kp in nextDict)
            {
                string line = string.Format("{0},{1}", kp.Key, kp.Value);
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("{0},F2NextNumbers,Finished", dbName);
        }
    }
}

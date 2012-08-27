using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace Lottery.Statistics.D11X5.D1
{
    using Data;
    using Model.D11X5;
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 统计D1下一个号码分布。Field:{D1:前一,Next:下一个号,C:出现次数}
    /// </summary>
    public class D1NextNumbers : BaseStatistics,IStatistics
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
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null, "D1");
            for (int i = 0; i < allNumbers.Count; i++) allNumbers[i].Seq = i;

            int numberCount = allNumbers.Count;
            Dictionary<string, int> nextNumberDict = new Dictionary<string, int>(11*11);
            for (int i = 1; i <= 11; i++)
            {
                var numbers = allNumbers.Where(x => x.D1.Equals(i));
                foreach (var number in numbers)
                {
                    int nextIndex = number.Seq + 1;
                    if (nextIndex >= numberCount) continue;
                    string key = string.Format("{0},{1}", i, allNumbers[nextIndex].D1);
                    if (nextNumberDict.ContainsKey(key))
                    {
                        nextNumberDict[key]++;
                    }
                    else
                    {
                        nextNumberDict.Add(key, 1);
                    }
                }
            }

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "D1_NextNumbers");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            foreach (var kp in nextNumberDict)
            {
                string line = string.Format("{0},{1}", kp.Key, kp.Value);
                writer.WriteLine(line);
            }
            writer.Close();
            Console.WriteLine("{0},D1NextNumbers,Finished", dbName);
        }
    }
}

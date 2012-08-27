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
    /// 以期为周期统计前一号码出现个数的分布.
    /// Field:{P:起始期号,N:间隔N期,C:出现号码个数}
    /// 表示从P期起，第N期内一共出现C个前一号码(重复出现的只算一次)
    /// </summary>
    public class D1PeroidNumbers : BaseStatistics, IStatistics
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
            List<DwNumber> allNumbers = biz.DataAccessor.SelectWithCondition(string.Empty, "P", SortTypeEnum.ASC, null, "D1", "P");
            int numberCount = allNumbers.Count;
            HashSet<int> allD1Numbers = this.GetAllD1Numbers();

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "D1_PeroidNumbers");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            for (int i = 0; i < numberCount - 5; i++)
            {
                int count = 0;
                for (int n = 5; count < 11; n++)
                {
                    if (i + n >= numberCount) break;
                    var subSet = allNumbers.GetRange(i, n).Select(y => y.D1).Distinct();
                    count = this.GetCount<int>(subSet, allD1Numbers);
                    string line = string.Format("{0},{1},{2}", allNumbers[i].P, n, count);
                    writer.WriteLine(line);
                }
            }
            writer.Close();
            Console.WriteLine("{0},D1PeroidNumbers,Finished", dbName);
        }
    }
}

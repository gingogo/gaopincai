using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace Lottery.Statistics.D11X5.F2
{
    using Model.D11X5;
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;

    /// <summary>
    /// 以天为周期统计前二号码出现的个数的分布。
    /// Field:{Day:天,C:所出前二号码总个数,Date:统计起始日期}
    /// 表示从Date开始，第Day天内，出了C个前二号码(重复出现的只算一次)。
    /// </summary>
    public class F2DayNumbers : BaseStatistics, IStatistics
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
            List<DwNumber> allNumbers = biz.GetAll("F2","Date");
            List<DwNumber> allDates = biz.DataAccessor.SelectDistinctDate();
            int end = allDates.Count;
            HashSet<string> allF2Numbers = this.GetAllF2Numbers(dbName.ToString());

            string fileName = string.Format("Dw{0}_{1}.txt", dbName.ToString(), "F2_DayNumbers");
            string filePath = string.Format("{0}\\{1}", this._rootPath, fileName);
            StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8);
            for (int i = 0; i < end; i++)
            {
                int count = 0;
                for (int day = 0; count < 110; day++)
                {
                    int next = i + day;
                    if (next >= end) break;
                    var subSet = allNumbers
                        .Where(x => x.Date >= allDates[i].Date && x.Date <= allDates[next].Date)
                        .Select(y => y.F2.Trim())
                        .Distinct();
                    count = this.GetCount<string>(subSet, allF2Numbers);
                    string line = string.Format("{0},{1},{2}", allDates[i].Date, day + 1, count);
                    writer.WriteLine(line);
                }
            }
            writer.Close();
            Console.WriteLine("{0},F2DayNumbers,Finished", dbName);
        }
    }
}

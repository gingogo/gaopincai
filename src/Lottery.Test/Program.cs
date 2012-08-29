using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Test
{
    using Model.Common;
    using Data.SQLServer.D11X5;
    using Data.SQLServer.Common;
    using ETL;
    using Utils;

    class Program
    {
        static void Main(string[] args)
        {
            //DownServiceTest();
            //StatTest();
            //ExtractLotteryData();
            //DmFCAnTest();
            Console.WriteLine("Finished");
            Console.Read();
        }

        static void ExtractLotteryData()
        {
            //DataDownload.DownPage();
            //ExtractData.Extract();
            ETL.SCC.ImportDwNumber.Start();
        }

        static void RepairPeroidSpan()
        {
            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("11X5");
            foreach (var category in categories)
            {
                DwNumberBiz biz = new DwNumberBiz(category.DbName);
                biz.RepairPeroidSpan("D1");
            }
        }

        static void DownServiceTest()
        {
            try
            {
                Services.DownloadService s = new Services.DownloadService();
                s.StartSync(DateTime.Now);
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Write(ex.ToString());
            }
        }

        static void DmFCAnTest()
        {
            //ETL.D11X5.ImportDmFCAn.Add("txt");
            //ETL.SCC.ImportDmFCAn.Add("txt");
        }

        static void StatTest()
        {
            Statistics.IStatistics[] stats = new Statistics.IStatistics[] 
            {
                //new Statistics.D11X5.D1.D1NextNumbers()
                //,
                //new Statistics.D11X5.D1.D1PeroidNumbers()
                //,
                //new Statistics.D11X5.D1.D1PeroidSpan()
                //,

                //new Statistics.D11X5.P2.F2NextNumbers()
                //,
                //new Statistics.D11X5.P2.F2DayNumbers()
                //,
                //new Statistics.D11X5.P2.F2PeroidSpan()
                //,
                //new Statistics.D11X5.P2.F2PeroidSpanLimit()
                //,
                //new Statistics.D11X5.P3.F3NextNumbers()
                //,
                //new Statistics.D11X5.P3.F3DayNumbers()
                //,
                //new Statistics.D11X5.P3.F3PeroidSpan()
                //new Statistics.D11X5.C2.C2PeroidSpan()
                //new Statistics.D11X5.C3.C3PeroidSpan()
                //new Statistics.D11X5.P4.A5PeroidSpan()
                //new Statistics.D11X5.A5.A5PeroidSpanLimit(),
                //new Statistics.D11X5.F2.F2PeroidSpanLimit()
                //new Statistics.D11X5.Peroid1008Count()
                new Statistics.SSC.PeroidSpan()
            };

            foreach (var stat in stats)
            {
                stat.Stat();
            }
        }

        static void OtherTest()
        {
            Combinations<int> c3 = new Combinations<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);
            List<string> c3s = c3.Get(",");

        }
    }
}

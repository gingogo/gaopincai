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
    using Analysis.Formula;

    class Program
    {
        static void Main(string[] args)
        {
            //OmissionValueTest();
            //DownServiceTest();
            //StatTest();
            //ExtractLotteryData();
            ETLTest();
            //TransactionTest();
            //FormulaTest();
            //Console.WriteLine((1%3).ToString());
            Console.WriteLine("Finished");
            Console.Read();
        }

        static void OmissionValueTest()
        {
            //OmissionValueBiz biz = new OmissionValueBiz("jiangx11x5");
            //List<OmissionValue> omissionValues = biz.GetAll("11X5", "F2", "DaXiao",
            //    string.Empty, "CurrentSpans", "DESC");
        }

        static void FormulaTest()
        {
            Console.WriteLine(FFG.GetDC(119, 1.0 / 10.0));
            Console.WriteLine(Deviation.GetColdByDC(0.959, 1.0 / 10.0));
            Console.WriteLine(Deviation.GetWatchColdN(0.959, 0.999, 1.0 / 110.0));
        }

        static void ExtractLotteryData()
        {
            //DataDownload.DownPage(101);
            //DataDownload.DownPage(106);

            //ExtractData.Extract(101);
            //ExtractData.Extract(106);
            
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

        static void ETLTest()
        {
            //ETL.D11X5.ImportDmFCAn.Add("db");
            //ETL.SCC.ImportDmFCAn.Add("db");
            //ETL.SCC.ImportDwNumber.Start();
            //ETL.Common.ImportDimension.Import();
            ETL.Common.ImportNumberType.Import();
            //ETL.Common.ImportNumberTypeDim.Import();
            //ETL.D11X5.ImportDwNumber.UpdateC4();
            //ETL.SCC.ImportDwNumber.UpdateC45();
        }

        static void StatTest()
        {
            Statistics.IStatistics[] stats = new Statistics.IStatistics[] 
            {
                //new Statistics.D11X5.PeroidSpan(),
                //new Statistics.D11X5.DmSpan(),
                //new Statistics.SSC.PeroidSpan(),
                //new Statistics.SSC.DmSpan(),
                //new Statistics.D3.PeroidSpan(),
                //new Statistics.D3.DmSpan()
                //new Statistics.PL35.PeroidSpan(),
                //new Statistics.PL35.DmSpan()
            };

            foreach (var stat in stats)
            {
                stat.Stat(Statistics.OutputType.Database, true);
                //stat.Stat(Statistics.OutputType.Database, false);
            }
        }

        static void OtherTest()
        {
            Combinations<int> c3 = new Combinations<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);
            List<string> c3s = c3.Get(",");

        }

        static void TransactionTest()
        {
            TransactionScopeTest.Test();
        }
    }
}

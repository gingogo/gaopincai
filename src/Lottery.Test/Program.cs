using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Test
{
//    using Model.Common;
//    using Data.SQLServer.D11X5;
//    using Data.SQLServer.Common;
//    using ETL;
//    using Utils;
//    using Analysis.Formula;
//    using Data.Downloader;
//
    using Statistics.D11X5;
    class Program
    {
        static void Main(string[] args)
        {
            C1Stat stat = new C1Stat();
            stat.C1StatMain("shand11x5");
            Console.WriteLine("执行成功!");
            Console.Read();
        }
//
//        static void OmissionValueTest()
//        {
//            //OmissionValueBiz biz = new OmissionValueBiz("jiangx11x5");
//            //List<OmissionValue> omissionValues = biz.GetAll("11X5", "F2", "DaXiao",
//            //    string.Empty, "CurrentSpans", "DESC");
//        }
//
//        static void FormulaTest()
//        {
//            Console.WriteLine(FFG.GetDC(119, 1.0 / 10.0));
//            Console.WriteLine(Deviation.GetColdByDC(0.959, 1.0 / 10.0));
//            Console.WriteLine(Deviation.GetWatchColdN(0.959, 0.999, 1.0 / 110.0));
//        }
//
//        static void ExtractNumber()
//        {
//            //DataDownload.DownPage(147);
//            //DataDownload.DownPage(167);
//            ExtractData.Extract(147);
//            //ExtractData.Extract(167);
//        }
//
//        static void ExtractNumber(int categoryId)
//        {
//            DataDownload.DownPage(categoryId);
//            ExtractData.Extract(categoryId);
//        }
//
//        static void DownServiceTest()
//        {
//            try
//            {
//                Services.DownloadService s = new Services.DownloadService();
//                //s.StartAsync(DateTime.Now);
//                s.StartSync(DateTime.Now);
//            }
//            catch (Exception ex)
//            {
//                Logging.Logger.Instance.Write(ex.ToString());
//            }
//        }
//
//        static void DownloaderTest()
//        {
//            Category category = CategoryBiz.Instance.GetById(185);
//            PinbleDownloader downloader = new PinbleDownloader();
//            downloader.Down(new Data.Parameter.DownParameter(category));
//        }
//
//        static void ServiceTest()
//        {
//            Services.CategoryService service = new Services.CategoryService();
//            service.Start(DateTime.Now);
//        }
//
//        static void CacheTest()
//        {
//           string[] dims = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("SSC");
//        }
//
//        static void ETLTest()
//        {
//            //ETL.D11X5.ImportDmFCAn.Add("db");
//            //ETL.SSC.ImportDmFCAn.Add("db");
//            //ETL.SSC.ImportDwNumber.Start();
//            //ETL.Common.ImportDimension.Import();
//            //ETL.Common.ImportNumberType.Import();
//            //ETL.Common.ImportNumberTypeDim.Import();
//            //ETL.D11X5.ImportDmDPC.Add("db");
//            //ETL.D11X5.ImportDwNumber.UpdateC4();
//            //ETL.D11X5.ImportDwNumber.UpdateP(167, "2012090644", "05,07,01,09,10");
//            //ETL.SSC.ImportDwNumber.UpdateC45();
//            //ETL.SSC.ImportDmDPC.UpdateNumberType();
//            //ETL.D12X3.ImportDmDPC.Add("db");
//        }
//
//        static void InsertP()
//        {
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031632", "02 01 09 03 04", "2012-03-16 14:10:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031633", "11 01 04 03 06", "2012-03-16 14:20:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031634", "05 10 03 07 04", "2012-03-16 14:30:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031636", "02 04 01 08 07", "2012-03-16 14:50:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031637", "09 07 04 01 03", "2012-03-16 15:00:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12031638", "03 02 11 05 04", "2012-03-16 15:10:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12040453", "08 01 06 02 10", "2012-04-04 17:40:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12102372", "06 05 02 03 10", "2012-10-23 20:50:00");
//            ETL.D11X5.ImportDwNumber.Insert(167, "12102373", "09 04 06 11 07", "2012-10-23 21:00:00");
//        }
//
//        static void StatTest()
//        {
//            Statistics.IStat[] stats = new Statistics.IStat[] 
//            {
//                //new Statistics.D11X5.DmSpan(),
//                //new Statistics.SSC.DmSpan(),
//                //new Statistics.D3.DmSpan(),
//                //new Statistics.PL35.DmSpan(),
//                //new Statistics.SSL.DmSpan(),
//                //new Statistics.D12X3.DmSpan()
//            };
//
//            foreach (var stat in stats)
//            {
//                //stat.Stat(true);
//                stat.Stat(false);
//            }
//        }
//
//        static void OtherTest()
//        {
//            Combinations<int> c3 = new Combinations<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3);
//            List<string> c3s = c3.Get(",");
//
//        }
//
//        static void TransactionTest()
//        {
//            TransactionScopeTest.Test();
//        }
    }
}

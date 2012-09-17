using System;

namespace Lottery.Downloader
{
    public class DownloaderFactory
    {
        public static IDownloader Creator(string type)
        {
            if (type == null) 
                throw new ArgumentNullException("type");

            if (type.ToLower().Equals("11x5")) 
                return new D11X5Downloader();

            if (type.ToLower().Equals("ssc"))
                return new SSCDownloader();

            //if (type.ToLower().Equals("3d"))
            //    return new PL35Downloader();

            return null;
        }
    }
}


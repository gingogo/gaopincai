using System;

namespace Lottery.Data.Downloader
{
    public class DownloaderFactory
    {
        public static IDownloader Creator(string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");

            if (url.ToLower().Contains("pinble.com")) return new PinbleDownloader();
            if (url.ToLower().Contains("qq.com")) return new QQDownloader();
            if (url.ToLower().Contains("360.cn")) return new CP360Downloader();
            if (url.ToLower().Contains("lecai.com")) return new LeCaiDownloader();

            return null;
        }
    }
}


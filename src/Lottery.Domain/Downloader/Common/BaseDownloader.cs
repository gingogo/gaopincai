using System.Net;

namespace Lottery.Downloader
{
    public abstract class BaseDownloader
    {
        protected WebClient _webClient = new WebClient();

        protected BaseDownloader()
        {
        }
    }
}


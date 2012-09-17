namespace Lottery.Downloader
{
    using System;

    public interface IDownloader
    {
        bool Down(DownParameter param);
    }
}


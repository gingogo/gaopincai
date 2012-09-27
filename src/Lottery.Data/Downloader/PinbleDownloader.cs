using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lottery.Data.Downloader
{
    using Logging;
    using Parameter;
    using Utils;

    /// <summary>
    /// 体彩排列三与排列五彩种数据下载类。
    /// </summary>
    public class PinbleDownloader : BaseDownloader, IDownloader
    {
        private bool Down11X5(DownParameter param)
        {
            return false;
        }

        private bool DownSSC(DownParameter param)
        {
            return false;
        }

        private bool Down3D(DownParameter param)
        {
            return false;
        }

        private bool DownPL35(DownParameter param)
        {
            return false;
        }

        private bool DownSSL(DownParameter param)
        {
            return false;
        }
    }
}


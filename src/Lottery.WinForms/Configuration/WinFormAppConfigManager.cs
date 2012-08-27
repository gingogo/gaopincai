using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Configuration
{
    public class WinFormAppConfigManager
    {
        public static string NoticeSoundFileName
        {
            get { return ConfigHelper.GetAppSettings("noticeSoundFileName"); }
        }
    }
}

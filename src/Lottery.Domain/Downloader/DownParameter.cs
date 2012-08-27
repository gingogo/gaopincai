using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Downloader
{
    public class DownParameter
    {
        public DownParameter(DateTime currentDate,string name,string downUrl,string dbName)
        {
            this.CurrentDate = currentDate;
            this.Name = name;
            this.DownUrl = downUrl;
            this.DbName = dbName;
        }

        public DateTime CurrentDate { get; set; }

        public string Name { get; set; }

        public string DownUrl { get; set; }

        public string DownSource { get; set; }

        public string DbName { get; set; }
    }
}

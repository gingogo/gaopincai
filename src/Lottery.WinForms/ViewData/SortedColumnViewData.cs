using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.ViewData
{
    public class SortedColumnViewData
    {
        public SortedColumnViewData()
        {
        }

        public SortedColumnViewData(string key, string text, bool isDbSort)
        {
            this.Key = key;
            this.Text = text;
            this.IsDbSort = isDbSort;
        }

        public string Key { get; set; }

        public string Text { get; set; }

        public bool IsDbSort { get; set; }
    }
}

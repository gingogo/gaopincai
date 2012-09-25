using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.ViewData
{
    public class ColumnHeaderViewData
    {
        public ColumnHeaderViewData()
        {
        }

        public ColumnHeaderViewData(string key, string text, int width)
        {
            this.Key = key;
            this.Text = text;
            this.Width = width;
            this.IsDbSort = false;
        }

        public ColumnHeaderViewData(string key, string text, int width, bool isDbSort)
            : this(key, text, width)
        {
            this.IsDbSort = isDbSort;
        }

        public string Key { get; set; }

        public string Text { get; set; }

        public int Width { get; set; }

        public bool IsDbSort { get; set; }
    }
}

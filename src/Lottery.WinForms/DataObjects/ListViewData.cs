using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.DataObjects
{
    public class ListViewData
    {
        /// <summary>
        /// 表头说明信息
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 宽度信息
        /// </summary>
        public int[] width { get; set; }

        /// <summary>
        /// 标题数组
        /// </summary>
        public string[] title { get; set; }
        /// <summary>
        /// 值数组list，每行一个数组
        /// </summary>
        public List<string[]> values { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.DataObjects
{
    [Serializable]
    public class NumSpanData
    {
        /// <summary>
        /// 数字
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 流水期号
        /// </summary>
        public int seq { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        public string p { get; set; }
        /// <summary>
        /// 最近间隔
        /// </summary>
        public int SpanLast { get; set; }
        /// <summary>
        /// 最大间隔
        /// </summary>
        public int SpanMax { get; set; }
        /// <summary>
        /// 平均间隔
        /// </summary>
        public int SpanAvg { get; set; }
        /// <summary>
        /// 距现在期数
        /// </summary>
        public int SpanTillNow { get; set; }
        /// <summary>
        /// 最近周期
        /// </summary>
        public string SpanRec { get; set; }
        /// <summary>
        /// 出现总次数
        /// </summary>
        public int Times { get; set; }
        /// <summary>
        /// 1天前出现次数
        /// </summary>
        public int TimesDay1 { get; set; }
        /// <summary>
        /// 2天前出现次数
        /// </summary>
        public int TimesDay2 { get; set; }
        /// <summary>
        /// 3天前出现次数
        /// </summary>
        public int TimesDay3 { get; set; }
        /// <summary>
        /// 4天前出现次数
        /// </summary>
        public int TimesDay4 { get; set; }
        /// <summary>
        /// 5天前出现次数
        /// </summary>
        public int TimesDay5 { get; set; }
        /// <summary>
        /// 6天前出现次数
        /// </summary>
        public int TimesDay6 { get; set; }
        /// <summary>
        /// 7天前出现次数
        /// </summary>
        public int TimesDay7 { get; set; }
        /// <summary>
        /// 接下来的可能性
        /// </summary>
        public string NextAll { get; set; }
        /// <summary>
        /// 1天内即将出现的可能性
        /// </summary>
        public string Next { get; set; }
        /// <summary>
        /// 可能性的误差
        /// </summary>
        public int NextTest { get; set; }
        /// <summary>
        /// 热度 0温号 1热号  -1冷号
        /// </summary>
        public int HotType { get; set; }
        /// <summary>
        /// 热度 0正常 1变热中  -1变冷中
        /// </summary>
        public int HotTrend { get; set; }
        /// <summary>
        /// 最近热度
        /// </summary>
        public string HotRecent { get; set; }
    }
}

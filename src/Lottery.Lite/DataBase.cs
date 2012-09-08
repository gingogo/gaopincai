using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Lite
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
        /// 实际出现期数
        /// </summary>
        public string Next { get; set; }
        /// <summary>
        /// 可能性概率
        /// </summary>
        public string NextPercent { get; set; }
        /// <summary>
        /// 1天内即将出现的可能性
        /// </summary>
        public string NextAbility { get; set; }
        /// <summary>
        /// 实际出现与预测的误差
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


    public class MentionData
    {
        /// <summary>
        /// 号码
        /// </summary>
        public string num { get; set; }
        /// <summary>
        /// 期数
        /// </summary>
        public string n { get; set; }
        /// <summary>
        /// 彩种
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 玩法
        /// </summary>
        public string numtype { get; set; }

    }

    public class CaiConfigData
    {
        /// <summary>
        /// 彩种
        /// </summary>
        public string CaiType { get; set; }
        /// <summary>
        /// 每天的期数
        /// </summary>
        public int PeriodPerDay { get; set; }
        /// <summary>
        /// 每期的时间
        /// </summary>
        public int TimePerPeriod { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int TimeBeginHour { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public int TimeEndHour { get; set; }
        /// <summary>
        /// 统计开始时间，默认是当前时间
        /// </summary>
        public DateTime NowCaculate { get; set; }
        /// <summary>
        /// 号码类型，F2等
        /// </summary>
        public string NumType { get; set; }

        /// <summary>
        /// 计算的任务类型
        /// </summary>
        public string TaskType { get; set; }

        /// <summary>
        /// 是否从缓存加载
        /// </summary>
        public bool LoadFromCache { get; set; }

        /// <summary>
        /// 应用程序路径
        /// </summary>
        public string AppPath { get; set; }

        public string StatusLabel { get; set; }
    }




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

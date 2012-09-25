using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.Caching
{
    using ViewData;

    public class Cache
    {
        private static Dictionary<string, ColumnHeaderViewData> omissonValueColumnHeaders = new Dictionary<string, ColumnHeaderViewData>(25);

        static Cache()
        {
            LoadToCache();
        }

        private static void LoadToCache()
        {
            SetOmissonValueColumnHeaders();
        }

        private static void SetOmissonValueColumnHeaders()
        {
            omissonValueColumnHeaders.Add("NumberId", new ColumnHeaderViewData("NumberId", "号码", 70,true));
            omissonValueColumnHeaders.Add("CurrentSpans", new ColumnHeaderViewData("CurrentSpans", "本期遗漏", 60, true));
            omissonValueColumnHeaders.Add("LastSpans", new ColumnHeaderViewData("LastSpans", "上期遗漏", 60));
            omissonValueColumnHeaders.Add("MaxSpans", new ColumnHeaderViewData("MaxSpans", "最大遗漏", 60, true));
            omissonValueColumnHeaders.Add("AvgSpans", new ColumnHeaderViewData("AvgSpans", "平均遗漏", 80, true));
            omissonValueColumnHeaders.Add("CurrentDC", new ColumnHeaderViewData("CurrentDC", "当前确定度", 80));
            omissonValueColumnHeaders.Add("HistoryMaxDC", new ColumnHeaderViewData("HistoryMaxDC", "历史最大确定度", 100));
            omissonValueColumnHeaders.Add("AvgMaxDC", new ColumnHeaderViewData("AvgMaxDC", "平均最大确定度", 100));
            omissonValueColumnHeaders.Add("MaxDC", new ColumnHeaderViewData("MaxDC", "总体最大确定度", 100));
            omissonValueColumnHeaders.Add("WatchColdN", new ColumnHeaderViewData("WatchColdN", "守冷期数", 60));
            omissonValueColumnHeaders.Add("State", new ColumnHeaderViewData("State", "偏态值", 55));
            omissonValueColumnHeaders.Add("OccurRating", new ColumnHeaderViewData("OccurRating", "欲出几率", 70));
            omissonValueColumnHeaders.Add("InvestmentValue", new ColumnHeaderViewData("InvestmentValue", "投资价值", 70));
            omissonValueColumnHeaders.Add("ReturnRating", new ColumnHeaderViewData("ReturnRating", "回补几率", 70));
            omissonValueColumnHeaders.Add("PeroidCount", new ColumnHeaderViewData("PeroidCount", "总期数", 55, true));
            omissonValueColumnHeaders.Add("Cycle", new ColumnHeaderViewData("Cycle", "循环周期", 60));
            omissonValueColumnHeaders.Add("ActualTimes", new ColumnHeaderViewData("ActualTimes", "出现次数", 60, true));
            omissonValueColumnHeaders.Add("TheoryTimes", new ColumnHeaderViewData("TheoryTimes", "理论出现次数", 90));
            omissonValueColumnHeaders.Add("Frequency", new ColumnHeaderViewData("Frequency", "出现频率", 70));
            omissonValueColumnHeaders.Add("Nums", new ColumnHeaderViewData("Nums", "注数", 50));
            omissonValueColumnHeaders.Add("Probability", new ColumnHeaderViewData("Probability", "概率", 65));
            omissonValueColumnHeaders.Add("Prize", new ColumnHeaderViewData("Prize", "奖金", 70));
            omissonValueColumnHeaders.Add("Amount", new ColumnHeaderViewData("Amount", "投注金额", 70));
        }

        public static Dictionary<string, ColumnHeaderViewData> OmissonValueColumnHeaders
        {
            get { return omissonValueColumnHeaders; }
        }
    }
}

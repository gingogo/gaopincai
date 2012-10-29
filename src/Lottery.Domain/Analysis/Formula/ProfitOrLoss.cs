using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    using Model.Analysis;

    /// <summary>
    /// 投资损益相关公式。
    /// </summary>
    public class ProfitOrLoss
    {
        /// <summary>
        /// 获取某一玩法的赔率(奖金/投注金额)。
        /// </summary>
        /// <param name="prize">奖金</param>
        /// <param name="amount">投注金额</param>
        /// <returns>赔率</returns>
        public static double GetOdds(double prize, double amount)
        {
            return prize / amount;
        }

        /// <summary>
        /// 获取某一玩法的赢率(赔率 * 玩法概率)
        /// </summary>
        /// <param name="prize">奖金</param>
        /// <param name="amount">投注金额</param>
        /// <param name="p">玩法概率</param>
        /// <returns>赢率</returns>
        public static double GetWins(double prize, double amount, double p)
        {
            double odds = GetOdds(prize, amount);
            return GetWins(odds, p);
        }

        /// <summary>
        /// 获取某一玩法的赢率(赔率 * 玩法概率)
        /// </summary>
        /// <param name="odds">赔率</param>
        /// <param name="amount">投注金额</param>
        /// <param name="p">玩法概率</param>
        /// <returns>赢率</returns>
        public static double GetWins(double odds, double p)
        {
            return odds * p;
        }

        /// <summary>
        /// 获取某一玩法的理论收益率.
        /// 输率 = 1-玩法概率.
        /// 收益率 = 赢率-输率 = 赔率*玩法概率-1+玩法概率 =（赔率+1）*玩法概率-1.
        /// </summary>
        /// <param name="odds">赔率</param>
        /// <param name="amount">投注金额</param>
        /// <param name="p">玩法概率</param>
        /// <returns>理论收益率</returns>
        public static double GetGains(double prize, double amount, double p)
        {
            double odds = GetOdds(prize, amount);
            return GetGains(odds, p);
        }

        /// <summary>
        /// 获取某一玩法的理论收益率(收益率为正才能赚钱,为负必亏).
        /// 输率 = 1-玩法概率.
        /// 收益率 = 赢率-输率 = 赔率*玩法概率-1+玩法概率 =（赔率+1）*玩法概率-1.
        /// </summary>
        /// <param name="odds">赔率</param>
        /// <param name="p">玩法概率</param>
        /// <returns>理论收益率</returns>
        public static double GetGains(double odds, double p)
        {
            return (odds + 1) * p - 1;
        }

        /// <summary>
        /// 获取倍投收益率。
        /// </summary>
        /// <param name="parameter">倍投参数</param>
        /// <returns>倍投收益率集合</returns>
        public static List<ProfitRate> GetMultiProfitRates(MultiParameter parameter)
        {
            List<ProfitRate> profitRates = new List<ProfitRate>(parameter.PeroidNums);
            for (int i = 1; i <= parameter.PeroidNums; i++)
            {
                double profitRating = GetProfitRating(parameter, i);
                double lastTotalAmount = (i == 1) ? 0 : profitRates[i - 2].CurrentTotalAmount;
                int lastMultiNums = (i == 1) ? parameter.StartMultiNums : profitRates[i - 2].MultiNums;
                int currentMultiNums = GetMultiNums(parameter, lastMultiNums, lastTotalAmount, profitRating);
                if (currentMultiNums == -1) break;

                ProfitRate profitRate = new ProfitRate(i, parameter.Nums, currentMultiNums, parameter.Prize, lastTotalAmount);
                profitRates.Add(profitRate);
            }

            return profitRates;
        }

        private static double GetProfitRating(MultiParameter parameter, int peroidNum)
        {
            if (parameter.IsGlobal) return parameter.GlobalRating;
            return peroidNum <= parameter.PrevPeroidNums ? parameter.PrevPeroidRating : parameter.RestPeroidRating;
        }

        private static int GetMultiNums(MultiParameter parameter, int lastMultiNums, double lastTotalAmount, double profitRating)
        {
            int multiNums = lastMultiNums;
            double totalAmount = lastTotalAmount + parameter.Nums * multiNums * 2;
            double totalProfit = parameter.Prize * multiNums - totalAmount;

            while (totalProfit / totalAmount < profitRating || totalProfit < parameter.MinProfitAmount)
            {
                if (multiNums > parameter.MaxMultiNums) return -1;
                multiNums++;
                totalAmount = lastTotalAmount + parameter.Nums * multiNums * 2;
                totalProfit = parameter.Prize * multiNums - totalAmount;
            }

            return multiNums;
        }
    }
}

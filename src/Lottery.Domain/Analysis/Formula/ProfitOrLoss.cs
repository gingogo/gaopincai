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
                double lastTotalAmount = (i > 1) ? profitRates[i - 2].TotalAmount : 0.0;
                int currentMultiNums = (i > 1) ? profitRates[i - 2].MultiNums : parameter.StartMultiNums;
                double profitRating = GetProfitRating(parameter, i);

                ProfitRate profitRate = new ProfitRate();
                profitRate.PeroidNum = i;
                profitRate.MultiNums = GetMultiNums(parameter, currentMultiNums, lastTotalAmount, profitRating);
                profitRate.CurrentAmount = parameter.Nums * profitRate.MultiNums * 2;
                profitRate.TotalAmount = lastTotalAmount + profitRate.CurrentAmount;
                profitRate.CurrentProfit = profitRate.MultiNums * parameter.Prize;
                profitRates.Add(profitRate);
            }

            return profitRates;
        }

        private static double GetProfitRating(MultiParameter parameter, int peroidNum)
        {
            if (parameter.IsGlobal) return parameter.GlobalRating;
            return peroidNum <= parameter.PrevPeroidNums ? parameter.PrevPeroidRating : parameter.RestPeroidRating;
        }

        private static int GetMultiNums(MultiParameter parameter, int currentMultiNums, double lastTotalAmount, double profitRating)
        {
            double totalAmount = lastTotalAmount + (parameter.Nums * currentMultiNums * 2);
            double totalPrize = parameter.Prize * currentMultiNums;
            double totalProfit = totalPrize - totalAmount;
            double currentProfitRating = totalProfit / totalAmount;

            while (currentProfitRating < profitRating)
            {
                if (currentMultiNums > parameter.MaxMultiNums) break;
                currentMultiNums++;
                totalAmount = lastTotalAmount + (parameter.Nums * currentMultiNums * 2);
                totalPrize = parameter.Prize * currentMultiNums;
                totalProfit = totalPrize - totalAmount;
                currentProfitRating = totalProfit / totalAmount;
            }

            return currentMultiNums;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    /// <summary>
    /// 投资损益相关公式。
    /// </summary>
    public class ProfitOrLoss
    {
        /// <summary>
        /// 获取某一玩法的赔率(奖金/投注金额)。
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="amount">投注金额</param>
        /// <returns>赔率</returns>
        public static double GetOdds(double bonus, double amount)
        {
            return bonus / amount;
        }

        /// <summary>
        /// 获取某一玩法的赢率(赔率 * 玩法概率)
        /// </summary>
        /// <param name="bonus">奖金</param>
        /// <param name="amount">投注金额</param>
        /// <param name="p">玩法概率</param>
        /// <returns>赢率</returns>
        public static double GetWins(double bonus, double amount, double p)
        {
            double odds = GetOdds(bonus, amount);
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
        public static double GetGains(double bonus, double amount, double p)
        {
            double odds = GetOdds(bonus, amount);
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
    }
}

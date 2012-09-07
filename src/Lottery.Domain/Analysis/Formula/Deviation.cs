using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    /// <summary>
    /// 偏差计算公式
    /// </summary>
    public class Deviation
    {
        /// <summary>
        /// 冷偏差
        /// </summary>
        /// <param name="n">遗漏期数 </param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns>冷偏差</returns>
        public static double GetCold(int n, double p)
        {
            return n * p * 100;
        }

        /// <summary>
        /// 热偏差
        /// </summary>
        /// <param name="n">遗漏期数</param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns>热偏差</returns>
        public static double GetThermal(int n, double p)
        {
            return 100 / (n * p);
        }
    }
}

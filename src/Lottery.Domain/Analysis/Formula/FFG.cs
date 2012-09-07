using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    /// <summary>
    /// 博彩基本公式
    /// </summary>
    public class FFG
    {
        /// <summary>
        /// 根据确定程序及中奖概率获取预计期数。
        /// </summary>
        /// <param name="dc">确定程度</param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns></returns>
        public static double GetN(double dc, double p)
        {
            return Math.Log(1 - dc, Math.E) / Math.Log(1 - p, Math.E);
        }

        /// <summary>
        /// 根据期数及中奖概率获取中奖确定程度。
        /// </summary>
        /// <param name="n">期数</param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns></returns>
        public static double GetDC(int n, double p)
        {
            return (1 - Math.Exp(n * Math.Log(1 - p, Math.E)));
        }
    }
}

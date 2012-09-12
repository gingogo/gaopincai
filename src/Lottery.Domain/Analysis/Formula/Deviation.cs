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
        /// 获取当前遗漏值的偏差值。
        /// </summary>
        /// <param name="n">遗漏期数</param>
        /// <param name="avgN">平均遗漏期数</param>
        /// <param name="p">玩法概率</param>
        /// <returns>当前遗漏值的偏差值</returns>
        public static double GetN(double n,double avgN, double p)
        {
            if (n > avgN)
                return GetColdByN(n, p);
            return GetThermal(n, p);
        }

        /// <summary>
        /// 冷偏差
        /// </summary>
        /// <param name="n">遗漏期数 </param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns>冷偏差</returns>
        public static double GetColdByDC(double dc, double p)
        {
            double n = FFG.GetN(dc, p);
            return GetColdByN(n, p);
        }

        /// <summary>
        /// 冷偏差
        /// </summary>
        /// <param name="n">遗漏期数 </param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns>冷偏差</returns>
        public static double GetColdByN(double n, double p)
        {
            return n * p * 100;
        }

        /// <summary>
        /// 获取守冷期数。
        /// </summary>
        /// <param name="startDC">起始期数确定程度</param>
        /// <param name="endDC">止损期数确定程度</param>
        /// <param name="p">玩法概率</param>
        /// <returns>守冷期数</returns>
        public static double GetWatchColdN(double startDC, double endDC, double p)
        {
            double startN = FFG.GetN(startDC, p);
            double endN = FFG.GetN(endDC, p);
            return Math.Round(endN - startN, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 热偏差
        /// </summary>
        /// <param name="n">遗漏期数</param>
        /// <param name="p">某一种玩法的中奖概率</param>
        /// <returns>热偏差</returns>
        public static double GetThermal(double n, double p)
        {
            return 100 / (n * p);
        }
    }
}

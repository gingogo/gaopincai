using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    /// <summary>
    /// 
    /// </summary>
    public class Deviation
    {
        /// <summary>
        /// 冷偏差
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GetCold(int n, double p)
        {
            return n * p * 100;
        }

        /// <summary>
        /// 热偏差
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GetThermal(int n, double p)
        {
            return 100 / (n * p);
        }
    }
}

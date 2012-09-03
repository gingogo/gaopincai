﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    public class FFG
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GetN(double dc, double p)
        {
            return Math.Log(1 - dc, Math.E) / Math.Log(1 - p, Math.E);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double GetDC(int n, double p)
        {
            return (1 - Math.Exp(n * Math.Log(1 - p, Math.E)));
        }
    }
}

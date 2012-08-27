using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Formula
{
    public class FFG
    {
        public static double GetN(double dc, double p)
        {
            return Math.Log(1 - dc, Math.E) / Math.Log(1 - p, Math.E);
        }

        public static double GetDC(int n, double p)
        {
            return (1 - Math.Exp(n * Math.Log(1 - p, Math.E)));
        }
    }
}

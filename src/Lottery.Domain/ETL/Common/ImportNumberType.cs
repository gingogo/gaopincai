using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data.SQLServer.Common;
    using Utils;

    public class ImportNumberType
    {
        public static void Import()
        {
            Import11x5();
            ImportSSC();
        }

        private static void Import11x5()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|前一", 1.0 / 11.0);
            dict.Add("F2|前二直选", 1.0 / 110.0);
            dict.Add("C2|前二组选", 1.0 / 55.0);
            dict.Add("F3|前三直选", 1.0 / 990.0);
            dict.Add("C3|前三组选", 1.0 / 165.0);
            dict.Add("A5|任五", 1.0 / 462.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "11X5";
                nt.Probability = kp.Value;
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportSSC()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星", 1.0 / 10.0);
            dict.Add("P2|二星直选", 1.0 / 100.0);
            dict.Add("C2|二星组选", 1.0 / 55.0);
            dict.Add("P3|三星直选", 1.0 / 1000.0);
            dict.Add("C33|三星组三", 1.0 / 220.0);
            dict.Add("C36|三星组六", 1.0 / 220.0);
            dict.Add("P4|四星", 1.0 / 10000.0);
            dict.Add("P5|五星", 1.0 / 100000.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "SSC";
                nt.Probability = kp.Value;
                NumberTypeBiz.Instance.Add(nt);
            }
        }
    }
}

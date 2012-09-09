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
            ImportChongQSSC();
        }

        private static void Import11x5()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|前一|13", 1.0 / 11.0);
            dict.Add("F2|前二直选|130", 1.0 / 110.0);
            dict.Add("C2|前二组选|65", 1.0 / 55.0);
            dict.Add("F3|前三直选|1170", 1.0 / 990.0);
            dict.Add("C3|前三组选|195", 1.0 / 165.0);
            dict.Add("A5|任五|540", 1.0 / 462.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "11X5";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportSSC()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星|11", 1.0 / 10.0);
            dict.Add("P2|二星直选|116", 1.0 / 100.0);
            dict.Add("C2|二星组选|58", 1.0 / 55.0);
            dict.Add("P3|三星直选|1160", 1.0 / 1000.0);
            dict.Add("C33|三星组三|385", 1.0 / 220.0);
            dict.Add("C36|三星组六|190", 1.0 / 220.0);
            dict.Add("P4|四星|10000", 1.0 / 10000.0);
            dict.Add("P5|五星|116000", 1.0 / 100000.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "SSC";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportChongQSSC()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星|10", 1.0 / 10.0);
            dict.Add("P2|二星直选|100", 1.0 / 100.0);
            dict.Add("C2|二星组选|50", 1.0 / 55.0);
            dict.Add("P3|三星直选|1000", 1.0 / 1000.0);
            dict.Add("C33|三星组三|320", 1.0 / 220.0);
            dict.Add("C36|三星组六|160", 1.0 / 220.0);
            dict.Add("P4|四星|10000", 1.0 / 10000.0);
            dict.Add("P5|五星|100000", 1.0 / 100000.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "ChongQSSC";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }
    }
}

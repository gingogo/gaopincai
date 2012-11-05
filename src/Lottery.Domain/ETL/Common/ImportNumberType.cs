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
            //NumberTypeBiz.Instance.DataAccessor.Truncate();

            Import11x5();
            //ImportJiangXSSC();
            //ImportChongQSSC();
            //Import3D();
            //ImportPL35();
            //ImportSSL();
            //Import12X3();
        }

        private static void Import11x5()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|前一|13", 1.0 / 11.0);
            dict.Add("D2|二位|0", 1.0 / 11.0);
            dict.Add("D3|三位|0", 1.0 / 11.0);
            dict.Add("D4|四位|0", 1.0 / 11.0);
            dict.Add("D5|五位|0", 1.0 / 11.0);
            dict.Add("P2|前二直选|130", 1.0 / 110.0);
            dict.Add("C2|前二组选|65", 1.0 / 55.0);
            dict.Add("P3|前三直选|1170", 1.0 / 990.0);
            dict.Add("C3|前三组选|195", 1.0 / 165.0);
            dict.Add("C5|任五|540", 1.0 / 462.0);
            //dict.Add("A2|任二|6", 1.0 / 5.5);
            //dict.Add("A3|任三|19", 1.0 / 16.5);
            //dict.Add("A4|任四|78", 1.0 / 66.0);
            //dict.Add("A6|任六|90", 1.0 / 77.0);
            //dict.Add("A7|任七|26", 1.0 / 22.0);
            //dict.Add("A8|任八|9", 1.0 / 8.25);

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
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportJiangXSSC()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星|11", 1.0 / 10.0);
            dict.Add("D2|二位|11", 1.0 / 10.0);
            dict.Add("D3|三位|11", 1.0 / 10.0);
            dict.Add("D4|四位|11", 1.0 / 10.0);
            dict.Add("D5|五位|11", 1.0 / 10.0);
            dict.Add("P2|二星直选|116", 1.0 / 100.0);
            dict.Add("C2|二星组选|58", 1.0 / 50.0);
            dict.Add("P3|三星直选|1160", 1.0 / 1000.0);
            dict.Add("C33|三星组三|385", (3.0 / 1000.0));
            dict.Add("C36|三星组六|190", (6.0 / 1000.0));
            dict.Add("P4|四星|10000", 1.0 / 10000.0);
            dict.Add("P5|五星|116000", 1.0 / 100000.0);
            dict.Add("C44|四星组选4|2900", 4.0 / 10000.0);
            dict.Add("C46|四星组选6|1930", 6.0 / 10000.0);
            dict.Add("C412|四星组选12|965", 12.0 / 10000.0);
            dict.Add("C424|四星组选24|480", 24.0 / 10000.0);
            dict.Add("C55|五星组选5|23200", 5.0 / 100000.0);
            dict.Add("C510|五星组选10|11600", 10.0 / 100000.0);
            dict.Add("C520|五星组选20|5800", 20.0 / 100000.0);
            dict.Add("C530|五星组选30|3860", 30.0 / 100000.0);
            dict.Add("C560|五星组选60|1930", 60.0 / 100000.0);
            dict.Add("C5120|五星组选120|960", 120.0 / 100000.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "JiangXSSC";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportChongQSSC()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星|10", 1.0 / 10.0);
            dict.Add("D2|二位|10", 1.0 / 10.0);
            dict.Add("D3|三位|10", 1.0 / 10.0);
            dict.Add("D4|四位|10", 1.0 / 10.0);
            dict.Add("D5|五位|10", 1.0 / 10.0);
            dict.Add("P2|二星直选|100", 1.0 / 100.0);
            dict.Add("C2|二星组选|50", 1.0 / 50.0);
            dict.Add("P3|三星直选|1000", 1.0 / 1000.0);
            dict.Add("C33|三星组三|320", (3.0 / 1000.0));
            dict.Add("C36|三星组六|160", (6.0 / 1000.0));
            dict.Add("P4|四星|10000", 1.0 / 10000.0);
            dict.Add("P5|五星|100000", 1.0 / 100000.0);
            dict.Add("C44|四星组选4|0", 4.0 / 10000.0);
            dict.Add("C46|四星组选6|0", 6.0 / 10000.0);
            dict.Add("C412|四星组选12|0", 12.0 / 10000.0);
            dict.Add("C424|四星组选24|0", 24.0 / 10000.0);
            dict.Add("C55|五星组选5|0", 5.0 / 100000.0);
            dict.Add("C510|五星组选10|0", 10.0 / 100000.0);
            dict.Add("C520|五星组选20|0", 20.0 / 100000.0);
            dict.Add("C530|五星组选30|0", 30.0 / 100000.0);
            dict.Add("C560|五星组选60|0", 60.0 / 100000.0);
            dict.Add("C5120|五星组选120|0", 120.0 / 100000.0);

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
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void Import3D()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一位|0", 1.0 / 10.0);
            dict.Add("D2|二位|0", 1.0 / 10.0);
            dict.Add("D3|三位|0", 1.0 / 10.0);
            dict.Add("P2|前二直选|0", 1.0 / 100.0);
            dict.Add("C2|前二组选|0", 1.0 / 50.0);
            dict.Add("P3|前三直选|1000", 1.0 / 1000.0);
            dict.Add("C33|前三组三|320", (3.0 / 1000.0));
            dict.Add("C36|前三组六|160", (6.0 / 1000.0));

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "3D";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportPL35()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|一星|0", 1.0 / 10.0);
            dict.Add("D2|二位|0", 1.0 / 10.0);
            dict.Add("D3|三位|0", 1.0 / 10.0);
            dict.Add("D4|四位|0", 1.0 / 10.0);
            dict.Add("D5|五位|0", 1.0 / 10.0);
            dict.Add("P2|前二直选|0", 1.0 / 100.0);
            dict.Add("C2|前二组选|0", 1.0 / 50.0);
            dict.Add("P3|前三直选|1000", 1.0 / 1000.0);
            dict.Add("C33|前三组三|320", (3.0 / 1000.0));
            dict.Add("C36|前三组六|160", (6.0 / 1000.0));
            dict.Add("P4|前四直选|0", 1.0 / 10000.0);
            dict.Add("P5|前五直选|100000", 1.0 / 100000.0);
            dict.Add("C44|前四组选4|0", 4.0 / 10000.0);
            dict.Add("C46|前四组选6|0", 6.0 / 10000.0);
            dict.Add("C412|前四组选12|0", 12.0 / 10000.0);
            dict.Add("C424|前四组选24|0", 24.0 / 10000.0);
            dict.Add("C55|前五组选5|0", 5.0 / 100000.0);
            dict.Add("C510|前五组选10|0", 10.0 / 100000.0);
            dict.Add("C520|前五组选20|0", 20.0 / 100000.0);
            dict.Add("C530|前五组选30|0", 30.0 / 100000.0);
            dict.Add("C560|前五组选60|0", 60.0 / 100000.0);
            dict.Add("C5120|前五组选120|0", 120.0 / 100000.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "PL35";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void ImportSSL()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|前一|10", 1.0 / 10.0);
            dict.Add("D2|二位|0", 1.0 / 10.0);
            dict.Add("D3|后一|10", 1.0 / 10.0);
            dict.Add("P2|前二直选|98", 1.0 / 100.0);
            dict.Add("C2|前二组选|0", 1.0 / 50.0);
            dict.Add("P3|直选三|980", 1.0 / 1000.0);
            dict.Add("C33|组选三|320", (3.0 / 1000.0));
            dict.Add("C36|组选六|160", (6.0 / 1000.0));

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "SSL";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static void Import12X3()
        {
            Dictionary<string, double> dict = new Dictionary<string, double>(11);
            dict.Add("D1|前一|110", 1.0 / 12.0);
            dict.Add("D2|二位|0", 1.0 / 12.0);
            dict.Add("D3|三位|0", 1.0 / 12.0);
            dict.Add("P2|前二直选|5000", 1.0 / 132.0);
            dict.Add("C2|前二组选|3344", 1.0 / 66.0);
            dict.Add("P3|前三直选|50000", 1.0 / 1320.0);
            dict.Add("C3|前三组选|27774", 1.0 / 220.0);
            dict.Add("G2|过二关|10000", 1.0 / 144.0);
            dict.Add("G3|过三关|500000", 1.0 / 1728.0);
            dict.Add("Z2|过二关组选|0", 2.0 / 144.0);
            dict.Add("Z33|过三关组选三|0", 3.0 / 1728.0);
            dict.Add("Z36|过三关组选六|0", 6.0 / 1728.0);

            foreach (var kp in dict)
            {
                string[] arr = kp.Key.Split('|');
                NumberType nt = new NumberType();
                nt.Name = arr[1];
                nt.Code = arr[0];
                nt.RuleType = "12X3";
                nt.Probability = kp.Value;
                nt.Amount = 2.0;
                nt.Prize = double.Parse(arr[2]);
                nt.Length = GetLength(arr[0]);
                NumberTypeBiz.Instance.Add(nt);
            }
        }

        private static int GetLength(string str)
        {
            if (str[0] == 'D') return 1;
            return int.Parse(str.Substring(1, 1));
        }
    }
}

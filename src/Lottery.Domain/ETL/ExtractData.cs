using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL
{
    using Model.Common;
    using Lottery.Data.SQLServer.Common;
    using Logging;

    public class ExtractData
    {
        private static Dictionary<int, int> pdic = new Dictionary<int, int>(1000);
        private static HashSet<long> pset = new HashSet<long>();

        public static void Extract()
        {
            string dataFilePath =  @"G:\LotteryData";
            if(!Directory.Exists(dataFilePath))
                Directory.CreateDirectory(dataFilePath);

            List<DmCategory> categories = DmCategoryBiz.Instance.GetEnabledCategories("ssc");
            foreach (DmCategory category in categories)
            {
                pset.Clear();
                string filePath = Path.Combine(@"G:\Lottery", category.Name);
                string dataFileName = string.Format(@"{0}\{1}.txt", dataFilePath, category.Name);
                StreamWriter sw = new StreamWriter(dataFileName, false, Encoding.UTF8);
                for (int i = category.DownPageIndex; i > 0; i--)
                {
                    string fileName = string.Format(@"{0}\{1}.html", filePath, i);
                    if (!File.Exists(fileName))
                        Logger.Instance.Write(string.Format("{0}-{1}.html-not exist", category.Name, i));
                    StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
                    string text = sr.ReadToEnd();
                    sr.Close();
                    Extract(text, sw, category.Name, ExtractSSC);
                }
                sw.Close();
            }

            Console.WriteLine("Finished!");
        }

        private static void Extract(string text, StreamWriter writer,string name,Action<StreamWriter,string,string,string,string> action)
        {
            //text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
            text = text.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">");
            string pattern = "<tr style='background-color: White; border-color: #B6CBE8;'>.*?</tr>";
            MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                Match m = matches[i];
                string sdate = Regex.Match(m.Value, "<td align='center' style='width: 20%;'>(.*?)</td>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string speroid = Regex.Match(m.Value, "<td style='width: 20%;'>(.*?)</td>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string code = Regex.Match(m.Value, "'MyGridView_ctl02_lblHao'>(\\d+)</(spans|span)>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                if (code.Trim().Length == 0) continue;

                action(writer, name, sdate, speroid, code);
            }
        }

        private static void ExtractSSC(StreamWriter writer, string name, string sdate, string speroid, string code)
        {
            char[] numbers = code.ToArray();
            string no = string.Join(",", numbers);
            string p2 = code.Substring(3);
            string p3 = code.Substring(2);
            string p4 = code.Substring(1);
            string p5 = code;

            DateTime datetime = DateTime.Parse(sdate);
            int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
            long p = 20000000000 + int.Parse(speroid);
            int n = int.Parse(speroid.Substring(speroid.Length - 3));

            if (pset.Contains(p)) return;

            pset.Add(p);
            string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                p, no, p2, p3, p4, p5, n, dateint, datetime);
            writer.WriteLine(line);
        }

        private static void Extract11X5(StreamWriter writer, string name, string sdate, string speroid, string code)
        {
            string no = code.Replace(" ", ",");
            string f5 = code.Replace(" ", "");
            string f2 = f5.Substring(0, 4);
            string f3 = f5.Substring(0, 6);

            DateTime datetime = DateTime.Parse(sdate);
            int dateint = int.Parse(datetime.ToString("yyyyMMdd"));

            int p = 2000000000 + int.Parse(speroid);
            int n = int.Parse(speroid.Substring(speroid.Length - 2));
            if (name.Equals("山东十一运夺金") &&
                dateint < 20090909)
            {
                if (pdic.ContainsKey(dateint))
                    pdic[dateint]++;
                else
                    pdic.Add(dateint, 1);
                n = pdic[dateint];
                p = dateint * 100 + n;
            }

            string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                no, f2, f3, f5, p, n, dateint, datetime);
            writer.WriteLine(line);
        }
    }
}

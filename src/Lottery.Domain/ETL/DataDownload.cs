using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Lottery.ETL
{
    using Logging;

    public class DataDownload
    {
        public static void Down()
        {
            string url1 = "http://www.pinble.com/Template/WebService1.asmx/lotteryNameData?lotteryName={0}";
            string url2 = "http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&type={3}&isgp={4}";
            string fileName = @"G:\lottery.html";
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            string text = sr.ReadToEnd();
            sr.Close();

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            StreamWriter sw = new StreamWriter(@"g:\categories.txt", false, Encoding.UTF8);
            MatchCollection matches = Regex.Matches(text, "ListClick\\('(.*?)','(.*?)'\\)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            foreach (Match m in matches)
            {
                int pageIndex = 1;
                string name = m.Groups[1].Value;
                string isgp = m.Groups[2].Value;
                string pl3 = name.ToLower().Equals("pl3") ? "pl3" : "";

                try
                {
                    //pageindex:'1',lottory:'FC3DData',pl3:'',type:'3D',isgp: '0'} 
                    string lotteryNameText = wc.DownloadString(string.Format(url1, name));
                    string lotteryName = Regex.Replace(lotteryNameText, "<.*?>|[\\r\\n]", "", RegexOptions.IgnoreCase | RegexOptions.Singleline).Trim();

                    string page1Text = wc.DownloadString(string.Format(url2, pageIndex, lotteryName, pl3, name, isgp));
                    string count = Regex.Match(page1Text, "共\\：(\\d+)条", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
                    string pageCount = Regex.Match(page1Text, "分页\\:1/(\\d+)页", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;

                    sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", name, isgp, lotteryName, pageCount, count, pl3));
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(name);
                }
            }
            sw.Close();
            Console.WriteLine("Finished!");
        }

        public static void DownPage()
        {
            List<String[]> list = new List<string[]>(96);
            StreamReader sr = new StreamReader(@"G:\LotteryData\categories.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                list.Add(line.Split(','));
            }
            sr.Close();

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string url2 = "http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&name={3}&isgp={4}";
            string filePath = @"G:\Lottery";

            for (int j = 1; j < 2; j++)
            {
                string[] arr = list[j];
                int pageCount = int.Parse(arr[3]);
                string lotteryName = arr[2];
                string name = arr[0];
                string isgp = arr[1];

                string dir = Path.Combine(filePath, name);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                for (int i = 1; i <= pageCount; i++)
                {
                    string url = string.Format(url2, i, lotteryName, "", name, isgp);
                    string fileName = string.Format("{0}\\{1}.html", dir, i);
                    try
                    {
                        string htmlText = wc.DownloadString(url);
                        wc.DownloadFile(url, fileName);
                    }
                    catch
                    {
                        //Logger.Instance.Write(ex.ToString());
                        Logger.Instance.Write(url);
                    }
                }
            }
            Console.WriteLine("Finished!");
        }
    }
}

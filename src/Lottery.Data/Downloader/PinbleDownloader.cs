using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lottery.Data.Downloader
{
    using Logging;
    using Parameter;
    using Utils;

    /// <summary>
    /// 抓取www.pinble.com网站的彩票数据类。
    /// </summary>
    public class PinbleDownloader : BaseDownloader, IDownloader
    {
        public PinbleDownloader()
        {
            this._webClient.Encoding = Encoding.UTF8;
        }

        protected override bool Down11X5(DownParameter param)
        {
            SQLServer.D11X5.DwNumberBiz biz = new SQLServer.D11X5.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                string code = numberInfo.Number.Replace(" ", ",");
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                int p = 2000000000 + int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 2));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        protected override bool DownSSC(DownParameter param)
        {
            SQLServer.SSC.DwNumberBiz biz = new SQLServer.SSC.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                char[] digits = numberInfo.Number.ToArray();
                string code = string.Join(",", digits);
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                long p = 20000000000 + int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 3));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        protected override bool Down3D(DownParameter param)
        {
            SQLServer.D3.DwNumberBiz biz = new SQLServer.D3.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                char[] digits = numberInfo.Number.ToArray();
                string code = string.Join(",", digits);
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                long p = int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 3));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        protected override bool DownPL35(DownParameter param)
        {
            SQLServer.PL35.DwNumberBiz biz = new SQLServer.PL35.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                char[] digits = numberInfo.Number.ToArray();
                string code = string.Join(",", digits);
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                long p = int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 3));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        protected override bool DownSSL(DownParameter param)
        {
            SQLServer.SSL.DwNumberBiz biz = new SQLServer.SSL.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                char[] digits = numberInfo.Number.ToArray();
                string code = string.Join(",", digits);
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                long p = int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 2));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        protected override bool Down12X3(DownParameter param)
        {
            SQLServer.D12X3.DwNumberBiz biz = new SQLServer.D12X3.DwNumberBiz(param.Category.DbName);
            DateTime lastDate = biz.GetLatestDate();

            int endIndex = this.GetEndIndex(param, lastDate);
            if (endIndex <= 0) return false;
            var numbers = this.GetNumbers(param, endIndex);
            if (numbers.Count == 0) return false;

            long lastP = biz.GetLatestPeroid();
            foreach (var numberInfo in numbers)
            {
                string code = numberInfo.Number.Replace(" ", ",");
                DateTime datetime = DateTime.Parse(numberInfo.DateTime);
                int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
                int p = 2000000000 + int.Parse(numberInfo.Peroid);
                int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 2));

                if (p <= lastP) continue;
                if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
                return false;
            }
            return true;
        }

        private List<NumberInfo> GetNumbers(DownParameter param,int endIndex)
        {
            string url = string.Empty;
            List<NumberInfo> numbers = new List<NumberInfo>(endIndex * 40);

            for (int i = endIndex; i >= 1; i--)
            {
                try
                {
                    url = string.Format(param.Category.DownUrl, i, param.Category.Code, "", param.Category.Name, param.Category.IsGP);
                    string pageText = this._webClient.DownloadString(url);
                    var pageNumbers = this.ExtractNumbers(pageText);
                    if (pageNumbers.Count == 0) 
                    {
                        Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
                        break;
                    }
                    numbers.AddRange(pageNumbers);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(string.Format("url:{0},message:{1}", url, ex));
                    break;
                }
            }

            return numbers;
        }

        private List<NumberInfo> ExtractNumbers(string pageText)
        {
            List<NumberInfo> numbers = new List<NumberInfo>(40);
            //text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
            pageText = pageText.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">");
            string pattern = "<tr style='background-color: White; border-color: #B6CBE8;'>.*?</tr>";
            MatchCollection matches = Regex.Matches(pageText, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            for (int i = matches.Count - 1; i >= 0; i--)
            {
                Match m = matches[i];
                string sdate = Regex.Match(m.Value, "<td align='center' style='width: 20%;'>(.*?)</td>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string speroid = Regex.Match(m.Value, "<td style='width: 20%;'>(.*?)</td>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string code = Regex.Match(m.Value, "'MyGridView_ctl02_lblHao'>(.*?)</(spans|span)>",
                    RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();

                if (code.Trim().Length == 0) continue;
                numbers.Add(new NumberInfo(code, speroid, sdate));
            }

            return numbers;
        }

        private int GetEndIndex(DownParameter param,DateTime lastDate)
        {
            int endIndex = 0;
            DateTime currentDate = lastDate;

            try
            {
                //http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&name={3}&isgp={4}
                string url = string.Format(param.Category.DownUrl, 1, param.Category.Code, "", param.Category.Name, param.Category.IsGP);
                string pageText = this._webClient.DownloadString(url);
                pageText = pageText.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">");
                string pattern = "<tr style='background-color: White; border-color: #B6CBE8;'>.*?</tr>";
                MatchCollection matches = Regex.Matches(pageText, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                foreach (Match m in matches)
                {
                    string sdate = Regex.Match(m.Value, "<td align='center' style='width: 20%;'>(.*?)</td>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string code = Regex.Match(m.Value, "'MyGridView_ctl02_lblHao'>(.*?)</(spans|span)>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();

                    if (code.Trim().Length == 0) continue;
                    currentDate = DateTime.Parse(sdate);
                    break;
                }

                TimeSpan timeSpan = currentDate - lastDate;
                int days = timeSpan.Days + 1;
                int count = days * param.Category.Times;
                endIndex = (count / param.Category.DownPageSize) + 1;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(string.Format("ex:{0},message:{1}", ex, "获取EndIndex失败"));
            }

            return endIndex;
        }
    }
}


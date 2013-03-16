using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lottery.Data.Downloader
{
    using Logging;
    using Parameter;
    using Utils;

    /// <summary>
    /// 抓取888.qq.com网站的彩票数据类。
    /// </summary>
    public class QQDownloader : BaseDownloader, IDownloader
    {
        protected override bool Down11X5(DownParameter param)
        {
            Biz.D11X5.DwNumberBiz biz = new Biz.D11X5.DwNumberBiz(param.Category.DbName);
            DateTime startDate = biz.GetLatestDate();

            for (DateTime date = startDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (!this.Down11X5(param, biz, date)) return false;
            }

            return true;
        }

        private bool Down11X5(DownParameter param, Biz.D11X5.DwNumberBiz biz, DateTime currentDate)
        {
            int intDate = int.Parse(currentDate.ToString("yyyyMMdd"));
            string url = string.Format(param.Category.DownUrl, intDate, "&");

            try
            {
                string htmlText = Regex.Match(this._webClient.DownloadString(url), "<tbody id=\"row_show\">.*</tbody>",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase).Value;
                MatchCollection matchs = Regex.Matches(htmlText, "<tr>.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                if (matchs.Count == 0)
                {
                    Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
                    return false;
                }

                long lastP = biz.GetLatestPeroid();
                for (int i = matchs.Count - 1; i >= 0; i--)
                {
                    Match match = matchs[i];
                    string peroid = Regex.Match(match.Value, "<td width=\"25%\">(\\d+)期</td>", 
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string datetime = Regex.Match(match.Value, "<td width=\"25%\">(\\d{4}-\\d{2}-\\d{2}.*?)</td>", 
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string code = Regex.Match(match.Value, @"[<spans >|<span >](\d{2},\d{2},\d{2},\d{2},\d{2})[</spans>|<spans>]", 
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();

                    if (string.IsNullOrEmpty(code) || code.Trim().Length == 0) continue;

                    int p = int.Parse(peroid);
                    //把期号统一成{yyyymmddnn}
                    if (p < 2000000000) p += 2000000000;
                    if (p <= lastP) continue;

                    int n = int.Parse(peroid.Substring(peroid.Length - 2));
                    if (!biz.Add(p, n, code, intDate, datetime)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, ex.Message));
                return false;
            }
        }

        protected override bool DownSSC(DownParameter param)
        {
            Biz.SSC.DwNumberBiz biz = new Biz.SSC.DwNumberBiz(param.Category.DbName);
            DateTime startDate = biz.GetLatestDate();

            for (DateTime date = startDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (!this.DownSSC(param, biz, date)) return false;
            }

            return true;
        }

        private bool DownSSC(DownParameter param, Biz.SSC.DwNumberBiz biz, DateTime currentDate)
        {
            int intDate = int.Parse(currentDate.ToString("yyyyMMdd"));
            string url = string.Format(param.Category.DownUrl, "&", intDate);

            try
            {
                string htmlText = this._webClient.DownloadString(url);
                MatchCollection matchs = Regex.Matches(htmlText, "<tr>.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                if (matchs.Count == 0)
                {
                    Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
                    return false;
                }

                long lastP = biz.GetLatestPeroid();
                for (int i = matchs.Count - 1; i >= 0; i--)
                {
                    Match match = matchs[i];
                    string peroid = Regex.Match(match.Value, "<td width=\"25%\">(\\d+)期</td>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string datetime = Regex.Match(match.Value, "<td width=\"25%\">(\\d{4}-\\d{2}-\\d{2}.*?)</td>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string code = Regex.Match(match.Value, "<div class=\"numBall_ssc\">(.*?)</div>",
                        RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    code = Regex.Replace(code, "<.*?>|[\\s]", "").Trim();

                    if (string.IsNullOrEmpty(code) || code.Length == 0) continue;

                    long p = long.Parse(peroid);
                    //把期号统一成{yyyymmddnnn}
                    if (p < 20000000000) p += 20000000000;
                    if (p <= lastP) continue;

                    code = string.Join(",", code.ToArray());
                    int n = int.Parse(peroid.Substring(peroid.Length - 3));
                    if (!biz.Add(p, n, code, intDate, datetime)) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, ex.Message));
                return false;
            }
        }

    }
}


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Linq;

namespace Lottery.Downloader
{
    using Utils;
    using Data.SQLServer.SSC;
    using Logging;

    public class SSCDownloader : BaseDownloader, IDownloader
    {
        public bool Down(DownParameter param)
        {
            return this.DownData(param);
        }

        private bool DownData(DownParameter param)
        {
            int intDate = int.Parse(param.CurrentDate.ToString("yyyyMMdd"));
            string url = string.Format(param.DownUrl, "&", intDate);

            try
            {
                string htmlText = this._webClient.DownloadString(url);
                MatchCollection matchs = Regex.Matches(htmlText, "<tr>.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (matchs.Count == 0)
                {
                    Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Name, url, "count=0"));
                    return false;
                }

                DwNumberBiz biz = new DwNumberBiz(param.DbName);
                HashSet<long> pSet = biz.GetPeroidsByDate(param.CurrentDate);
                for (int i = matchs.Count - 1; i >= 0; i--)
                {
                    Match match = matchs[i];
                    string peroid = Regex.Match(match.Value, "<td width=\"25%\">(\\d+)期</td>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string datetime = Regex.Match(match.Value, "<td width=\"25%\">(\\d{4}-\\d{2}-\\d{2}.*?)</td>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string code = Regex.Match(match.Value, "<div class=\"numBall_ssc\">(.*?)</div>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    code = Regex.Replace(code, "<.*?>|[\\s]", "").Trim();
                    if (string.IsNullOrEmpty(code) || code.Length == 0) continue;

                    long p = long.Parse(peroid);
                    //把期号统一成{yyyymmddnnn}
                    if (p < 20000000000) p += 20000000000;
                    if (pSet.Contains(p)) continue;

                    code = string.Join(",", code.ToArray());
                    int n = int.Parse(peroid.Substring(peroid.Length - 3));
                    if (!biz.Add(p, n, code, intDate, datetime)) return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Name, url, exception.Message));
                return false;
            }
        }
    }
}


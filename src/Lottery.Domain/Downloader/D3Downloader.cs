using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Linq;

namespace Lottery.Downloader
{
    using Utils;
    using Data.SQLServer.D3;
    using Logging;

    public class D3Downloader : BaseDownloader, IDownloader
    {
        public bool Down(DownParameter param)
        {
            return this.DownData(param);
        }

        private bool DownData(DownParameter param)
        {
            int intDate = int.Parse(param.CurrentDate.ToString("yyyyMMdd"));
            string url = param.DownUrl;

            try
            {
                string htmlText = Regex.Match(this._webClient.DownloadString(url), "<div id=\"conKjlist\" class=\"kjlist\">.*?</table>", RegexOptions.Singleline | RegexOptions.IgnoreCase).Value;
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
                    string peroid = Regex.Match(match.Value, "<td>(\\d{7})</td>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string datetime = Regex.Match(match.Value, "<td>(\\d{4}-\\d{2}-\\d{2})</td>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                    string code = Regex.Match(match.Value, "<div class=\"aball\">.*?</div>", RegexOptions.IgnoreCase | RegexOptions.Singleline).Value;
                    code = Regex.Replace(code, "<.*?>", "");
                    code = string.Join(",", code.ToArray());
                    if (string.IsNullOrEmpty(code) || code.Trim().Length == 0) continue;

                    int p = int.Parse(peroid);
                    //把期号统一成{yyyynnn}
                    if (p < 2000000) p += 2000000;
                    if (pSet.Contains(p)) continue;

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


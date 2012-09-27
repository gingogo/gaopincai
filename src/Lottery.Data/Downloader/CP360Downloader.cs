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
    /// 抓取cp.360.cn网站的彩票数据类。
    /// </summary>
    public class CP360Downloader : BaseDownloader, IDownloader
    {
        protected override bool Down3D(DownParameter param)
        {
            SQLServer.D3.DwNumberBiz biz = new SQLServer.D3.DwNumberBiz(param.Category.DbName);
            DateTime startDate = biz.GetLatestDate();

            for (DateTime date = startDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (!this.Down3D(param, biz, date)) return false;
            }

            return true;
        }

        private bool Down3D(DownParameter param, SQLServer.D3.DwNumberBiz biz, DateTime currentDate)
        {
            int intDate = int.Parse(currentDate.ToString("yyyyMMdd"));
            string url = param.Category.DownUrl;

            try
            {
                string htmlText = Regex.Match(this._webClient.DownloadString(url), "<div id=\"conKjlist\" class=\"kjlist\">.*?</table>", 
                    RegexOptions.Singleline | RegexOptions.IgnoreCase).Value;
                MatchCollection matchs = Regex.Matches(htmlText, "<tr>.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                if (matchs.Count == 0)
                {
                    Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
                    return false;
                }

                HashSet<long> pSet = biz.GetPeroidsByDate(currentDate);
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
            catch (Exception ex)
            {
                Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, ex.Message));
                return false;
            }
        }

        protected override bool DownPL35(DownParameter param)
        {
            SQLServer.PL35.DwNumberBiz biz = new SQLServer.PL35.DwNumberBiz(param.Category.DbName);
            DateTime startDate = biz.GetLatestDate();

            for (DateTime date = startDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (!this.DownPL35(param, biz, date)) return false;
            }

            return true;
        }

        private bool DownPL35(DownParameter param, SQLServer.PL35.DwNumberBiz biz, DateTime currentDate)
        {
            int intDate = int.Parse(currentDate.ToString("yyyyMMdd"));
            string url = param.Category.DownUrl;

            try
            {
                string htmlText = Regex.Match(this._webClient.DownloadString(url), "<div id=\"conKjlist\" class=\"kjlist\">.*?</table>", RegexOptions.Singleline | RegexOptions.IgnoreCase).Value;
                MatchCollection matchs = Regex.Matches(htmlText, "<tr>.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (matchs.Count == 0)
                {
                    Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
                    return false;
                }

                HashSet<long> pSet = biz.GetPeroidsByDate(currentDate);
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
            catch (Exception ex)
            {
                Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, ex.Message));
                return false;
            }
        }
    }
}


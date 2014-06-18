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
	/// 抓取www.lecai.com网站的彩票数据类。
	/// </summary>
	public class LeCaiDownloader : BaseDownloader, IDownloader
	{
		protected override bool Down11X5(DownParameter param)
		{
			Biz.D11X5.DwNumberBiz biz = new Biz.D11X5.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();
			
			var numbers = this.GetNumbers(param, lastDate);
			if (numbers.Count == 0) return false;

			long lastP = biz.GetLatestPeroid();
			foreach (var numberInfo in numbers)
			{
				string code = numberInfo.Number;
				DateTime datetime = DateTime.Parse(numberInfo.DateTime);
				int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
				long p = int.Parse(numberInfo.Peroid);
                if (p < 2000000000) p += 2000000000;
				int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 2));

				if (p <= lastP) continue;
				if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
				return false;
			}
			return true;
		}

		protected override bool DownSSC(DownParameter param)
		{
			Biz.SSC.DwNumberBiz biz = new Biz.SSC.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();

			var numbers = this.GetNumbers(param, lastDate);
			if (numbers.Count == 0) return false;

			long lastP = biz.GetLatestPeroid();
			foreach (var numberInfo in numbers)
			{
				char[] digits = numberInfo.Number.ToArray();
				string code = string.Join(",", digits);
				DateTime datetime = DateTime.Parse(numberInfo.DateTime);
				int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
				long p = long.Parse(numberInfo.Peroid);
                if (p < 20000000000) p += 20000000000;
				int n = int.Parse(numberInfo.Peroid.Substring(numberInfo.Peroid.Length - 3));

				if (p <= lastP) continue;
				if (biz.Add(p, n, code, dateint, numberInfo.DateTime)) continue;
				return false;
			}
			return true;
		}

		protected override bool Down3D(DownParameter param)
		{
			Biz.D3.DwNumberBiz biz = new Biz.D3.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();

			var numbers = this.GetNumbers(param, lastDate);
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
			Biz.PL35.DwNumberBiz biz = new Biz.PL35.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();

			var numbers = this.GetNumbers(param, lastDate);
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
			Biz.SSL.DwNumberBiz biz = new Biz.SSL.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();

			var numbers = this.GetNumbers(param, lastDate);
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
			Biz.D12X3.DwNumberBiz biz = new Biz.D12X3.DwNumberBiz(param.Category.DbName);
			DateTime lastDate = biz.GetLatestDate();

			var numbers = this.GetNumbers(param, lastDate);
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

		private List<NumberInfo> GetNumbers(DownParameter param,DateTime lastDate)
		{
			string url = string.Empty;
			List<NumberInfo> numbers = new List<NumberInfo>(120);

			for (DateTime currDate = lastDate; currDate <= DateTime.Now;currDate=currDate.AddDays(1))
			{
				try
				{
					url = string.Format(param.Category.DownUrl, currDate.ToString("yyyy-MM-dd"));
					this._webClient.Encoding = System.Text.Encoding.UTF8;
                    string userAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
                    this._webClient.Headers.Add("User-Agent", userAgent);
					string pageText = this._webClient.DownloadString(url);
					var pageNumbers = this.ExtractNumbers(pageText,param.Category.DbName);
					if (pageNumbers.Count == 0)
					{
						Logger.Instance.Write(string.Format("name:{0},url:{1},msg:{2}", param.Category.Name, url, "count=0"));
						//break;
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

        private List<NumberInfo> ExtractNumbers(string pageText, string dbName)
        {
            List<NumberInfo> numbers = new List<NumberInfo>(120);
            string pattern = "<table id=\"draw_list\">.*?</table>";
            string drawListText = Regex.Match(pageText, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase).Value;
            MatchCollection matches = Regex.Matches(drawListText, "<tr class=\"bgcolor[0-9]\">.*?</tr>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            for (int i = matches.Count - 1; i >= 0; i--)
            {
                Match m = matches[i];
                string sdate = Regex.Match(m.Value, "<td class=\"td1\">(.*?)</td>",
                                           RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string speroid = Regex.Match(m.Value, "<td class=\"td2\">.*?(\\d+).*?</td>",
                                             RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
                string code = Regex.Match(m.Value, "<td class=\"td3\">(.*?)</td>",
                                          RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value;
                code = Regex.Replace(Regex.Replace(code, "</span>", ",", RegexOptions.IgnoreCase | RegexOptions.Singleline)
                                     , "<.*?>|[\\t\\n\\r\\s]", "", RegexOptions.IgnoreCase | RegexOptions.Singleline).Trim().TrimEnd(',');

                if (code.Trim().Length == 0) continue;
                if (dbName.ToLower().Contains("chongqssc"))
                    sdate = DateTime.Parse(sdate).AddMinutes((matches.Count - i) * 10).ToString();
                else
                    sdate = DateTime.Parse(sdate).AddHours(9).AddMinutes((matches.Count - i) * 10).ToString();
                numbers.Add(new NumberInfo(code, speroid, sdate));
            }

            return numbers;
        }
	}
}


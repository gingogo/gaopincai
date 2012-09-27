using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace Lottery.Services
{
    using Data.SQLServer.Common;
    using Logging;
    using Model.Common;

    /// <summary>
    /// 更新彩种分类表的数据。
    /// </summary>
    public class CategoryService :IService
    {
        public void Start(DateTime currentDateTime)
        {
            string urlFormat = "http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&name={3}&isgp={4}";
            List<Category> categories = CategoryBiz.Instance.GetCategories();
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            foreach (var category in categories)
            {
                if (category.ParentId == 0) continue;

                string url = string.Format(urlFormat, 1, category.Code, "", category.Name, category.IsGP);
                try
                {
                    string htmlText = wc.DownloadString(url);
                    string count = Regex.Match(htmlText, "共\\：(\\d+)条", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
                    string pageCount = Regex.Match(htmlText, "分页\\:1/(\\d+)页", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
                }
                catch
                {
                    Logger.Instance.Write(url);
                }
            }
        }

        public void Stop()
        {
        }

        public void Refresh()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Lottery.Services
{
    using Data.Biz.Common;
    using Logging;
    using Model.Common;
    using Utils;

    /// <summary>
    /// 更新彩种分类表的数据。
    /// </summary>
    public class CategoryService :IService
    {
        public void Start(DateTime currentDateTime)
        {
            if (!this.IsUpdateTime(currentDateTime)) return;

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
                    int peroidCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "共\\：(\\d+)条", 
                        RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    int pageCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "分页\\:1/(\\d+)页", 
                        RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    Category entity = new Category() { Id = category.Id, PeroidCount = peroidCount, DownPageCount = pageCount };
                    CategoryBiz.Instance.Modify(entity, entity.Id, Category.C_DownPageCount, Category.C_PeroidCount);
                }
                catch(Exception ex)
                {
                    Logger.Instance.Write(string.Format("url:{0},message:{1}", url, ex));
                }
            }
        }

        private bool IsUpdateTime(DateTime currentTime)
        {
            string hours = "21,22,23,0,1,2,3";
            return (hours.Contains(currentTime.Hour.ToString()) &&
                currentTime.Minute == 0 && currentTime.Second == 0);
        }
    }
}

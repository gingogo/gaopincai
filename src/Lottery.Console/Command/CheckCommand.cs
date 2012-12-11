using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Lottery.Console.Command
{
    using Configuration;
    using Data.SQLServer.Common;
    using Data.SQLServer.D11X5;
    using Model.Common;
    using Utils;
    using Logging;

    /// <summary>
    /// 数据校检命令。
    /// </summary>
    public class CheckCommand : ICommand
    {
        public CheckCommand()
        {
        }

        public void Execute(params string[] args)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string urlFormat = "http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&name={3}&isgp={4}";

                List<Category> categories = CategoryBiz.Instance.GetEnabledCategories(false);
                Dictionary<string, string> dict = new Dictionary<string, string>(categories.Count);

                foreach (var category in categories)
                {
                    if (category.ParentId == 0) continue;
                    string url = string.Format(urlFormat, 1, category.Code, "", category.Name, category.IsGP);
                    string htmlText = wc.DownloadString(url);
                    int peroidCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "共\\：(\\d+)条", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    int pageCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "分页\\:1/(\\d+)页", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    Category entity = new Category() { Id = category.Id, PeroidCount = peroidCount, DownPageCount = pageCount };
                    CategoryBiz.Instance.Modify(entity, entity.Id, Category.C_DownPageCount, Category.C_PeroidCount);
                    DwNumberBiz biz = new DwNumberBiz(category.DbName);
                    int maxSeq = biz.DataAccessor.SelectMaxWithCondition("Seq", 10, string.Empty);
                    int downPeroids = biz.Count;
                    System.Console.WriteLine("{0}:{1}", category.Name, string.Format("{0}期,下载,{1}期,Max Seq,{2}", peroidCount, downPeroids, maxSeq));
                    if (category.Type.Equals("11X5")) this.CheckC5CX(category);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Command Error!");
                Logger.Instance.Write(ex.ToString());
            }
        }

        private void CheckC5CX(Category category)
        {
            string[] c5cxs = new string[] { "C5C2", "C5C3", "C5C4", "C5C6", "C5C7", "C5C8" };
            DwC5CXSpanBiz c5cxbiz = new DwC5CXSpanBiz(category.DbName);
            foreach (string c5cx in c5cxs)
            {
                c5cxbiz.DataAccessor.TableName = ConfigHelper.GetDwSpanTableName(c5cx);
                int peroidCount = c5cxbiz.DataAccessor.Count();
                int maxSeq = c5cxbiz.DataAccessor.SelectMaxWithCondition("Seq", 10, string.Empty);
                System.Console.WriteLine("{0}:{1}", category.Name + "-" + c5cx, string.Format("{0}期,下载,Max Seq,{1}", peroidCount, maxSeq));
            }
        }
    }
}

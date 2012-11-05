using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;
    using Logging;

    /// <summary>
    /// CategoryBiz提供业务逻辑类。
    /// </summary>
    public partial class CategoryBiz :
        SinglePKDataAccessBiz<CategoryDAO, Category>
    {
        #region 私有字段

        private List<Category> listCache;

        #endregion

        #region 构造函数

        /// <summary>
        /// CategoryBiz类的一个单件。
        /// </summary>
        public static readonly CategoryBiz Instance = new CategoryBiz();

        protected CategoryBiz()
            : base(new CategoryDAO(ConfigHelper.CommonTableConnString))
        {
            this.LoadToCache();
        }

        #endregion

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public List<Category> GetCategories()
        {
            return this.listCache;
        }

        public List<Category> GetEnabledCategories()
        {
            return this.listCache.Where(x => x.Enabled == 1).OrderBy(x=>x.Seq).ToList();
        }

        public List<Category> GetEnabledCategories(string type)
        {
            return this.listCache.Where(x => x.Enabled == 1 && x.Type.ToLower().Equals(type.ToLower())).ToList();
        }

        public List<Category> GetEnabledCategories(bool isFromCache)
        {
            if (isFromCache) 
                return this.GetEnabledCategories();

            Operand operand = Restrictions.Clause(SqlClause.Where)
                .Append(Restrictions.Equal(Category.C_Enabled, 1));
            return this.DataAccessor.SelectWithCondition(operand.ToString());
        }

        public List<Category> GetEnabledCategories(bool isFromCache,string type)
        {
            if (isFromCache)
                return this.GetEnabledCategories(type);

            Operand operand = Restrictions.Clause(SqlClause.Where)
               .Append(Restrictions.Equal(Category.C_Enabled, 1))
               .Append(Restrictions.And)
               .Append(Restrictions.Equal(Category.C_Type, type));
            return this.DataAccessor.SelectWithCondition(operand.ToString());
        }

        public Dictionary<string, string> GetEnabledCategoriesPeroidCount()
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
                try
                {
                    string htmlText = wc.DownloadString(url);
                    int peroidCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "共\\：(\\d+)条",
                        RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    int pageCount = ConvertHelper.GetInt32(Regex.Match(htmlText, "分页\\:1/(\\d+)页",
                        RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value);
                    Category entity = new Category() { Id = category.Id, PeroidCount = peroidCount, DownPageCount = pageCount };
                    CategoryBiz.Instance.Modify(entity, entity.Id, Category.C_DownPageCount, Category.C_PeroidCount);
                    D11X5.DwNumberBiz biz = new D11X5.DwNumberBiz(category.DbName);
                    int maxSeq = biz.DataAccessor.GetMaxValue("Seq", 10, string.Empty);
                    int downPeroids = biz.Count;

                    dict.Add(category.Name, string.Format("{0}期,下载,{1}期,Max Seq,{2}", peroidCount, downPeroids, maxSeq));
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(string.Format("url:{0},message:{1}", url, ex));
                }
            }

            return dict;
        }

        #endregion

        #region 私有方法成员

        private void LoadToCache()
        {
            if (this.listCache != null && 
                this.listCache.Count > 0) this.listCache.Clear();

            this.listCache = this.GetAll();
        }

        #endregion
    }
}
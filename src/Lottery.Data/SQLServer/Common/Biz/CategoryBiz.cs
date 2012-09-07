using System;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// CategoryBiz提供业务逻辑类。
    /// </summary>
    public partial class CategoryBiz :
        SinglePKDataAccessBiz<CategoryDAO, Category>
    {
        /// <summary>
        /// DmCategoryBiz类的一个单件。
        /// </summary>
        public static readonly CategoryBiz Instance = new CategoryBiz();

        protected CategoryBiz()
            : base(new CategoryDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        public List<Category> GetEnabledCategories()
        {
            string condition = "where enabled = 1";
            return this.DataAccessor.SelectWithCondition(condition);
        }

        public List<Category> GetEnabledCategories(string type)
        {
            string condition = string.Format("where enabled = 1 and type = '{0}' ", type);
            return this.DataAccessor.SelectWithCondition(condition);
        }

        #endregion

        #region 私有方法成员

        #endregion
    }
}
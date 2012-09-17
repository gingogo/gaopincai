using System;
using System.Linq;
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
            //Operand operand = Restrictions.Clause(SqlClause.Where)
            //    .Append(Restrictions.Equal(Category.C_Enabled, 1));
            //return this.DataAccessor.SelectWithCondition(operand.ToString());
            return this.listCache.Where(x => x.Enabled == 1).OrderBy(x=>x.Seq).ToList();
        }

        public List<Category> GetEnabledCategories(string type)
        {
            //Operand operand = Restrictions.Clause(SqlClause.Where)
            //   .Append(Restrictions.Equal(Category.C_Enabled, 1))
            //   .Append(Restrictions.And)
            //   .Append(Restrictions.Equal(Category.C_Type, type));
            //return this.DataAccessor.SelectWithCondition(operand.ToString());
            return this.listCache.Where(x => x.Enabled == 1 && x.Type.ToLower().Equals(type.ToLower())).ToList();
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
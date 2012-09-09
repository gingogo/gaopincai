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
        /// CategoryBiz类的一个单件。
        /// </summary>
        public static readonly CategoryBiz Instance = new CategoryBiz();

        protected CategoryBiz()
            : base(new CategoryDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        public List<Category> GetEnabledCategories()
        {
            Operand operand = Restrictions.Clause(SqlClause.Where)
                .Append(Restrictions.Equal(Category.C_Enabled, 1));
            return this.DataAccessor.SelectWithCondition(operand.ToString());
        }

        public List<Category> GetEnabledCategories(string ruleType)
        {
            Operand operand = Restrictions.Clause(SqlClause.Where)
               .Append(Restrictions.Equal(Category.C_Enabled, 1))
               .Append(Restrictions.And)
               .Append(Restrictions.Equal(Category.C_RuleType, ruleType));
            return this.DataAccessor.SelectWithCondition(operand.ToString());
        }

        #endregion

        #region 私有方法成员

        #endregion
    }
}
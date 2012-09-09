using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    /// <summary>
    /// DmFCAnBiz提供业务逻辑类。
    /// </summary>
    public partial class DmFCAnBiz :
        SinglePKDataAccessBiz<DmFCAnDAO, DmFCAn>
    {
        public DmFCAnBiz(string dbName, string tableName)
            : base(new DmFCAnDAO(ConfigHelper.GetDmTableName(tableName), ConfigHelper.GetConnString(dbName)))
        {
        }

        #region 公共业务逻辑成员

        /// <summary>
        /// 获取指定维度值的号码集合
        /// </summary>
        /// <param name="dimension">维度代号</param>
        /// <param name="value">维值</param>
        /// <returns>号码集合</returns>
        public List<DmFCAn> GetNumbers(string dimension, string value)
        {
            string inValue = string.Join(",", value.Split(',').Select(x => string.Format("'{0}'", x)));
            Operand operand = Restrictions.Clause(SqlClause.Where)
                .Append(Restrictions.In(dimension, inValue));
            return this.DataAccessor.SelectWithCondition(operand.ToString(), dimension, SortTypeEnum.ASC, null, dimension, DmFCAn.C_Number);
        }

        #endregion

        #region 私有方法成员

        #endregion
    }
}
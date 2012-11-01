using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    /// <summary>
    /// DwC5CXSpanBiz提供业务逻辑类。
    /// </summary>
    public partial class DwC5CXSpanBiz :
        BaseDataAccessBiz<DwC5CXSpanDAO, DwC5CXSpan>
    {
        protected DwC5CXSpanBiz(string dbName, string tableName)
            : base(new DwC5CXSpanDAO(ConfigHelper.GetDwSpanTableName(tableName), ConfigHelper.GetConnString(dbName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
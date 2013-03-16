using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.Biz.D11X5
{
    using Data.D11X5;
    using Model.D11X5;
    using Utils;
    using Configuration;

    /// <summary>
    /// DwC5CXSpanBiz提供业务逻辑类。
    /// </summary>
    public partial class DwC5CXSpanBiz :
        BaseDataAccessBiz<IDwC5CXSpanDAO, DwC5CXSpan>
    {
        public DwC5CXSpanBiz(string dbName)
            : this(dbName, string.Empty)
        {
        }

        public DwC5CXSpanBiz(string dbName, string tableName)
            : base(DAOFactory.Create<IDwC5CXSpanDAO>(dbName, ConfigHelper.GetDwSpanTableName(tableName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
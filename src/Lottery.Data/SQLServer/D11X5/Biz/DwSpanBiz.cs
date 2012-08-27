using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    /// <summary>
    /// DwSpanBiz提供对各维度间隔表业务逻辑类。
    /// </summary>
    public partial class DwSpanBiz :
        BaseDataAccessBiz<DwSpanDAO, DwSpan>
    {
        public DwSpanBiz(string dbName, string tableName)
            : base(new DwSpanDAO(ConfigHelper.GetDwSpanTableName(tableName),
                ConfigHelper.GetConnString(dbName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Data.SQLServer.SSC
{
    using Model.SSC;
    using Utils;
    using Configuration;

    /// <summary>
    /// PeroidSpanBiz提供业务逻辑类。
    /// </summary>
    public partial class DwPeroidSpanBiz :
        BaseDataAccessBiz<DwPeroidSpanDAO, DwPeroidSpan>
    {
        public DwPeroidSpanBiz(string dbName, string tableName)
            : base(new DwPeroidSpanDAO(ConfigHelper.GetDwSpanTableName(tableName),
                ConfigHelper.GetConnString(dbName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
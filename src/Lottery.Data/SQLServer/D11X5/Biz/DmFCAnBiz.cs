using System;
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

        #endregion

        #region 私有方法成员

        #endregion
    }
}
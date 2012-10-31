using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    /// <summary>
    /// DmC5CXBiz提供业务逻辑类。
    /// </summary>
    public partial class DmC5CXBiz :
        BaseDataAccessBiz<DmC5CXDAO, DmC5CX>
    {
        public DmC5CXBiz(string dbName)
            : base(new DmC5CXDAO(ConfigHelper.GetConnString(dbName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
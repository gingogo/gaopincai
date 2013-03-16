using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Data.Biz.D11X5
{
    using Configuration;
    using Data.D11X5;
    using Model.D11X5;
    using Utils;

    /// <summary>
    /// DmC5CXBiz提供业务逻辑类。
    /// </summary>
    public partial class DmC5CXBiz :
        BaseDataAccessBiz<IDmC5CXDAO, DmC5CX>
    {
        public DmC5CXBiz(string dbName)
            : base(DAOFactory.Create<IDmC5CXDAO>(dbName))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
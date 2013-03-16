using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Data.Biz.PL35
{
    using Configuration;
    using Data.PL35;
    using Model.PL35;
    using Utils;

    /// <summary>
    /// DwSpanBiz提供对各维度间隔表业务逻辑类。
    /// </summary>
    public partial class DwSpanBiz :
        BaseDataAccessBiz<IDwSpanDAO, DwSpan>
    {
        public DwSpanBiz(string dbName, string tableName)
            : base(DAOFactory.Create<IDwSpanDAO>(dbName, ConfigHelper.GetDwSpanTableName(tableName)))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
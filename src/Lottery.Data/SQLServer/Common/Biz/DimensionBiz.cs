using System;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// DimensionBiz提供业务逻辑类。
    /// </summary>
    public partial class DimensionBiz :
        SinglePKDataAccessBiz<DimensionDAO, Dimension>
    {
        /// <summary>
        /// DimensionBiz类的一个单件。
        /// </summary>
        public static readonly DimensionBiz Instance = new DimensionBiz();

        protected DimensionBiz()
            : base(new DimensionDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
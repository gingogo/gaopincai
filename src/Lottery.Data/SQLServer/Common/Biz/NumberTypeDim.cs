using System;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// NumberTypeDimBiz提供业务逻辑类。
    /// </summary>
    public partial class NumberTypeDimBiz :
        SinglePKDataAccessBiz<NumberTypeDimDAO, NumberTypeDim>
    {
        /// <summary>
        /// NumberTypeDimBiz类的一个单件。
        /// </summary>
        public static readonly NumberTypeDimBiz Instance = new NumberTypeDimBiz();

        protected NumberTypeDimBiz()
            : base(new NumberTypeDimDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
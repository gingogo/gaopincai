using System;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// NumberTypeBiz提供业务逻辑类。
    /// </summary>
    public partial class NumberTypeBiz :
        SinglePKDataAccessBiz<NumberTypeDAO, NumberType>
    {
        /// <summary>
        /// NumberTypeBiz类的一个单件。
        /// </summary>
        public static readonly NumberTypeBiz Instance = new NumberTypeBiz();

        protected NumberTypeBiz()
            : base(new NumberTypeDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
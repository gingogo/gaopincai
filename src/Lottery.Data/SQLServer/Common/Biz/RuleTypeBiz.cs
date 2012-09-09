using System;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// RuleTypeBiz提供业务逻辑类。
    /// </summary>
    public partial class RuleTypeBiz :
        SinglePKDataAccessBiz<RuleTypeDAO, RuleType>
    {
        /// <summary>
        /// RuleTypeBiz类的一个单件。
        /// </summary>
        public static readonly RuleTypeBiz Instance = new RuleTypeBiz();

        protected RuleTypeBiz()
            : base(new RuleTypeDAO(ConfigHelper.CommonTableConnString))
        {
        }

        #region 公共业务逻辑成员

        #endregion

        #region 私有方法成员

        #endregion
    }
}
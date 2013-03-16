using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lottery.Data.Analysis
{
    using Model.Analysis;
    using Configuration;
    using Utils;

    /// <summary>
    /// IOmissionValueDAO提供表(OmissionValue)的相关数据访问公共接口。
    /// </summary>
    public interface IOmissionValueDAO : IBaseSelect<OmissionValue>
    {
        #region 特定数据访问方法

        List<OmissionValue> SelectOmissionValues(string ruleType, string numberType, string dimension, string filter,
            string orderByColName, string sortType);

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lottery.Data.Common
{
    using Model.Common;

    /// <summary>
    /// IDimensionNumberTypeDAO提供表(DimensionNumberType)的相关数据访问公共接口。
    /// </summary>
    public interface IDimensionNumberTypeDAO
        : ISinglePKDataAccess<DimensionNumberType>
    {
        #region 特定数据访问方法

        List<TypeDimensionNumberType> SelectGroupByTypeDimensionNumberType();

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Lottery.Data.D12X3
{
    using Model.Common;
    using Model.D12X3;

    /// <summary>
    /// IDmDPCDAO提供表(DmDx,DmPx,DmCx)的相关数据访问公共接口。
    /// </summary>
    public interface IDmDPCDAO : ISinglePKDataAccess<DmDPC>
    {
        #region 特定数据访问方法

        List<DimensionNumberType> SelectNumberTypeDimGroupBy(string[] dimensions, string numberType);

        #endregion
    }
}
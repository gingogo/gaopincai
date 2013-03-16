using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

namespace Lottery.Data.SSC
{
    using Model.Common;
    using Model.SSC;

    /// <summary>
    /// IDmFCAnDAO提供表(DmDx,DmPx,DmCx)的相关数据访问公共接口。
    /// </summary>
    public interface IDmDPCDAO : ISinglePKDataAccess<DmDPC>
    {
        #region 特定数据访问方法

        List<DimensionNumberType> SelectNumberTypeDimGroupBy(string[] dimensions, string numberType);

        #endregion
    }
}
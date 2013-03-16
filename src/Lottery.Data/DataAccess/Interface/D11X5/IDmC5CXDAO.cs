using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Lottery.Data.D11X5
{
    using Model.Common;
    using Model.D11X5;

    /// <summary>
    /// IDmC5CX提供表(DmC5CX)的相关数据访问公共接口。
    /// </summary>
    public interface IDmC5CXDAO
        : IBaseDataAccess<DmC5CX>
    {
         #region 特定数据访问方法

        List<DimensionNumberType> SelectNumberTypeDimGroupBy(string[] dimensions, string numberType);

        #endregion
    }
}
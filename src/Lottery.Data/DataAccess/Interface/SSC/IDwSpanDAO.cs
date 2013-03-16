using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lottery.Data.SSC
{
    using Model.SSC;

    /// <summary>
    /// IDwSpanDAO提供各维度间隔表(DwXXXXSpan)的相关数据访问公共接口。
    /// </summary>
    public interface IDwSpanDAO: IBaseDataAccess<DwSpan>
    {
        #region 特定数据访问方法

        long SelectLatestPeroid(string condition);

        long SelectMaxPeroid();

        int SelectMaxSpan(string num);

        int SelectAvgSpan(string num);

        #endregion
    }
}
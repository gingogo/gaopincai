using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Lottery.Data.D11X5
{
    using Model.D11X5;

    /// <summary>
    /// IDwC5CXSpan提供表(DwC5C[2,3,4,6,7,8]Span)的相关数据访问公共接口。
    /// </summary>
    public interface IDwC5CXSpanDAO: IBaseDataAccess<DwC5CXSpan>
    {
        #region 特定数据访问方法

        long SelectLatestPeroid(string condition);

        /// <summary>
        /// 获取开奖号码每个维度的间隔.
        /// </summary>
        /// <param name="c5cxNumbers">c5cx号码集合</param>
        /// <param name="currentSeq">当前期数</param>
        /// <param name="tableName">DwC5C2|3|4|6|7|8Spans</param>
        /// <param name="dmNames">维度名称(区分大小写,取值为:Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <param name="numberType">号码类型C2|C3|C4|C6|C7|C8</param>
        /// <returns></returns>
        Dictionary<string, Dictionary<string, int>> SelectLastSpans(List<DmC5CX> c5cxNumbers,
            int currentSeq, string tableName, string[] dmNames, string numberType);

        #endregion
    }
}
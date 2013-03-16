using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace Lottery.Data.D12X3
{
    using Model.D12X3;

    /// <summary>
    /// IDwNumberDAO提供表(DwNumber)的相关数据访问公共接口。
    /// </summary>
    public interface IDwNumberDAO : ISinglePKDataAccess<DwNumber>
    {
        #region 公有方法

        int SelectLatestDate(string condition);

        long SelectLatestPeroid(string condition);

        List<DwNumber> SelectDistinctDate();

        DwNumber SelectLastOneBySeq(string numberId, string columnName, string filter);

        /// <summary>
        /// 获取开奖号码每个维度的间隔.
        /// </summary>
        /// <param name="number">开奖号码</param>
        /// <param name="dmName">维度名称(区分大小写,取值为:Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <param name="numberTypes">号码类型</param>
        /// <returns></returns>
        Dictionary<string, int> SelectSpansByNumberTypes(DwNumber number, string dmName, string[] numberTypes);

        /// <summary>
        /// 获取指定号码在今天出现的期数，来判断该号码今天是否出现
        /// </summary>
        /// <param name="numberId">号码</param>
        /// <param name="columnName">号码类型</param>
        /// <returns></returns>
        string GetPeroidInToday(string numberId, string columnName);

        /// <summary>
        /// 获取指定号码在指定日期前最后一次出现的期数
        /// </summary>
        /// <param name="numberId">号码</param>
        /// <param name="columnName">号码类型</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        string GetPeroidBefore(string numberId, string columnName, DateTime dt);

        #endregion
    }
}


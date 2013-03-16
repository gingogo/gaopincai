using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace Lottery.Data.D11X5
{
    using Model.D11X5;

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

        Dictionary<string, int> SelectSpansByNumberTypes(DwNumber number, string dmName, string[] numberTypes);

        string GetPeroidInToday(string numberId, string columnName);

        string GetPeroidBefore(string numberId, string columnName, DateTime dt);

        void UpdateSeq(int n, long p);

        #endregion
    }
}


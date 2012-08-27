using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.D11X5
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class Base11X5Statistics : BaseStatistics
    {
        protected override List<DmCategory> GetCatgories()
        {
            return DmCategoryBiz.Instance.GetEnabledCategories("11X5");
        }
    }
}

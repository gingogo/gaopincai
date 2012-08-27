using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.SSC
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class BaseSSCStatistics : BaseStatistics
    {
        protected override List<DmCategory> GetCatgories()
        {
            return DmCategoryBiz.Instance.GetEnabledCategories("SSC");
        }
    }
}

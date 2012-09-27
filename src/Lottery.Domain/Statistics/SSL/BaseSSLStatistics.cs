using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.SSL
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class BaseSSLStatistics : BaseStatistics
    {
        protected override List<Category> GetCatgories()
        {
            return CategoryBiz.Instance.GetEnabledCategories("SSL");
        }
    }
}

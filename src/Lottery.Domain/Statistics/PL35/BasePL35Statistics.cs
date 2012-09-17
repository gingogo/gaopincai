using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.PL35
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class BasePL35Statistics : BaseStatistics
    {
        protected override List<Category> GetCatgories()
        {
            return CategoryBiz.Instance.GetEnabledCategories("PL35");
        }
    }
}

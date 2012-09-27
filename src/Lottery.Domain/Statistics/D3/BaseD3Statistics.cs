using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.D3
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class BaseD3Statistics : BaseStatistics
    {
        protected override List<Category> GetCatgories()
        {
            return CategoryBiz.Instance.GetEnabledCategories("3D");
        }
    }
}

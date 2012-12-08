using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.SSC
{
    using Model.Common;
    using Data.SQLServer.Common;

    public abstract class BaseSSCStat : BaseStat
    {
        protected override List<Category> GetCatgories()
        {
            //Category category = CategoryBiz.Instance.GetById(147);
            //return new List<Category>() { category };
            return CategoryBiz.Instance.GetEnabledCategories("SSC");
        }
    }
}

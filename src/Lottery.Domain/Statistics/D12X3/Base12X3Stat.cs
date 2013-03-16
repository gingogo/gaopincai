using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.D12X3
{
    using Model.Common;
    using Data.Biz.Common;

    public abstract class Base12X3Stat : BaseStat
    {
        protected override List<Category> GetCatgories()
        {
            //Category category = CategoryBiz.Instance.GetById(185);
            //return new List<Category>() { category };
            return CategoryBiz.Instance.GetEnabledCategories("12X3");
        }
    }
}

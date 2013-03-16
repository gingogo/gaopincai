using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.SSL
{
    using Model.Common;
    using Data.Biz.Common;

    public abstract class BaseSSLStat : BaseStat
    {
        protected override List<Category> GetCatgories()
        {
            //Category category = CategoryBiz.Instance.GetById(144);
            //return new List<Category>() { category };
            return CategoryBiz.Instance.GetEnabledCategories("SSL");
        }
    }
}

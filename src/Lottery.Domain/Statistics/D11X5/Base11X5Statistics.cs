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
        protected override List<Category> GetCatgories()
        {
            Category category = CategoryBiz.Instance.GetById(167);
            return new List<Category>() { category };
            //return CategoryBiz.Instance.GetEnabledCategories("11X5");
        }
    }
}

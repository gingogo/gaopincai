using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lottery.Data.Common
{
    using Model.Common;

    /// <summary>
    /// ICategoryDAO提供表(Category)的相关数据访问公共接口。
    /// </summary>
    public interface ICategoryDAO
        : ISinglePKDataAccess<Category>
    {
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Lottery.Data.Common
{
    using Model.Common;

    /// <summary>
    /// INumberTypeDAO提供表(NumberType)的相关数据访问公共接口。
    /// </summary>
    public interface INumberTypeDAO
        : ISinglePKDataAccess<NumberType>
    {        
    }
}
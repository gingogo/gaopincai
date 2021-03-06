using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Data
{
    /// <summary>
    /// 视图结构基本业务逻辑类的泛型基类。
    /// </summary>
    /// <typeparam name="U">数据访问层接口</typeparam>
    /// <typeparam name="T">实体对象</typeparam>
    public abstract class ViewDataAccessBiz<U, T> : CommonBiz<U, T>
        where U : IBaseSelect<T>, IViewDataAccess<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataAccessor">数据访问器对象</param>
        protected ViewDataAccessBiz(U dataAccessor)
            : base(dataAccessor)
        {
        }
    }
}


using System;

namespace Lottery.Data.Parameter
{
    using Model.Common;
    
    /// <summary>
    /// 提供异步事件封送的参数类。
    /// </summary>
    public class EventParameter
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="category">彩种对象</param>
        public EventParameter(Category category)
        {
            this.Category = category;
        }

        /// <summary>
        /// 获取或设置彩种对象。
        /// </summary>
        public Category Category { get; set; }
    }
}


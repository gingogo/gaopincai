namespace Lottery.Data.Parameter
{
    using Model.Common;

    /// <summary>
    /// 提供彩票数据下载导入所需的参数类。
    /// </summary>
    public class DownParameter
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="category">彩种对象</param>
        public DownParameter(Category category)
        {
            this.Category = category;
        }

        /// <summary>
        /// 获取或设置需要下载导入彩种对象。
        /// </summary>
        public Category Category { get; set; }
    }
}

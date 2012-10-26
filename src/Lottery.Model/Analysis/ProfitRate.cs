using System;

namespace Lottery.Model.Analysis
{
    /// <summary>
    /// 投资收益率数据对象。
    /// </summary>
    public class ProfitRate
    {
        public ProfitRate()
        {
        }

        /// <summary>
        /// 获取或设置投入期数
        /// </summary>
        public int PeroidNum { get; set; }

        /// <summary>
        /// 获取或设置投入倍数
        /// </summary>
        public int MultiNums { get; set; }

        /// <summary>
        /// 获取或设置本期投入
        /// </summary>
        public double CurrentAmount { get; set; }

        /// <summary>
        /// 获取或设置累计投入
        /// </summary>
        public double TotalAmount { get; set; }

        /// <summary>
        /// 获取或设置本期收益
        /// </summary>
        public double CurrentProfit { get; set; }

        /// <summary>
        /// 获取盈利收益
        /// </summary>
        public double TotalProfit
        {
            get { return this.CurrentProfit - this.TotalAmount; }
        }

        /// <summary>
        /// 获取收益率
        /// </summary>
        public double ProfitRating
        {
            get { return this.TotalProfit / this.TotalAmount; }
        }
    }
}

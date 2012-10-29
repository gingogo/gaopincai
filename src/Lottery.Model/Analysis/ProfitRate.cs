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
        /// 构造函数。
        /// </summary>
        /// <param name="peroidNum">当前期数</param>
        /// <param name="nums">当前投注数</param>
        /// <param name="multiNums">投注倍数</param>
        /// <param name="prize">单位奖金</param>
        /// <param name="lastTotalAmount">当前累入投入金额</param>
        public ProfitRate(int peroidNum,int nums,int multiNums,double prize,double lastTotalAmount)
        {
            this.PeroidNum = peroidNum;
            this.MultiNums = multiNums;
            this.CurrentAmount = nums * multiNums * 2;
            this.CurrentProfit = prize * multiNums;
            this.CurrentTotalAmount = lastTotalAmount + this.CurrentAmount;
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
        public double CurrentTotalAmount { get; set; }

        /// <summary>
        /// 获取或设置本期收益
        /// </summary>
        public double CurrentProfit { get; set; }

        /// <summary>
        /// 获取盈利收益
        /// </summary>
        public double TotalProfit
        {
            get { return this.CurrentProfit - this.CurrentTotalAmount; }
        }

        /// <summary>
        /// 获取收益率
        /// </summary>
        public double ProfitRating
        {
            get { return this.TotalProfit / this.CurrentTotalAmount; }
        }
    }
}

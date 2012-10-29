using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.ViewData
{
    using Model.Analysis;

    /// <summary>
    /// 投资收益率View数据对象
    /// </summary>
    public class ProfitRateViewData
    {
        private ProfitRate _profitRate;

        /// <summary>
        /// 构造投资收益率View数据对象
        /// </summary>
        /// <param name="profitRate">投资收益率数据对象</param>
        public ProfitRateViewData(ProfitRate profitRate)
        {
            this._profitRate = profitRate;
        }

        /// <summary>
        /// 获取投入期数
        /// </summary>
        public string PeroidNums
        {
            get { return this._profitRate.PeroidNum.ToString(); }
        }

        /// <summary>
        /// 获取投入倍数
        /// </summary>
        public string MultiNums
        {
            get { return this._profitRate.MultiNums.ToString(); }
        }

        /// <summary>
        /// 获取本期投入
        /// </summary>
        public string CurrentAmount
        {
            get { return this._profitRate.CurrentAmount.ToString("F2"); }
        }

        /// <summary>
        /// 获取累计投入
        /// </summary>
        public string TotalAmount
        {
            get { return this._profitRate.CurrentTotalAmount.ToString("F2"); }
        }

        /// <summary>
        /// 获取本期收益
        /// </summary>
        public string CurrentProfit
        {
            get { return this._profitRate.CurrentProfit.ToString("F2"); }
        }

        /// <summary>
        /// 获取盈利收益
        /// </summary>
        public string TotalProfit
        {
            get { return this._profitRate.TotalProfit.ToString("F2"); }
        }

        /// <summary>
        /// 获取收益率
        /// </summary>
        public string ProfitRating
        {
            get { return this._profitRate.ProfitRating.ToString("P"); }
        }
    }
}

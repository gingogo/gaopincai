using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Model.Analysis
{
    /// <summary>
    /// 倍投参数对象
    /// </summary>
    public class MultiParameter
    {
        public MultiParameter()
        {
        }

        /// <summary>
        /// 获取或设置方案期数
        /// </summary>
        public int PeroidNums { get; set; }

        /// <summary>
        /// 获取或设置投入注数
        /// </summary>
        public int Nums { get; set; }

        /// <summary>
        /// 获取或设置起始倍数
        /// </summary>
        public int StartMultiNums { get; set; }

        /// <summary>
        /// 获取或设置最大倍数
        /// </summary>
        public int MaxMultiNums { get; set; }

        /// <summary>
        /// 获取或设置单倍奖金
        /// </summary>
        public double Prize { get; set; }

        /// <summary>
        /// 获取或设置方案期数
        /// </summary>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// 获取或设置是否设置全程收益率
        /// </summary>
        public double GlobalRating { get; set; }

        /// <summary>
        /// 获取或设置前N期数
        /// </summary>
        public int PrevPeroidNums { get; set; }

        /// <summary>
        /// 获取或设置前N期数收益率
        /// </summary>
        public double PrevPeroidRating { get; set; }

        /// <summary>
        /// 获取或设置之后期数收益率
        /// </summary>
        public double RestPeroidRating { get; set; }

        /// <summary>
        /// 获取或设置最低收益金额
        /// </summary>
        public double MinProfitAmount { get; set; }
    }
}

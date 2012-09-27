using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Data.Downloader
{
    /// <summary>
    /// 开奖号码信息类
    /// </summary>
    public class NumberInfo
    {
        public NumberInfo()
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="number">开奖号码</param>
        /// <param name="peroid">开奖期号</param>
        /// <param name="dateTime">开奖时间</param>
        public NumberInfo(string number, string peroid, string dateTime)
        {
            this.Number = number;
            this.Peroid = peroid;
            this.DateTime = dateTime;
        }

        /// <summary>
        /// 获取或设置开奖号码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 获取或设置开奖期号
        /// </summary>
        public string Peroid { get; set; }

        /// <summary>
        /// 获取或设置开奖时间
        /// </summary>
        public string DateTime { get; set; }
    }
}

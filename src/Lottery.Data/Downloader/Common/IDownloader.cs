using System;

namespace Lottery.Data.Downloader
{
    using Parameter;

    /// <summary>
    /// 彩票数据下载器接口。
    /// </summary>
    public interface IDownloader
    {
        /// <summary>
        /// 下载开奖数据并保存到数据库
        /// </summary>
        /// <param name="param">下载数据参数对象</param>
        /// <returns>true成功,false失败</returns>
        bool Down(DownParameter param);
    }
}


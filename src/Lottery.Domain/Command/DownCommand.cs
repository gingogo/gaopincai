using System;

namespace Lottery.Command
{
    /// <summary>
    /// 数据下载命令。
    /// </summary>
    public class DownCommand : BaseCommand
    {
        public DownCommand()
        {
        }

        protected override void ExecuteCommand(Action<string> output, params string[] args)
        {
            Services.DownloadService s = new Services.DownloadService();
            s.StartSync(DateTime.Now);

            if (args != null &&
                args.Length > 0 &&
                args[0].Trim().ToLower().Equals("c5cx"))
            {
                Statistics.IStat stat = new Statistics.D11X5.C5CXSpanStat();
                stat.Stat();
            }
        }
    }
}

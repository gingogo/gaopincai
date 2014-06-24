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
        }
    }
}

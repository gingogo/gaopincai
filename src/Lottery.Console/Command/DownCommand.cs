using System;

namespace Lottery.Console.Command
{
	/// <summary>
	/// 数据下载命令。
	/// </summary>
	public class DownCommand : ICommand
	{
		public DownCommand()
		{
		}
		
		public void Execute(params string[] args)
		{
			try
            {
                Services.DownloadService s = new Services.DownloadService();
                s.StartSync(DateTime.Now);
                Statistics.IStat stat = new Statistics.D11X5.C5CXSpanStat();
                stat.Stat();
            }
            catch (Exception ex)
            {
                Logging.Logger.Instance.Write(ex.ToString());
            }
		}
	}
}

using System;
using System.Linq;

namespace Lottery.Console.Command
{
	/// <summary>
	/// 初始化数据命令。
	/// </summary>
	public class InitCommand : ICommand
	{
		public InitCommand()
		{
		}
		
		public void Execute(params string[] args)
		{
			Statistics.IStat[] stats = new Statistics.IStat[]
			{
				new Statistics.D11X5.SpanStat(),
				new Statistics.SSC.SpanStat(),
				new Statistics.D3.SpanStat(),
				new Statistics.PL35.SpanStat(),
				new Statistics.SSL.SpanStat(),
				new Statistics.D12X3.SpanStat(),
				new Statistics.D11X5.C5CXSpanStat(),
			};
			
			try
			{
				foreach (var stat in stats)
				{
					stat.Stat(false,true);
				}
			}
			catch (Exception ex)
			{
                System.Console.WriteLine("Command Error!");
				Logging.Logger.Instance.Write(ex.ToString());
			}
		}
	}
}

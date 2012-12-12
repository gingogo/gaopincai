using System;
using System.Linq;

namespace Lottery.Command
{
	/// <summary>
	/// 初始化数据命令。
	/// </summary>
    public class InitCommand : BaseCommand
	{
		public InitCommand()
		{
		}

        protected override void ExecuteCommand(Action<string> output, params string[] args)
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

            foreach (var stat in stats)
            {
                stat.Stat(false, true);
            }
		}
	}
}

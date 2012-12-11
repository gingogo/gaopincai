using System;
using System.Collections.Generic;

namespace Lottery.Console.Command
{
	/// <summary>
	/// 遗漏值计算命令。
	/// </summary>
	public class SpanCommand : ICommand
	{
		public SpanCommand()
		{
		}
		
		public void Execute(params string[] args)
		{
			
			List<Statistics.IStat> stats = new List<Statistics.IStat>(args.Length);
			foreach(var arg in args)
			{
				if(arg.ToLower().Trim().Equals("11x5"))
					stats.Add(new Statistics.D11X5.SpanStat());
				if(arg.ToLower().Trim().Equals("ssc"))
					stats.Add(new Statistics.D11X5.SpanStat());
				if(arg.ToLower().Trim().Equals("3d"))
					stats.Add(new Statistics.D11X5.SpanStat());
				if(arg.ToLower().Trim().Equals("12x3"))
					stats.Add(new Statistics.D11X5.SpanStat());
				if(arg.ToLower().Trim().Equals("ssl"))
					stats.Add(new Statistics.D11X5.SpanStat());
				if(arg.ToLower().Trim().Equals("c5cx"))
					stats.Add(new Statistics.D11X5.SpanStat());
			}
			
			try
			{
				foreach (var stat in stats)
				{
					stat.Stat(false,false);
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

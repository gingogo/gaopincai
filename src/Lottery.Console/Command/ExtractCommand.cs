using System;

namespace Lottery.Console.Command
{
	using ETL;
	
	/// <summary>
	/// 批量数据下载与提取命令。
	/// </summary>
	public class ExtractCommand : ICommand
	{
		public ExtractCommand()
		{
		}
		
		public void Execute(params string[] args)
		{
			if(args == null || args.Length == 0)
				throw new ArgumentNullException("args");
			
			try
			{
				foreach (var arg in args)
				{
					DataDownload.DownPage(int.Parse(arg));
					ExtractData.Extract(int.Parse(arg));
				}
			}
			catch (Exception ex)
			{
				Logging.Logger.Instance.Write(ex.ToString());
			}
		}
	}
}

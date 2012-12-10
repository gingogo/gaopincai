using System;

namespace Lottery.Console.Command
{
	/// <summary>
	/// 命令解析器。
	/// </summary>
	public class CommandParser
	{
		public static void Parse(string cmdName,params string[] args)
		{
			if(string.IsNullOrEmpty(cmdName) ||
			   cmdName.Trim().Length == 0) throw new ArgumentNullException("cmdName");
			
			ICommand command = Creator(cmdName);
			command.Execute(args);
		}
		
		private static ICommand Creator(string cmdName)
		{
			cmdName = cmdName.Trim().ToLower();
			
			if(cmdName.Equals("down")) return new DownCommand();
			if(cmdName.Equals("check")) return new CheckCommand();
			if(cmdName.Equals("extract")) return new ExtractCommand();
			if(cmdName.Equals("init")) return new InitCommand();
			if(cmdName.Equals("span")) return new SpanCommand();
			
			return new BadCommand();
		}
	}
}

using System;

namespace Lottery.Command
{
	/// <summary>
	/// 命令解析器。
	/// </summary>
	public class CommandParser
	{
        public static void Parse(Action<string> output,string cmdName, params string[] args)
		{
			if(string.IsNullOrEmpty(cmdName) ||
               cmdName.Trim().Length == 0) System.Console.WriteLine("Not found this Command!");
			
			ICommand command = Creator(cmdName);
            command.Execute(output, args);
		}
		
		private static ICommand Creator(string cmdName)
		{
			cmdName = cmdName.Trim().ToLower();
			
			if(cmdName.Equals("down")) return new DownCommand();
			if(cmdName.Equals("check")) return new CheckCommand();
			if(cmdName.Equals("extract")) return new ExtractCommand();
			if(cmdName.Equals("init")) return new InitCommand();
			if(cmdName.Equals("span")) return new SpanCommand();
			if(cmdName.Equals("respan")) return new ReSpanCommand();
			
			return new BadCommand();
		}
	}
}

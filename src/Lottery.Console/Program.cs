using System;

namespace Lottery.Console
{
	using Command;
	
	class Program
	{
		static void Main(string[] args)
		{
            if (args == null || args.Length == 0)
            {
                System.Console.WriteLine("Please input your command name.");
                return;
            }

            string cmdName = args[0];
            string[] cmdArgs = new string[args.Length - 1];
            Array.Copy(args, 1, cmdArgs, 0, args.Length - 1);
            CommandParser.Parse(System.Console.WriteLine, cmdName, cmdArgs);

			System.Console.WriteLine("All Command Finished!");
		}
	}
}
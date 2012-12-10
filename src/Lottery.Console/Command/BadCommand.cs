using System;

namespace Lottery.Console.Command
{
	/// <summary>
	/// Description of BadCommand.
	/// </summary>
	public class BadCommand : ICommand
	{
		public BadCommand()
		{
		}
		
		public void Execute(params string[] args)
		{
			System.Console.WriteLine("Not found this Command!");
		}
	}
}

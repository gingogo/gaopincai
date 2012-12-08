using System;

namespace Lottery.Console.Command
{
	/// <summary>
	/// Description of ICommand.
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// 命令执行方法
		/// </summary>
		/// <param name="args">参数</param>
		void Execute(params string[] args);
	}
}

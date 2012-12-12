using System;

namespace Lottery.Command
{
	/// <summary>
	/// Description of ICommand.
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// 命令执行方法
		/// </summary>
        /// <param name="output">输出方法</param>
		/// <param name="args">参数</param>
		void Execute(Action<string> output, params string[] args);
	}
}

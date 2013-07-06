using System;

namespace Lottery.Command
{
    using ETL;

    /// <summary>
    /// 批量数据下载与提取命令。
    /// </summary>
    public class ExtractCommand : BaseCommand
    {
        public ExtractCommand()
        {
        }

        protected override void ExecuteCommand(Action<string> output, params string[] args)
        {
            if (args == null || args.Length == 0)
                output("Please input arguments.");

            foreach (var arg in args)
            {
                DataDownload.DownKaiJiangData(int.Parse(arg));
                ExtractData.Extract(int.Parse(arg));
            }
        }
    }
}

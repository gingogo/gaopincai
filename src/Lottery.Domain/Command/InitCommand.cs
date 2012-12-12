using System;
using System.Collections.Generic;
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
            var statDict = new Dictionary<string, Statistics.IStat>(7);
            statDict.Add("11x5", new Statistics.D11X5.SpanStat());
            statDict.Add("ssc", new Statistics.SSC.SpanStat());
            statDict.Add("3d", new Statistics.D3.SpanStat());
            statDict.Add("pl35", new Statistics.PL35.SpanStat());
            statDict.Add("ssl", new Statistics.SSL.SpanStat());
            statDict.Add("12x3", new Statistics.D12X3.SpanStat());
            statDict.Add("c5cx", new Statistics.D11X5.C5CXSpanStat());

            if (args != null && args.Length > 0)
            {
                ExecuteArgCmmand(statDict, output, args);
                return;
            }

            foreach (var dict in statDict)
            {
                dict.Value.Stat(false, true);
            }
        }

        private void ExecuteArgCmmand(Dictionary<string, Statistics.IStat> statDict, Action<string> output, string[] args)
        {
            foreach (var arg in args)
            {
                string key = arg.Trim().ToLower();
                if (statDict.ContainsKey(key))
                    statDict[key].Stat(false, true);
                else
                    output(string.Format("Not found argument : {0}.", arg));
            }
        }
    }
}

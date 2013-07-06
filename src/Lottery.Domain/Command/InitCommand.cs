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
            if (args == null || args.Length == 0)
                output("Please input arguments.");

			foreach(var arg in args)
			{
				if(arg.ToLower().Trim().Equals("11x5"))
					ETL.D11X5.ImportDmDPC.Add("db");
				if(arg.ToLower().Trim().Equals("ssc"))
					ETL.SSC.ImportDmDPC.AddSSC("db");
				if(arg.ToLower().Trim().Equals("3d"))
					ETL.SSC.ImportDmDPC.Add3D("db");
				if(arg.ToLower().Trim().Equals("12x3"))
					ETL.D12X3.ImportDmDPC.Add("db");
				if(arg.ToLower().Trim().Equals("ssl"))
					ETL.SSC.ImportDmDPC.AddSSL("db");
				if(arg.ToLower().Trim().Equals("pl35"))
					ETL.SSC.ImportDmDPC.AddPL35("db");
			}
		}
    }
}

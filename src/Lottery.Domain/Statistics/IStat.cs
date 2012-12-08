using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics
{
    public interface IStat
    {
    	void Stat();
    	
        void Stat(bool isReset);

        void Stat(bool isAsync,bool isReset);
    }
}

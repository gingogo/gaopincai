using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Statistics
{
    public interface IStatistics
    {
        void Stat();

        void Stat(bool isAsync);
    }
}

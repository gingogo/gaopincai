using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Services
{
    public interface IService
    {
        void Start(DateTime currentDateTime);
        void Stop();
        void Refresh();
    }
}

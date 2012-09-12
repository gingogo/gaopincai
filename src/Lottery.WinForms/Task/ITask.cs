using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.Task
{
    public interface ITask
    {
        void Start(object userState, Parameter parameter);
    }
}

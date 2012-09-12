using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.Task
{
    public class TaskArguments
    {
        private ITask _task;
        private Parameter _parameter;

        public TaskArguments(ITask task,Parameter parameter)
        {
            this._task = task;
            this._parameter = parameter;
        }

        public ITask Task
        {
            get { return this._task; }
        }

        public Parameter Parameter
        {
            get { return this._parameter; }
        }
    }
}

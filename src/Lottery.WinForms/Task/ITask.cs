using System.Windows.Forms;

namespace Lottery.WinForms.Task
{
    public interface ITask
    {
        void Start(Parameter parameter);

        void Complete(Parameter parameter);
    }
}

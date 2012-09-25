using System.Windows.Forms;

namespace Lottery.WinForms.Task
{
    using Components;

    public class Parameter
    {
        public Parameter() { }

        public object UserState { get; set; }

        public AsyncEventWorker Worker { get; set; }

        public Control Sender { get; set; }

        public Control Target { get; set; }

        public MainForm Owner { get; set; }
    }
}

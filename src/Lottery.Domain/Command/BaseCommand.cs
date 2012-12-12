using System;

namespace Lottery.Command
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand()
        { }

        public virtual void Execute(Action<string> output, params string[] args)
        {
            try
            {
                this.ExecuteCommand(output, args);
            }
            catch (Exception ex)
            {
                output("Command Error!");
                Logging.Logger.Instance.Write(ex.ToString());
            }
        }

        protected virtual void ExecuteCommand(Action<string> output, params string[] args)
        {
            output("Not found this Command!");
        }
    }
}

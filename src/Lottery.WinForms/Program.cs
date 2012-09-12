using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms
{
    using Helpers;
    using UI;
    using Logging;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                AppContainer container = new AppContainer();
                MainForm form = new MainForm();
                container.Add(form);

                //Logger.Instance.Write("程序启动", LogLevel.Info);
                Application.Run(form);
                //Logger.Instance.Write("程序退出", LogLevel.Info);
            }
            catch (Exception ex)
            {
                //Logger.Instance.Write(ex.ToString(), LogLevel.Error);
                MessageBoxHelper.DisplayFailure(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System;
using System.ServiceProcess;
using System.Timers;

namespace Lottery.WinService
{
    using Logging;

    public partial class MainService : ServiceBase
    {
        private Timer updateTimer;

        public MainService()
        {
            InitializeComponent();

            updateTimer = new System.Timers.Timer();
            updateTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            updateTimer.Interval = 1000;
        }

        protected override void OnStart(string[] args)
        {
            updateTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            updateTimer.Enabled = false;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (e.SignalTime.Hour < 9) return;
                Services.ServiceManager.RunAllService(e.SignalTime);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex.ToString());
            }
        }
    }
}

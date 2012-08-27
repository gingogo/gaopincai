using System;
using System.Collections.Generic;
using System.Timers;

namespace Lottery.Test
{
    using Services;

    public class Bootstraper
    {
        private Timer updateTimer;

        public Bootstraper()
        {
            updateTimer = new System.Timers.Timer();
            updateTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            updateTimer.Interval = 1000;
            updateTimer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Services.ServiceManager.RunAllService(e.SignalTime);
        }
    }
}


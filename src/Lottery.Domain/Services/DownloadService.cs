using System;
using System.Collections.Generic;
using System.Configuration;

namespace Lottery.Services
{
    using Components;
    using Configuration;
    using Data.SQLServer.Common;
    using Data.SQLServer.D11X5;
    using Downloader;
    using Logging;
    using Model.Common;
    using Model.D11X5;
    using Utils;

    public class DownloadService : IService
    {
        private AsyncEventWorker asyncEventWorker = new AsyncEventWorker();
        private List<Category> categories;

        public DownloadService()
        {
            this.asyncEventWorker.DoWork += new DoWorkEventHandler(asyncEventWorker_DoWork);
            //this.asyncEventWorker.ProgressChanged += new ProgressChangedEventHandler(asyncEventWorker_ProgressChanged);
            //this.asyncEventWorker.Completed += new WorkerCompletedEventHandler(asyncEventWorker_Completed);
            this.categories = CategoryBiz.Instance.GetEnabledCategories();
        }

        public void asyncEventWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            this.StartDown(args.Argument as EventParameter);
        }

        private void asyncEventWorker_Completed(object sender, WorkerCompletedEventArgs args)
        {
        }

        private void asyncEventWorker_ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
        }

        public void Stop()
        {
        }

        public void Refresh()
        {
        }

        public void Start(DateTime currentDateTime)
        {
            if (ConfigHelper.IsAsyncDown)
                this.StartAsync(currentDateTime);
            else
                this.StartSync(currentDateTime);
        }

        public void StartAsync(DateTime currentDateTime)
        {
            foreach (var category in categories)
            {
                //if (!IsUpdateTime(currentDateTime, category.DownIntervals, category.DownPeroid))
                //    continue;

                EventParameter parameter = new EventParameter(category.Type, category.Name, category.DownUrl, category.DbName);
                parameter.StartDate = GetLatestDate(category.DbName);
                parameter.EndDate = DateTime.Now;
                this.asyncEventWorker.RunAsync(Guid.NewGuid().ToString(), parameter);
            }
        }

        public void StartSync(DateTime currentDateTime)
        {
            foreach (var category in categories)
            {
                //if (category.DbName.Equals("Fc3D") || category.DbName.Equals("TcPL35")) continue;
                //if (!IsUpdateTime(currentDateTime, category.DownIntervals, category.DownPeroid))
                //    continue;

                EventParameter parameter = new EventParameter(category.Type, category.Name, category.DownUrl, category.DbName);
                parameter.StartDate = GetLatestDate(category.DbName);
                parameter.EndDate = DateTime.Now;
                this.StartDown(parameter);
            }
        }

        private void StartDown(EventParameter parameter)
        {
            IDownloader downloader = DownloaderFactory.Creator(parameter.Type);
            for (DateTime date = parameter.StartDate; date <= parameter.EndDate; date = date.AddDays(1))
            {
                try
                {
                    DownParameter param = new DownParameter(date, parameter.Name, parameter.DownUrl, parameter.DbName);
                    if (!downloader.Down(param)) break;
                }
                catch (Exception exception)
                {
                    Logger.Instance.Write(string.Format("Name:{0}-{1},Date:{2},Msg:{3}", parameter.Name, parameter.Type, date, exception.ToString()));
                }
            }
        }

        private bool IsUpdateTime(DateTime currentTime,string intervals,string peroid)
        {
            peroid = peroid.Trim().ToLower();
            if (peroid.Equals("m"))
            {
                int interval = ConvertHelper.GetInt32(intervals);
                int minute = currentTime.Minute == 0 ? 60 : currentTime.Minute;
                return (minute % interval == 0 && currentTime.Second == 0);
            }

            if (peroid.Equals("d"))
            {
                return (currentTime.Hour == 23 && currentTime.Minute == 0 && currentTime.Second == 0);
            }

            if (peroid.Equals("w"))
            {
                return (currentTime.Hour == 23 && currentTime.Minute == 0 &&
                    currentTime.Second == 0 && intervals.Contains(((int)currentTime.DayOfWeek).ToString()));
            }

            return false;
        }

        private DateTime GetLatestDate(string dbName)
        {
            return new DwNumberBiz(dbName).GetLatestDate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;

namespace Lottery.Services
{
    using Components;
    using Configuration;
    using Data.Biz.Common;
    using Data.Biz.D11X5;
    using Data.Downloader;
    using Data.Parameter;
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
                if (!IsUpdateTime(currentDateTime, category.DownIntervals, category.DownPeroid)) continue;
                if (this.asyncEventWorker.Exists(category.Code)) continue;

                EventParameter eventParameter = new EventParameter(category);
                this.asyncEventWorker.RunAsync(category.Code, eventParameter);
            }
        }

        public void StartSync(DateTime currentDateTime)
        {
            foreach (var category in categories)
            {
                //if (!IsUpdateTime(currentDateTime, category.DownIntervals, category.DownPeroid))
                //    continue;
                //if (category.Id != 185) continue;
                EventParameter eventParameter = new EventParameter(category);
                this.StartDown(eventParameter);

                Console.WriteLine(string.Format("{0}:Finished", category.DbName));
            }
        }

        private void StartDown(EventParameter eventParameter)
        {
            IDownloader downloader = DownloaderFactory.Creator(eventParameter.Category.DownUrl);
            if (downloader == null) return;

            DownParameter downParameter = new DownParameter(eventParameter.Category);
            downloader.Down(downParameter);
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
                return (intervals.Contains(currentTime.Hour.ToString()) &&
                    currentTime.Minute == 0 &&
                    currentTime.Second == 0);
            }

            if (peroid.Equals("w"))
            {
                return (intervals.Contains(currentTime.Hour.ToString()) && 
                    currentTime.Minute == 0 &&
                    currentTime.Second == 0 && 
                    intervals.Contains(((int)currentTime.DayOfWeek).ToString()));
            }

            return false;
        }
    }
}

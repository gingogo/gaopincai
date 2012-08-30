using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.Statistics
{
    using Data.SQLServer.Common;
    using Model.Common;

    public abstract class BaseStatistics : IStatistics
    {
        private delegate void AsyncStatDelegate(string dbName, OutputType outputType);
        private AsyncStatDelegate asyncStatDlgt;

        protected BaseStatistics()
        {
            this.asyncStatDlgt = new AsyncStatDelegate(this.Stat);
        }

        public virtual void Stat()
        {
            this.Stat(OutputType.Text, true);
        }

        public virtual void Stat(OutputType outputType, bool isAsync)
        {
            List<DmCategory> categories = this.GetCatgories();
            foreach (var category in categories)
            {
                if (isAsync)
                    this.AsyncStatAll(category, outputType);
                else
                    this.SyncStatAll(category, outputType);
            }
        }

        protected virtual void AsyncStatAll(DmCategory category, OutputType outputType)
        {
            this.asyncStatDlgt.BeginInvoke(category.DbName, outputType, null, null);
        }

        protected virtual void SyncStatAll(DmCategory category, OutputType outputType)
        {
            this.Stat(category.DbName, outputType);
        }

        protected virtual string GetOutputFileName(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stat");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return string.Format("{0}\\{1}", path, fileName);
        }

        protected virtual void Stat(string dbName,OutputType outputType)
        {
        }

        protected abstract List<DmCategory> GetCatgories();
    }

    public enum OutputType
    {
        Text,
        Database
    }
}

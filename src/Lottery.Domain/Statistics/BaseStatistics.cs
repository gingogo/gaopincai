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
        private delegate void AsyncStatDelegate(string dbName);

        private AsyncStatDelegate asyncStatDlgt;

        protected BaseStatistics()
        {
            this.asyncStatDlgt = new AsyncStatDelegate(this.Stat);
        }

        public virtual void Stat()
        {
            this.Stat(true);
        }

        public virtual void Stat(bool isAsync)
        {
            List<Category> categories = this.GetCatgories();
            foreach (var category in categories)
            {
                if (isAsync)
                    this.AsyncStatAll(category);
                else
                    this.SyncStatAll(category);
            }
        }

        protected virtual void AsyncStatAll(Category category)
        {
            this.asyncStatDlgt.BeginInvoke(category.DbName, null, null);
        }

        protected virtual void SyncStatAll(Category category)
        {
            this.Stat(category.DbName);
        }

        protected abstract void Stat(string dbName);

        protected abstract List<Category> GetCatgories();
    }
}

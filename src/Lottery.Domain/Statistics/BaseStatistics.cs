using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Lottery.Statistics
{
    using Data.SQLServer.Common;
    using Model.Common;

    public abstract class BaseStatistics : IStatistics
    {
        protected BaseStatistics()
        {
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
                    this.AsyncStatAll(category);
                else
                    this.SyncStatAll(category);
            }
        }

        protected virtual void AsyncStatAll(DmCategory category)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(this.Stat));
            thread.Start(category.DbName);
        }

        protected virtual void SyncStatAll(DmCategory category)
        {
            this.Stat(category.DbName);
        }

        protected virtual void Stat(object dbName)
        {
            throw new NotImplementedException();
        }

        protected abstract List<DmCategory> GetCatgories();
    }

    public enum OutputType
    {
        Text,
        Database
    }
}

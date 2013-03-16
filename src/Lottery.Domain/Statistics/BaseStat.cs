using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lottery.Statistics
{
	using Data.Biz.Common;
	using Model.Common;

	public abstract class BaseStat : IStat
	{
		private delegate void AsyncStatDelegate(string dbName,bool isReset);

		private AsyncStatDelegate asyncStatDlgt;

		protected BaseStat()
		{
			this.asyncStatDlgt = new AsyncStatDelegate(this.Stat);
		}

		public virtual void Stat()
		{
			this.Stat(false);
		}

		public virtual void Stat(bool isReset)
		{
			this.Stat(false,false);
		}
		
		public virtual void Stat(bool isAsync,bool isReset)
		{
			List<Category> categories = this.GetCatgories();
			foreach (var category in categories)
			{
				if (isAsync)
					this.asyncStatDlgt.BeginInvoke(category.DbName,isReset,null, null);
				else
					this.Stat(category.DbName,isReset);
			}
		}

		protected abstract void Stat(string dbName,bool isReset);

		protected abstract List<Category> GetCatgories();
	}
}

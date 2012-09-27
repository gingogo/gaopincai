using System.Net;

namespace Lottery.Data.Downloader
{
    using Parameter;

    public abstract class BaseDownloader
    {
        protected WebClient _webClient = new WebClient();

        protected BaseDownloader()
        {
        }

        public virtual bool Down(DownParameter param)
        {
            string type = param.Category.Type.ToLower();

            if (type.Equals("11x5")) return this.Down11X5(param);
            if (type.Equals("ssc")) return this.DownSSC(param);
            if (type.Equals("3d")) return this.Down3D(param);
            if (type.Equals("pl35")) return this.DownPL35(param);
            if (type.Equals("ssl")) return this.DownSSL(param);

            return false;
        }

        protected virtual bool Down11X5(DownParameter param)
        {
            return false;
        }

        protected virtual bool DownSSC(DownParameter param)
        {
            return false;
        }

        protected virtual bool Down3D(DownParameter param)
        {
            return false;
        }

        protected virtual bool DownPL35(DownParameter param)
        {
            return false;
        }

        protected virtual bool DownSSL(DownParameter param)
        {
            return false;
        }
    }
}


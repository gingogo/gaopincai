using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Services
{
    public class ServiceManager
    {
        private static List<IService> _services;

        static ServiceManager()
        {
            _services = new List<IService>(2);
            _services.Add(new DownloadService());
            _services.Add(new CategoryService());
        }

        public static void RunAllService(DateTime currentDateTime)
        {
            _services.ForEach(x => x.Start(currentDateTime));
        }
    }
}

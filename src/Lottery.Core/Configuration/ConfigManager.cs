using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lottery.Configuration
{
    public class ConfigManager
    {
        private static readonly string dataSourceSectionName = "dataSourceSection";

        private static DataSourceSection dataSourceSection;

        static ConfigManager()
        {
            LoadConfigSection();
        }

        public static DataSourceSection DataSourceSection
        {
            get { return dataSourceSection; }
        }

        private static void LoadConfigSection()
        {
            try
            {
                dataSourceSection = (DataSourceSection)ConfigurationManager.GetSection(dataSourceSectionName);
            }
            catch (Exception ex)
            {
                throw new ConfigurationErrorsException("加载配置文件出错", ex);
            }
        }
    }
}

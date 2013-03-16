using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lottery.Configuration
{
    public class DatabaseElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public String Name
        {
            get { return base["name"].ToString(); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("namespace", IsRequired = true)]
        public String Namespace
        {
            get { return base["namespace"].ToString(); }
            set { base["namespace"] = value; }
        }

        [ConfigurationProperty("connectionString", IsRequired = true)]
        public String ConnectionString
        {
            get { return base["connectionString"].ToString(); }
            set { base["connectionString"] = value; }
        }
    }
}

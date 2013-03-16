using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lottery.Configuration
{
    public class DataSourceElement : ConfigurationElement
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

        [ConfigurationProperty("assembly", IsRequired = true)]
        public String Assembly
        {
            get { return base["assembly"].ToString(); }
            set { base["assembly"] = value; }
        }
        
        [ConfigurationProperty("databases", IsRequired = true)]
        public DatabaseElementCollection Databases
        {
            get { return (DatabaseElementCollection)base["databases"]; }
        }
    }
}

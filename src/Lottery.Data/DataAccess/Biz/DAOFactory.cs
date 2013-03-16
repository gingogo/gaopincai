using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace Lottery.Data.Biz
{
    using Configuration;

    public class DAOFactory
    {
        public static T Create<T>(string dbName)
        {
            return Create<T>(dbName, string.Empty);
        }

        public static T Create<T>(string dbName, string tableName)
        {
            string typeName = typeof(T).Name.Substring(1);
            return CreateInstance<T>(dbName, typeName, tableName);
        }

        public static T CreateInstance<T>(string dbName, string typeName)
        {
            return CreateInstance<T>(dbName, typeName, string.Empty);
        }

        public static T CreateInstance<T>(string dbName, string typeName, string tableName)
        {
            dbName = dbName.Trim().ToLower();
            string dataSourceName = ConfigHelper.GetAppSettings("dataSource");
            DataSourceElement config = ConfigManager.DataSourceSection.DataSources[dataSourceName];
            var dbNamespace = config.Databases[dbName].Namespace;
            var connectionString = config.Databases[dbName].ConnectionString;
            var fullTypeName = string.Format("{0}.{1}.{2},{3}", config.Namespace, dbNamespace, typeName, config.Assembly);

            object[] args = string.IsNullOrEmpty(tableName) ? 
                new object[] { connectionString } : 
                new object[] { tableName, connectionString };
            return (T)Activator.CreateInstance(Type.GetType(fullTypeName), args);
        }
    }
}

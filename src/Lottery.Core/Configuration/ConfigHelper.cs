using System.Configuration;

namespace Lottery.Configuration
{
    public class ConfigHelper
    {
        public static string CommonDBName
        {
            get { return GetAppSettings("commonDB"); }
        }

        public static string CommonTableConnString
        {
            get { return GetConnString(GetAppSettings("commonTable")); }
        }

        public static string D11x5DmTableConnStringName
        {
            get { return GetAppSettings("11x5DmTable"); }
        }

        public static string SSCDmTableConnStringName
        {
            get { return GetAppSettings("sscDmTable"); }
        }

        public static string D3DmTableConnStringName
        {
            get { return GetAppSettings("3dDmTable"); }
        }

        public static string SSLDmTableConnStringName
        {
            get { return GetAppSettings("sslDmTable"); }
        }

        public static string PL35DmTableConnStringName
        {
            get { return GetAppSettings("pl35DmTable"); }
        }

        public static string GetConnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name.Trim().ToLower()].ConnectionString; 
        }

        public static bool IsAsyncDown
        {
            get { return bool.Parse(GetAppSettings("isAsyncDown")); }
        }

        public static string GetDmTableName(string tableName)
        {
            return string.Format("Dm{0}", tableName);
        }

        public static string GetStCycleTableName(string tableName)
        {
            return string.Format("St{0}Cycle", tableName);
        }

        public static string GetDwSpanTableName(string tableName)
        {
            return string.Format("Dw{0}Span", tableName);
        }

        public static string GetAppSettings(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}

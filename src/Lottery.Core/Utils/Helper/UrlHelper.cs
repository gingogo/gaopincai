using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Lottery.Utils
{
    public class UrlHelper
    {
        private UrlHelper()
        {
        }

        public static string EnsureTrailingSlash(string stringThatNeedsTrailingSlash)
        {
            if (!stringThatNeedsTrailingSlash.EndsWith("/"))
            {
                return (stringThatNeedsTrailingSlash + "/");
            }
            return stringThatNeedsTrailingSlash;
        }

        public static string GetApplicationPath()
        {
            return EnsureTrailingSlash(HttpContext.Current.Request.ApplicationPath);
        }

        public static string GetHostUrl()
        {
            string str = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
            string str2 = ((str == null) || (str == "0")) ? "http" : "https";
            string str3 = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            string str4 = (str3 == "80") ? string.Empty : (":" + str3);
            string str5 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
            return string.Format("{0}://{1}{2}", str2, str5, str4);
        }

        public static string[] GetParamsFromPathInfo(string pathInfo)
        {
            if (pathInfo.Length > 0)
            {
                if (pathInfo.EndsWith("/"))
                {
                    pathInfo = pathInfo.Substring(0, pathInfo.Length - 1);
                }
                pathInfo = pathInfo.Substring(1, pathInfo.Length - 1);
                return pathInfo.Split(new char[] { '/' });
            }
            return null;
        }

        public static string GetSiteUrl()
        {
            string applicationPath = HttpContext.Current.Request.ApplicationPath;
            if (applicationPath.EndsWith("/") && (applicationPath.Length == 1))
            {
                return GetHostUrl();
            }
            return (GetHostUrl() + applicationPath.ToLower());
        }

        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }
    }
}


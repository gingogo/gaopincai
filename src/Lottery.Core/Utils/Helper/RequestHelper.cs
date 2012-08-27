using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace Lottery.Utils
{
    public class RequestHelper
    {
        public static void Filter(NameValueCollection nvc)
        {
            foreach (string str in nvc.AllKeys)
            {
                StringHelper.SqlFilter(nvc[str]);
            }
        }

        public static string GetCurrentFullHost()
        {
            HttpRequest request = HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
            {
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            return request.Url.Host;
        }

        public static string GetFilterQueryString(string queryItem, string defaultValue)
        {
            string str = StringHelper.SqlFilter(GetQueryString(queryItem));
            if (string.IsNullOrEmpty(str))
            {
                return defaultValue;
            }
            return str;
        }

        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            return GetQueryFloat(strName, defValue);
        }

        public static string GetFormFilterString(string queryItem, string defaultValue)
        {
            return StringHelper.SqlFilter(GetFormString(queryItem));
        }

        public static float GetFormFloat(string strName, float defValue)
        {
            float result = defValue;
            float.TryParse(HttpContext.Current.Request.Form[strName], out result);
            return result;
        }

        public static int GetFormInt(string strName, int defValue)
        {
            int result = defValue;
            int.TryParse(HttpContext.Current.Request.Form[strName], out result);
            return result;
        }

        public static string GetFormString(string queryItem)
        {
            string str = HttpContext.Current.Request.Form[queryItem];
            if (str == null)
            {
                return "";
            }
            return str;
        }

        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            return GetQueryInt(strName, defValue);
        }

        public static string GetIP()
        {
            string userHostAddress = string.Empty;
            userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }
            if (!(!string.IsNullOrEmpty(userHostAddress) && UrlHelper.IsIP(userHostAddress)))
            {
                return "127.0.0.1";
            }
            return userHostAddress;
        }

        public static string GetPageName()
        {
            string[] strArray = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].ToLower();
        }

        public static int GetParamCount()
        {
            return (HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count);
        }

        public static float GetQueryFloat(string strName, float defValue)
        {
            float result = defValue;
            float.TryParse(HttpContext.Current.Request.QueryString[strName], out result);
            return result;
        }

        public static int GetQueryInt(string strName, int defValue)
        {
            int result = defValue;
            int.TryParse(HttpContext.Current.Request.QueryString[strName], out result);
            return result;
        }

        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }

        public static string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return "";
            }
            if (!(!sqlSafeCheck || StringHelper.IsSafeSqlString(HttpContext.Current.Request.QueryString[strName])))
            {
                return "unsafe string";
            }
            return HttpContext.Current.Request.QueryString[strName];
        }

        public static string GetQueryStringByCode(string strName)
        {
            return GetQueryStringByCode(strName, Encoding.UTF8);
        }

        public static string GetQueryStringByCode(string strName, Encoding encode)
        {
            NameValueCollection values = HttpUtility.ParseQueryString(HttpContext.Current.Request.Url.Query, encode);
            if (values[strName] == null)
            {
                return "";
            }
            return values[strName];
        }

        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        public static string GetReturnUrl()
        {
            return GetReturnUrl("/");
        }

        public static string GetReturnUrl(string defaultUrl)
        {
            string str = HttpContext.Current.Request.QueryString["returnurl"];
            if (string.IsNullOrEmpty(str))
            {
                str = defaultUrl;
            }
            return str;
        }

        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }

        public static string GetString(string strName)
        {
            if (GetQueryString(strName) == "")
            {
                return GetFormString(strName);
            }
            return GetQueryString(strName);
        }

        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        public static string GetUrlReferrer()
        {
            string str = null;
            try
            {
                str = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch
            {
            }
            if (str == null)
            {
                return "";
            }
            return str;
        }

        public static bool IsBrowserGet()
        {
            string[] strArray = new string[] { "ie", "opera", "netscape", "mozilla", "konqueror", "firefox" };
            string str = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str.IndexOf(strArray[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsEmpty(NameValueCollection nvc, params string[] keys)
        {
            if ((((nvc == null) || (nvc.Count == 0)) || (keys == null)) || (keys.Length == 0))
            {
                return true;
            }
            foreach (string str in keys)
            {
                if (string.IsNullOrEmpty(nvc[str]) || (nvc[str].Trim().Length == 0))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        public static bool IsSearchEnginesGet()
        {
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                string[] strArray = new string[] { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou" };
                string str = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str.IndexOf(strArray[i]) >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void RedirectFromPage(string defaultUrl)
        {
            RedirectFromPage("ReturnUrl", defaultUrl);
        }

        public static void RedirectFromPage(string paramName, string defaultUrl)
        {
            string str = HttpContext.Current.Request.QueryString[paramName];
            if (string.IsNullOrEmpty(str))
            {
                str = defaultUrl;
            }
            HttpContext.Current.Response.Redirect(str, true);
        }

        public static int RequestFormInt32(string queryItem, int defaultValue)
        {
            int num;
            queryItem = HttpContext.Current.Request.Form[queryItem];
            if (!int.TryParse(queryItem, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static double RequestFormSingle(string queryItem, double defaultValue)
        {
            double num;
            queryItem = HttpContext.Current.Request.Form[queryItem];
            if (!double.TryParse(queryItem, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static int RequestInt32(string queryItem, int defaultValue)
        {
            int num;
            queryItem = HttpContext.Current.Request.QueryString[queryItem];
            if (!int.TryParse(queryItem, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static double RequestSingle(string queryItem, double defaultValue)
        {
            double num;
            queryItem = HttpContext.Current.Request.QueryString[queryItem];
            if (!double.TryParse(queryItem, out num))
            {
                num = defaultValue;
            }
            return num;
        }

        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
    }
}


using System;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Lottery.Utils
{
    public static class StringHelper
    {
        public static string AddZeroToStr(int str, int length)
        {
            string str2 = str.ToString();
            for (int i = 0; i < (length - str.ToString().Length); i++)
            {
                str2 = "0" + str2;
            }
            return str2;
        }

        public static string[] BubbleSort(string[] r)
        {
            for (int i = 0; i < r.Length; i++)
            {
                bool flag = false;
                for (int j = r.Length - 2; j >= i; j--)
                {
                    if (string.CompareOrdinal(r[j + 1], r[j]) < 0)
                    {
                        string str = r[j + 1];
                        r[j + 1] = r[j];
                        r[j] = str;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return r;
                }
            }
            return r;
        }

        public static bool CheckDropDownList(string value)
        {
            return ((value.IndexOf("请选择") == -1) && (value.IndexOf("请先选择") == -1));
        }

        public static bool CheckNullOrEmptyString(string str)
        {
            return (string.IsNullOrEmpty(str) || (str.Trim().Length == 0));
        }

        public static string CollectionFilter(string conStr, string tagName, int fType)
        {
            string input = conStr;
            switch (fType)
            {
                case 1:
                    return Regex.Replace(input, "<" + tagName + "([^>])*>", "", RegexOptions.IgnoreCase);

                case 2:
                    return Regex.Replace(input, "<" + tagName + "([^>])*>.*?</" + tagName + "([^>])*>", "", RegexOptions.IgnoreCase);

                case 3:
                    return Regex.Replace(Regex.Replace(input, "<" + tagName + "([^>])*>", "", RegexOptions.IgnoreCase), "</" + tagName + "([^>])*>", "", RegexOptions.IgnoreCase);
            }
            return input;
        }

        public static string ConvertToJavaScript(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("\n", @"\n");
            str = str.Replace("\r", @"\r");
            str = str.Replace("\"", "\\\"");
            return str;
        }

        public static int CountSplitNum(string str)
        {
            int length = 0;
            if (str.StartsWith("|") && str.EndsWith("|"))
            {
                length = str.Trim().TrimEnd(new char[] { '|' }).TrimStart(new char[] { '|' }).Split(new char[] { '|' }).Length;
            }
            return length;
        }

        public static string CutString(string str, int length)
        {
            return CutString(str, length, "");
        }

        public static string CutString(string _FullStr, int _Length, string _EndStr)
        {
            if (Encoding.Default.GetBytes(_FullStr).Length <= _Length)
            {
                return _FullStr;
            }
            ASCIIEncoding encoding = new ASCIIEncoding();
            _Length -= Encoding.Default.GetBytes(_EndStr).Length;
            int num = 0;
            StringBuilder builder = new StringBuilder();
            byte[] bytes = encoding.GetBytes(_FullStr);
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x3f)
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
                if (num > _Length)
                {
                    break;
                }
                builder.Append(_FullStr.Substring(i, 1));
            }
            builder.Append(_EndStr);
            return builder.ToString();
        }

        public static string DropHTML(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml))
            {
                return "";
            }
            return Regex.Replace(RemoveHtml(strHtml).Replace("<", "").Replace(">", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\t", ""), "(&\\w+;)|(\r\n)|\r|\n|>|<|\t", "");
        }

        public static string FileterSpec(string htmlCode)
        {
            string str = htmlCode;
            foreach (Match match in Regex.Matches(htmlCode, "&.+?;"))
            {
                str = str.Replace(match.Value, "");
            }
            return str;
        }

        public static string FilterA(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<.?a(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FilterDiv(string htmlCode)
        {
            string str = htmlCode;
            return Regex.Replace(htmlCode, "<.?div(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FilterFont(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<.?font(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FilterHtml(string htmlCode)
        {
            string str = htmlCode;
            foreach (Match match in Regex.Matches(htmlCode, "<(.|\n)+?>"))
            {
                str = str.Replace(match.Value, "");
            }
            return str;
        }

        public static string FilterIFrame(string htmlCode)
        {
            string pattern = @"<iframe((?:.|\n)*?)</iframe>";
            MatchCollection matchs = Regex.Matches(htmlCode, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                htmlCode = htmlCode.Replace(match.Value, "");
            }
            return htmlCode;
        }

        public static string FilterImg(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(input, "<img(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FilterObject(string htmlCode)
        {
            string pattern = @"<object((?:.|\n)*?)</object>";
            string oldValue = string.Empty;
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                oldValue = match.Value;
                htmlCode = htmlCode.Replace(oldValue, "");
            }
            return htmlCode;
        }

        public static string FilterScript(string htmlCode)
        {
            string pattern = @"<script((?:.|\n)*?)</script>";
            MatchCollection matchs = Regex.Matches(htmlCode, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matchs)
            {
                htmlCode = htmlCode.Replace(match.Value, "");
            }
            return htmlCode;
        }

        public static string FilterScript(string conStr, string filterItem)
        {
            string str = conStr.Replace("\r", "{$Chr13}").Replace("\n", "{$Chr10}");
            foreach (string str2 in filterItem.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                switch (str2)
                {
                    case "Iframe":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Object":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Script":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Style":
                        str = CollectionFilter(str, str2, 2);
                        break;

                    case "Div":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Span":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Table":
                        str = CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(str, str2, 3), "Tbody", 3), "Tr", 3), "Td", 3), "Th", 3);
                        break;

                    case "Img":
                        str = CollectionFilter(str, str2, 1);
                        break;

                    case "Font":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "A":
                        str = CollectionFilter(str, str2, 3);
                        break;

                    case "Html":
                        str = StripTags(str);
                        goto Label_0202;
                }
            }
        Label_0202:
            return str.Replace("{$Chr13}", "\r").Replace("{$Chr10}", "\n");
        }

        public static string FilterSpan(string htmlCode)
        {
            string str = htmlCode;
            return Regex.Replace(htmlCode, "<.?span(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FilterStyle(string htmlCode)
        {
            string pattern = @"<style((?:.|\n)*?)</style>";
            string oldValue = string.Empty;
            Match match = new Regex(pattern, RegexOptions.IgnoreCase).Match(htmlCode);
            if (match.Success)
            {
                oldValue = match.Value;
                htmlCode = htmlCode.Replace(oldValue, "");
            }
            return htmlCode;
        }

        public static string FilterTableProtery(string htmlCode)
        {
            string input = htmlCode;
            return Regex.Replace(Regex.Replace(Regex.Replace(input, "<.?table(.|\n)*?>", "", RegexOptions.IgnoreCase), "<.?tr(.|\n)*?>", "", RegexOptions.IgnoreCase), "<.?td(.|\n)*?>", "", RegexOptions.IgnoreCase);
        }

        public static string FormatWord(int index)
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (index > str.Length)
            {
                return index.ToString();
            }
            char ch = str[index - 1];
            return ch.ToString();
        }

        public static string GenRnd(int len)
        {
            if ((len < 1) || (len > 15))
            {
                len = 5;
            }
            Random random = new Random();
            string str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                builder.Append(str.Substring(random.Next(0, str.Length - 1), 1));
            }
            return builder.ToString();
        }

        public static string[] GetArrByReg(string strSrc)
        {
            return strSrc.Split(new string[] { @"([\s\S]*?)" }, StringSplitOptions.None);
        }

        public static string GetDateString(DateTime dt)
        {
            return string.Format("{0}-{1}-{2}", dt.Year.ToString("D4"), dt.Month.ToString("D2"), dt.Day.ToString("D2"));
        }

        public static string GetDateTimeStr()
        {
            DateTime now = DateTime.Now;
            return string.Concat(new object[] { now.Year, AddZeroToStr(now.Month, 2), AddZeroToStr(now.Day, 2), AddZeroToStr(now.Hour, 2), AddZeroToStr(now.Minute, 2), AddZeroToStr(now.Second, 2) });
        }

        public static string GetFilterWords(string strContent, string strFilter)
        {
            return GetFilterWords(strContent, strFilter, "**");
        }

        public static string GetFilterWords(string strContent, string strFilter, string strReplace)
        {
            return Regex.Replace(strContent, strFilter, strReplace);
        }

        public static string GetFullyFormat16Decimal(string value, int totalLength)
        {
            int num = totalLength - value.Length;
            for (int i = 0; i < num; i++)
            {
                value = "0" + value;
            }
            return value;
        }

        public static string GetHtmlCode(string urlStr, string charSet)
        {
            try
            {
                string str = string.Empty;
                WebClient client = new WebClient {
                    Encoding = Encoding.GetEncoding(charSet)
                };
                client.Headers["Referer"] = new Uri(urlStr).Host;
                byte[] bytes = client.DownloadData(urlStr);
                try
                {
                    str = Encoding.GetEncoding(charSet).GetString(bytes);
                }
                catch
                {
                }
                return str;
            }
            catch
            {
                return "";
            }
        }

        public static string getInputTxt(string txt)
        {
            txt = FilterHtml(txt);
            txt = txt.Replace("'", "").Replace("-", "").Replace(".", "").Replace(@"\", "").Replace(";", "").Replace(":", "").Replace("\"", "").Replace("%", "").Replace("<", "").Replace(">", "").Replace("《", "").Replace("》", "").Replace(" ", "").Replace("*", "").Replace("@", "").Trim();
            return txt;
        }

        public static string getInputUrl(string txt)
        {
            return txt.Replace("'", "").Replace("-", "").Replace(@"\", "").Replace(";", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("《", "").Replace("》", "").Replace(" ", "").Trim();
        }

        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            strPath = strPath.Replace("/", @"\");
            strPath = strPath.TrimStart(new char[] { '\\' });
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        public static string GetMatchContentFilterPattern(string input, string pattern)
        {
            string str = "";
            Regex regex = new Regex(pattern);
            string[] arrByReg = GetArrByReg(pattern);
            string str2 = Regex.Match(input, pattern).Value;
            if (str2 != "")
            {
                str2 = str2.Substring(arrByReg[0].Length);
                str2 = str2.Substring(0, str2.Length - arrByReg[1].Length);
            }
            return (str + str2);
        }

        public static string GetShortDateAuto(string datetime)
        {
            DateTime time = Convert.ToDateTime(datetime);
            string str = string.Concat(new object[] { time.Year, "-", time.Month, "-", time.Day });
            TimeSpan span = (TimeSpan) (DateTime.Now - time);
            if (span.Days < 1)
            {
                if (span.Hours < 1)
                {
                    return (span.Minutes + "分钟");
                }
                if (span.Hours < 0x18)
                {
                    str = span.Hours + "小时";
                }
                return str;
            }
            return time.ToString("yy-MM-dd");
        }

        public static string GetshortDateChina(string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
            {
                return "";
            }
            DateTime time = Convert.ToDateTime(datetime);
            return string.Concat(new object[] { time.Year, "年", time.Month, "月", time.Day, "日 ", time.Hour, ":", time.Minute });
        }

        public static string GetShortDateChinaString(string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
            {
                return "";
            }
            DateTime time = Convert.ToDateTime(datetime);
            return string.Concat(new object[] { time.Year, "年", time.Month, "月", time.Day, "日 " });
        }

        public static string GetShortDateMonthDay(DateTime dt)
        {
            return string.Concat(new object[] { dt.Month, "月", dt.Day, "日" });
        }

        public static string GetShortDateMonthDay(DateTime dt, string separator)
        {
            return (dt.Month + separator + dt.Day);
        }

        public static string GetShortDateWithYear(string datetime)
        {
            try
            {
                return Convert.ToDateTime(datetime).ToString("yyyy-MM-dd");
            }
            catch
            {
                return "";
            }
        }

        public static string GetShortstring(string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            int num = 0;
            int num2 = 0;
            while (num < str.Length)
            {
                if (Convert.ToInt32(str[num]) > 0x80)
                {
                    if ((num2 + 2) > length)
                    {
                        return (str.Substring(0, num - 1) + "…");
                    }
                    num2 += 2;
                }
                else if ((num2 + 1) <= length)
                {
                    num2++;
                }
                else
                {
                    return (str.Substring(0, num) + "…");
                }
                num++;
            }
            return str;
        }

        public static string GetShortstring(string str, string length)
        {
            if (string.IsNullOrEmpty(length))
            {
                return str;
            }
            return GetShortstring(str, Convert.ToInt32(length));
        }

        public static string GetSubString(object obj, int length)
        {
            return GetSubString(obj, length, "");
        }

        public static string GetSubString(object obj, int length, string end)
        {
            if (obj == null)
            {
                return "";
            }
            string str = obj.ToString();
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            int num = 0;
            int num2 = 0;
            while (num < str.Length)
            {
                if (Convert.ToInt32(str[num]) > 0x80)
                {
                    if ((num2 + 2) > length)
                    {
                        return (str.Substring(0, num - 1) + end);
                    }
                    num2 += 2;
                }
                else if ((num2 + 1) <= length)
                {
                    num2++;
                }
                else
                {
                    return (str.Substring(0, num) + end);
                }
                num++;
            }
            return str;
        }

        public static string[] GetUnique(string[] strArr)
        {
            NameValueCollection values = new NameValueCollection();
            foreach (string str in strArr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    values[str] = str;
                }
            }
            return values.AllKeys;
        }

        public static string GetUniqueStr(string[] strArr)
        {
            NameValueCollection values = new NameValueCollection();
            string str = "|";
            foreach (string str2 in strArr)
            {
                if (!string.IsNullOrEmpty(str2))
                {
                    values[str2] = str2;
                }
            }
            for (int i = 0; i < values.AllKeys.Length; i++)
            {
                str = str + values.AllKeys[i] + "|";
            }
            return str;
        }

        public static string GetUrl(string queryName, string queryValue)
        {
            queryValue = HttpContext.Current.Server.UrlEncode(queryValue);
            string input = HttpContext.Current.Request.RawUrl.ToLower();
            if (input.IndexOf("?") == -1)
            {
                input = input + "?";
            }
            if (input.IndexOf(queryName + "=") >= 0)
            {
                return Regex.Replace(input, "(&?)" + queryName + @"=([\w%]){0,}", "&" + queryName + "=" + queryValue);
            }
            string str3 = input;
            return (str3 + "&" + queryName + "=" + queryValue);
        }

        public static string GetWeek(DateTime dt)
        {
            CultureInfo info = new CultureInfo("zh-CN");
            return ("星期" + info.DateTimeFormat.GetAbbreviatedDayName(dt.DayOfWeek).ToString());
        }

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
        }

        public static int MockInt(int _RealInt, DateTime _StartTime, DateTime _StopTime, int _K, int Seed)
        {
            int num = Seed;
            double num2 = 0.314;
            int num3 = (int) Math.Floor((double) (((num * num2) - Math.Floor((double) (num * num2))) * 10.0));
            num3 = (num3 < 0) ? 3 : num3;
            TimeSpan span = (TimeSpan) (_StopTime.Date - _StartTime.Date);
            int num4 = (span.Days < 0) ? 0 : span.Days;
            int num5 = num3 * _K;
            double num6 = 8.6;
            int num7 = (int) Math.Floor((double) (_StopTime.Day * num6));
            int num8 = 0;
            for (DateTime time = _StartTime.AddDays(-1.0); time.AddDays(1.0) <= _StopTime; time = time.AddDays(1.0))
            {
                num8 += (int) Math.Floor((double) (time.Day * num6));
            }
            int num9 = (int) Math.Floor((double) (((num5 + num7) / 0x18) * DateTime.Now.Hour));
            int num10 = ((num5 + num7) + _RealInt) - num9;
            return ((((num5 * num4) + _RealInt) + num8) - num10);
        }

        public static string RemoveHtml(string htmlCode)
        {
            string str = htmlCode;
            foreach (Match match in Regex.Matches(htmlCode, "<.+?>"))
            {
                str = str.Replace(match.Value, "");
            }
            return str;
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!string.IsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                {
                    return new string[] { strContent };
                }
                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            return new string[0];
        }

        public static string SqlFilter(string Contents)
        {
            string pattern = "exec|insert|select|delete|'|update|chr|mid|master|truncate|char|declare|and|--";
            if (Regex.IsMatch(Contents.ToLower(), pattern, RegexOptions.IgnoreCase))
            {
                Contents = Regex.Replace(Contents.ToLower(), pattern, " ", RegexOptions.IgnoreCase);
            }
            return Contents;
        }

        public static string SqlReplace(string Contents)
        {
            Contents = Contents.Replace("'", "''").Replace("%", "[%]").Replace("-", "[-]");
            return Contents;
        }

        public static string StripTags(string input)
        {
            Regex regex = new Regex("<([^<]|\n)+?>");
            return regex.Replace(input, "");
        }

        public static string SubString(string str, int length)
        {
            if (string.IsNullOrEmpty(str) || (str.Trim().Length == 0))
            {
                return string.Empty;
            }
            if (str.Length < length)
            {
                return str;
            }
            return str.Substring(0, length);
        }

        public static string SuperiorHtml(string htmlCode, string pattern)
        {
            return Regex.Replace(htmlCode, pattern, "", RegexOptions.IgnoreCase);
        }

        public static string ToDBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 0xff00) && (chArray[i] < 0xff5f))
                {
                    chArray[i] = (char) (chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        public static string XmlEncode(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace("&", "&amp;");
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace("'", "&apos;");
                str = str.Replace("\"", "&quot;");
            }
            return str;
        }
    }
}


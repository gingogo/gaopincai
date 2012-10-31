using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Utils
{
    public static class NumberAttributeExtension
    {
        /// <summary>
        /// 把以英文逗号分隔的数字字符串转换成整型List集合
        /// </summary>
        /// <param name="str">英文逗号分隔的数字字符串</param>
        /// <returns>List集合</returns>
        public static List<int> ToList(this string str)
        {
            return str.ToList(',');
        }

        /// <summary>
        /// 把以某字符分隔的数字字符串转换成整型List集合
        /// </summary>
        /// <param name="str">英文逗号分隔的数字字符串</param>
        /// <param name="separator">分隔字符</param>
        /// <returns>List集合</returns>
        public static List<int> ToList(this string str, char separator)
        {
            string[] arr = str.Split(separator);
            List<int> digits = new List<int>();
            foreach (string e in arr)
                digits.Add(int.Parse(e));
            return digits;
        }

        /// <summary>
        /// 把数字集合转换成指定分隔符连接的字符串。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<int> digits)
        {
            return string.Join(string.Empty, digits.ToArray());
        }

        /// <summary>
        /// 把数字集合转换成指定分隔符连接的字符串。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <param name="sepertor">分隔字符</param>
        /// <returns></returns>
        public static string ToString(this IEnumerable<int> digits,string separator)
        {
            return string.Join(separator, digits.ToArray());
        }

        /// <summary>
        /// 把数字字符串按指定长度进行英文逗号分隔。
        /// </summary>
        /// <param name="obj">字符串对象</param>
        /// <param name="len">分隔后每个组的长度</param>
        /// <returns></returns>
        public static string ToString(this object obj, int len)
        {
            return obj.ToString(len, ",");
        }

        /// <summary>
        /// 把数字字符串按指定长度进行分隔。
        /// </summary>
        /// <param name="obj">字符串对象</param>
        /// <param name="length">分隔后每个组的长度</param>
        /// <param name="separator">分隔字符</param>
        /// <returns></returns>
        public static string ToString(this object obj,int length, string separator)
        {
            string str = obj.ToString();
            return ToString(str, length, separator);
        }

        /// <summary>
        /// 把数字字符串按指定长度进行分隔。
        /// </summary>
        /// <param name="str">字符串对象</param>
        /// <param name="length">分隔后每个组的长度</param>
        /// <param name="separator">分隔字符</param>
        /// <returns></returns>
        public static string ToString(this string str, int length, string separator)
        {
            if (length == 1)
                return string.Join(separator, str.ToArray());

            if (str.Length <= length) return str;

            List<string> list = new List<string>(5);
            for (int i = 0; i < str.Length; i += length)
            {
                list.Add(str.Substring(i, length));
            }

            return string.Join(separator, list.ToArray());
        }

        /// <summary>
        /// 把数字集合格式化成D2格式的字符串。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns></returns>
        public static string Format(this IEnumerable<int> digits)
        {
            return digits.Format("D2", string.Empty);
        }

        /// <summary>
        /// 把数字集合格式化成D2格式的字符串。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string Format(this IEnumerable<int> digits, string separator)
        {
            return digits.Format("D2", separator);
        }

        /// <summary>
        /// 把数字集合格式化成指定格式的字符串
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <param name="format">格式化分格</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string Format(this IEnumerable<int> digits, string format, string separator)
        {
            return string.Join(separator, digits.Select(x => x.ToString(format)).ToArray());
        }

        /// <summary>
        /// 把数字指定分格的字符串。
        /// </summary>
        /// <param name="num">数字</param>
        /// <param name="format">格式化分格</param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string Format(this int num, string format, string separator)
        {
            return string.Join(separator, num.ToString(format).ToArray());
        }

        /// <summary>
        /// 获取号码的尾数。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>最后一个字符</returns>
        public static int GetWei(this int number)
        {
            return number.ToString().GetWei();
        }

        /// <summary>
        /// 获取号码的尾数。
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>最后一个字符</returns>
        public static int GetWei(this string str)
        {
            int index = str.Length - 1;
            return int.Parse(str.Substring(index));
        }

        /// <summary>
        /// 获取号码的质合，1表示质数，0表示合数
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>1|0</returns>
        public static string GetZiHe(this IEnumerable<int> digits)
        {
            List<string> result = new List<string>(digits.Count());
            foreach (int e in digits)
            {
                result.Add((
                    e == 0 ||
                    e == 4 ||
                    e == 6 ||
                    e == 8 ||
                    e == 9 ||
                    e == 10 ||
                    e == 12) ? "0" : "1");
            }
            return string.Join("|", result.ToArray());
        }

        /// <summary>
        /// 获取号码的除3余数
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>0|1|2</returns>
        public static string GetLu012(this IEnumerable<int> digits)
        {
            List<string> result = new List<string>(digits.Count());
            foreach (int e in digits)
            {
                result.Add((e % 3).ToString());
            }
            return string.Join("|", result.ToArray());
        }

        /// <summary>
        /// 获取号码的大小，1表示大，0表示小
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <param name="middle">大小的分隔值</param>
        /// <returns>1|0</returns>
        public static string GetDaXiao(this IEnumerable<int> digits, int middle)
        {
            List<string> result = new List<string>(digits.Count());
            foreach (int e in digits)
            {
                result.Add(e > middle ? "1" : "0");
            }
            return string.Join("|", result.ToArray());
        }

        /// <summary>
        /// 获取号码的奇偶，1表示奇数，0表示偶数
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>1|0</returns>
        public static string GetDanShuang(this IEnumerable<int> digits)
        {
            List<string> result = new List<string>(digits.Count());
            foreach (int e in digits)
            {
                result.Add(e % 2 == 0 ? "0" : "1");
            }
            return string.Join("|", result.ToArray());
        }

        /// <summary>
        /// 获取号码的乘积
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>各号码相乘的积</returns>
        public static int GetJi(this IEnumerable<int> digits)
        {
            int x = 1;
            foreach (int digit in digits)
                x *= digit;
            return x;
        }

        /// <summary>
        /// 获取号码的跨度(最大号码-最小号码)
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>跨度</returns>
        public static int GetKuaDu(this IEnumerable<int> digits)
        {
            if (digits.Count() <= 1) return digits.Max();
            return (digits.Max() - digits.Min());
        }

        /// <summary>
        /// 获取号码AC值, 一组号码中所有两个号码相减，然后对所得的差求绝对值，
        /// 如果有相同的数字，则只保留一个，得到不同差值个数，
        /// AC值就等于不同差值个数减去r-1（r为投注号码数，在数字三型彩票中r为3）。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>AC值</returns>
        public static int GetAC(this IList<int> digits)
        {
            if (digits.Count <= 1) return 0;

            int r = digits.Count;
            var comb = new Combinations<int>(digits, 2);
            var substracts = new List<int>(comb.Count);
            foreach (var number in comb)
            {
                substracts.Add(number.GetKuaDu());
            }
            return substracts.Distinct().Count() - (r - 1);
        }

        /// <summary>
        /// 获取号码的相加的和值。
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>和值</returns>
        public static int GetHe(this IEnumerable<int> digits)
        {
            return digits.Sum();
        }

        /// <summary>
        /// 获取号码的大小比
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <param name="middle">大小中间值</param>
        /// <returns>大|小</returns>
        public static string GetDaXiaoBi(this IEnumerable<int> digits, int middle)
        {
            string str = digits.GetDaXiao(middle);
            return string.Format("{0}|{1}", str.Count("1"), str.Count("0"));
        }

        /// <summary>
        /// 获取号码的质合比
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>质|合</returns>
        public static string GetZiHeBi(this IEnumerable<int> digits)
        {
            string str = digits.GetZiHe();
            return string.Format("{0}|{1}", str.Count("1"), str.Count("0"));
        }

        /// <summary>
        /// 获取号码的单双比
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>单|双</returns>
        public static string GetDanShuangBi(this IEnumerable<int> digits)
        {
            string str = digits.GetDanShuang();
            return string.Format("{0}|{1}", str.Count("1"), str.Count("0"));
        }

        /// <summary>
        /// 获取012路比
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>0|1|2</returns>
        public static string GetLu012Bi(this IEnumerable<int> digits)
        {
            string str = digits.GetLu012();
            return string.Format("{0}|{1}|{2}", str.Count("0"), str.Count("1"), str.Count("2"));
        }

        /// <summary>
        /// 获取号码某一属性(大小，单双，质合，012路)，的比例
        /// </summary>
        /// <param name="digits">号码的各位数字集合</param>
        /// <returns>属性与统计个数字典</returns>
        public static Dictionary<int, int> ToDictionary(this IEnumerable<int> digits, Func<int, int> func)
        {
            return digits.Select(func)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Count());
        }

        /// <summary>
        /// 获取号码某一属性(大小，单双，质合，012路)，的比例
        /// </summary>
        /// <param name="str">以英文|号分隔的字符串</param>
        /// <returns>属性与统计个数字典</returns>
        public static Dictionary<char, int> ToDictionary(this string str)
        {
            return str.GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Count());
        }

        /// <summary>
        /// 获取号码某一属性(大小，单双，质合，012路)，的比例
        /// </summary>
        /// <param name="str">以英文|号分隔的字符串</param>
        /// <returns>属性与统计个数降序字符串，用英文逗号分隔(如：1,0)</returns>
        public static string ToCountString(this string str)
        {
            return string.Join(",", str.GroupBy(x => x)
                .OrderByDescending(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Count()).Values.ToArray());
        }

        /// <summary>
        /// 获取号码某一属性(大小，单双，质合，012路)，的比例
        /// </summary>
        /// <param name="str">以英文|号分隔的字符串</param>
        /// <returns>属性与统计个数降序字符串，用英文逗号分隔(如：1,0)</returns>
        public static int Count(this string str,string ch)
        {
            return str.Split('|').Where(x => x.Equals(ch)).Count();
        }

         /// <summary>
        /// 获取号码的各维度值。
        /// </summary>
        /// <param name="obj">某一种类型的号码字符串对象</param>
        /// <param name="length">每几个数字为一组以英文逗号分隔</param>
        /// <param name="dmName">维度名称,区分大小写,取值为:(Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <param name="daXiaoMiddle">大小分隔值</param>
        /// <returns></returns>
        public static string GetDmValue(this object obj, int length, string dmName, int daXiaoMiddle)
        {
            return obj.ToString(length).GetDmValue(dmName, daXiaoMiddle);
        }

        /// <summary>
        /// 获取号码的各维度值。
        /// </summary>
        /// <param name="str">某一种类型的号码字符串,每个数字以英文逗号分隔</param>
        /// <param name="dmName">维度名称,区分大小写,取值为:(Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <param name="daXiaoMiddle">大小分隔值</param>
        /// <returns></returns>
        public static string GetDmValue(this string str, string dmName, int daXiaoMiddle)
        {
            if (dmName.Equals("Peroid")) return string.Empty;

            List<int> digits = str.ToList();
            if (dmName.Equals("DaXiao")) return digits.GetDaXiao(daXiaoMiddle);
            if (dmName.Equals("DanShuang")) return digits.GetDanShuang();
            if (dmName.Equals("ZiHe")) return digits.GetZiHe();
            if (dmName.Equals("Lu012")) return digits.GetLu012();
            if (dmName.Equals("He")) return digits.GetHe().ToString();
            if (dmName.Equals("HeWei")) return digits.GetHe().GetWei().ToString();
            if (dmName.Equals("Ji")) return digits.GetJi().ToString();
            if (dmName.Equals("JiWei")) return digits.GetJi().GetWei().ToString();
            if (dmName.Equals("KuaDu")) return digits.GetKuaDu().ToString();
            if (dmName.Equals("AC")) return digits.GetAC().ToString();
            if (dmName.Equals("DaXiaoBi")) return digits.GetDaXiaoBi(daXiaoMiddle);
            if (dmName.Equals("ZiHeBi")) return digits.GetZiHeBi();
            if (dmName.Equals("DanShuangBi")) return digits.GetDanShuangBi();
            if (dmName.Equals("Lu012Bi")) return digits.GetLu012Bi();

            return string.Empty;
        }

        /// <summary>
        /// 获取号码类型。
        /// </summary>
        /// <param name="str">号码</param>
        /// <returns>号码类型</returns>
        public static string GetNumberType(this string str)
        {
            if (str.Length < 2) return string.Empty;

            int digits = 0;
            if (str.Length == 2)
            {
                digits = str.ToArray().Distinct().Count();
                return (digits == 2) ? "C2" : "B2";
            }

            if (str.Length == 3)
            {
                digits = str.ToArray().Distinct().Count();
                if (digits == 3) return "C36";
                return (digits == 2) ? "C33" : "B3";
            }

            if (str.Length == 4)
            {
                string s = string.Join("",str.GroupBy(x => x).Select(g => g.Count()).OrderByDescending(e => e));
                if (s.Equals("1111")) return "C424";
                if (s.Equals("211")) return "C412";
                if (s.Equals("22")) return "C46";
                if (s.Equals("31")) return "C44";
                return "B4";
            }

            string s1 = string.Join("", str.GroupBy(x => x).Select(g => g.Count()).OrderByDescending(e => e));
            if (s1.Equals("11111")) return "C5120";
            if (s1.Equals("2111")) return "C560";
            if (s1.Equals("221")) return "C530";
            if (s1.Equals("311")) return "C520";
            if (s1.Equals("32")) return "C510";
            if (s1.Equals("41")) return "C55";
            return "B5";
        }

        /// <summary>
        /// 获取规范化的NumberType
        /// </summary>
        /// <param name="str">原NumberType</param>
        /// <returns>规范化的NumberType</returns>
        public static string GetNormNumberType(this string str)
        {
            if (str[0] == 'D') return "DX";
            return str;
        }
    }
}

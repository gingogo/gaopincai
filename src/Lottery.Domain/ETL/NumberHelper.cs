using System.Collections.Generic;
using System.Linq;

namespace Lottery.ETL
{
    using Utils;

    public class NumberHelper
    {
        public static List<string> GetComputeResult(List<string> numbers,int daxiaoMiddle)
        {
            List<string> results = new List<string>();
            foreach (string number in numbers)
            {
                string[] arr = number.Split(',');
                List<int> digits = new List<int>();
                foreach (string str in arr)
                    digits.Add(int.Parse(str));

                string id = number.Replace(",", "");
                string num = number.Replace(",", " ");

                string dx = GetDaXiao(digits, daxiaoMiddle);
                string ds = GetDanShuang(digits);
                string zh = GetZiHe(digits);
                string m3 = Get012(digits);

                int s = digits.Sum();
                int ji = GetJi(digits);
                int hw = GetWei(s.ToString());
                int jiWei = GetWei(ji.ToString());
                int kuaDu = GetKuaDu(digits);
                int ac = GetAC(digits);

                string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                    id, num, s, hw, dx, ds, zh, m3, ji, jiWei, kuaDu, ac);
                results.Add(line);
            }

            return results;
        }

        public static string GetDaXiao(List<int> digits, int middle)
        {
            List<string> result = new List<string>(digits.Count);
            foreach (int e in digits)
            {
                result.Add(e > middle ? "1" : "0");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        public static string GetDanShuang(List<int> digits)
        {
            List<string> result = new List<string>(digits.Count);
            foreach (int e in digits)
            {
                result.Add(e % 2 == 0 ? "0" : "1");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        public static string GetZiHe(List<int> digits)
        {
            List<string> result = new List<string>(digits.Count);
            foreach (int e in digits)
            {
                result.Add((
                    e == 0 ||
                    e == 4 ||
                    e == 6 ||
                    e == 8 ||
                    e == 9 ||
                    e == 10) ? "0" : "1");
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("0")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        public static string Get012(List<int> digits)
        {
            List<string> result = new List<string>(digits.Count);
            foreach (int e in digits)
            {
                result.Add((e % 3).ToString());
            }

            List<string> cntList = new List<string>();
            cntList.Add(result.Count(x => x.Equals("0")).ToString());
            cntList.Add(result.Count(x => x.Equals("1")).ToString());
            cntList.Add(result.Count(x => x.Equals("2")).ToString());

            return string.Format("{0},{1}",
                string.Join("|", result.ToArray()),
                string.Join(",", cntList.ToArray()));
        }

        public static int GetJi(List<int> digits)
        {
            int x = 1;
            foreach (int digit in digits)
                x *= digit;
            return x;
        }

        public static int GetKuaDu(List<int> digits)
        {
            return (digits.Max() - digits.Min());
        }

        public static int GetAC(List<int> digits)
        {
            //一组号码中所有两个号码相减，然后对所得的差求绝对值，
            //如果有相同的数字，则只保留一个，得到不同差值个数，
            //AC值就等于不同差值个数减去r-1（r为投注号码数，在数字三型彩票中r为3）。
            int r = digits.Count;
            var comb = new Combinations<int>(digits, 2);
            var numbers = comb.Get(",");
            var substracts = new List<int>(numbers.Count);

            foreach (var number in numbers)
            {
                string[] arr = number.Split(',');
                List<int> digits1 = new List<int>();
                foreach (string str in arr)
                    digits1.Add(int.Parse(str));
                substracts.Add(GetKuaDu(digits1));
            }

            return substracts.Distinct().Count() - (r - 1);
        }

        public static int GetWei(string str)
        {
            int index = str.Length - 1;
            return int.Parse(str.Substring(index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lottery.WinForms.Biz
{
    using DataObjects;

    public static class BizBase
    {
        /// <summary>
        /// 通过日期计算对应的期数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetPeriodByDate(DateTime dt, CaiConfigData CaiData)
        {
            if (dt.Hour < CaiData.TimeBeginHour) return 0;
            if (dt.Hour >= CaiData.TimeEndHour) return CaiData.PeriodPerDay;
            return (dt.Hour - CaiData.TimeBeginHour) * 5 + (dt.Minute % CaiData.TimePerPeriod);
        }

        /// <summary>
        /// 获取当前时间的date格式
        /// </summary>
        /// <returns></returns>
        public static string GetDateNow()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 通过日期计算对应的P
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetPByDate(DateTime dt, CaiConfigData CaiData)
        {
            string p = dt.ToString("yyyyMMdd");
            if (dt.Hour < CaiData.TimeBeginHour) return p + "01";
            if (dt.Hour >= CaiData.TimeEndHour) return p + CaiData.PeriodPerDay.ToString();
            return p + ((dt.Hour - CaiData.TimeBeginHour) * (60 / CaiData.TimePerPeriod) + (dt.Minute % CaiData.TimePerPeriod)).ToString();
        }

        /// <summary>
        /// 计算与当前时间的间隔
        /// </summary>
        /// <param name="p"></param>
        /// <param name="CaiData"></param>
        /// <returns></returns>
        public static int GetSpanTillNow(string p, CaiConfigData CaiData)
        {
            if (p == null) return 0;

            DateTime now = CaiData.NowCaculate;
            string lastDate = p.Substring(0, 8);
            int term = Convert.ToInt32(p.Substring(8, 2));
            DateTime dt = DateTime.ParseExact(lastDate, "yyyyMMdd", null);
            int dtSplit = ((now - dt).Days) * CaiData.PeriodPerDay;
            int nowSpan = dtSplit + BizBase.GetPeriodByDate(now, CaiData) - term;
            return nowSpan;
        }

        public static string ListToString(List<int> ints)
        {
            return ListToString(ints, false);
        }

        public static string ListToString(List<int> ints, bool distinct)
        {
            string re = "";
            if (distinct)
                ints = ints.Distinct().ToList();
            foreach (int i in ints)
            {
                re += i.ToString() + ",";
            }
            if (re != "")
            {
                re.Substring(0, re.Length - 1);
            }
            return re;
        }

        public static void XMLSerialize(List<NumSpanData> spans, CaiConfigData CaiData)
        {
            string fileName = string.Format("{0}_{1}_{2}.xml",
                CaiData.CaiType, CaiData.TaskType, CaiData.NowCaculate.ToString("yyyyMMdd"));
            string path = Path.Combine(CaiData.AppPath, "Cache") + fileName;

            XmlSerializer xs = new XmlSerializer(typeof(List<NumSpanData>));
            Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            xs.Serialize(stream, spans);
            stream.Close();
        }

        public static List<NumSpanData> XMLDeserialize(CaiConfigData CaiData)
        {
            string fileName = string.Format("{0}_{1}_{2}.xml", 
                CaiData.CaiType, CaiData.TaskType, CaiData.NowCaculate.ToString("yyyyMMdd"));
            string path = Path.Combine(CaiData.AppPath, "Cache") + fileName;

            if (File.Exists(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<NumSpanData>));
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                List<NumSpanData> spans = (List<NumSpanData>)xs.Deserialize(stream);
                stream.Close();
                return spans;
            }

            return null;
        }
    }
}

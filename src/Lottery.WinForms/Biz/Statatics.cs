using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lottery.WinForms.Biz
{
    using Configuration;
    using Data.SQLServer.D11X5;
    using DataObjects;
    using Model.D11X5;
    using Utils;

    public class Statatics
    {
        /// <summary>
        /// 获取周期统计
        /// </summary>
        /// <param name="CaiData">配置数据对象</param>
        /// <returns>周期对象列表</returns>
        public List<NumSpanData> GetSpanCount(CaiConfigData CaiData)
        {
            if (CaiData.IsLoadFromCache)
            {
                //从缓存中获取
                List<NumSpanData> re = BizBase.XMLDeserialize(CaiData);
                if (re != null)
                    return re;
            }

            List<NumSpanData> spans = new List<NumSpanData>();
            DwSpanDAO da = new DwSpanDAO(ConfigHelper.GetDwSpanTableName(CaiData.NumType),
                ConfigHelper.GetConnString(CaiData.CaiType));
            string[] numList = NumberBiz.Instance.GetNumberIds(CaiData.NumType).Keys.ToArray<string>();

            //获取今天出的全部号码
            DwNumberDAO nda = new DwNumberDAO(ConfigHelper.GetConnString(CaiData.CaiType));
            DateTime dt = CaiData.NowCaculate.AddDays(1);
            string NumCondition = "where date = " + dt.ToString("yyyyMMdd");
            List<DwNumber> TodayDtos = nda.SelectWithCondition(NumCondition, new string[] { "P", "D1", "N", "F2", "Date" });

            foreach (string num in numList)
            {
                NumSpanData span = new NumSpanData();
                span.num = num;

                string pBegin = BizBase.GetPByDate(CaiData.NowCaculate, CaiData);//开始计算的时间
                string condition = " where NumberId = '" + num + "' and p < " + pBegin + " order by p desc";
                List<DwSpan> dtos = da.SelectTopN(100, condition, new string[] { "P", "LastN", "Spans" });
                List<int> spanList = new List<int>();
                int i = 0;
                foreach (DwSpan dto in dtos)
                {
                    if (i == 0)
                    {
                        span.p = dto.P.ToString();
                        span.SpanLast = dto.F2Spans;
                        span.SpanTillNow = BizBase.GetSpanTillNow(dto.P.ToString(), CaiData);
                    }
                    span.SpanRec += dto.F2Spans.ToString() + ",";
                    i++;
                    spanList.Add(dto.F2Spans);

                }

                span.SpanMax = da.SelectMaxSpan(span.num);
                span.SpanAvg = da.SelectAvgSpan(span.num);
                span.NextAll = GetNextCyclesByNum(span, spanList, CaiData);

                //pBegin后的第二天出现的期数
                span.Next = this.GetNFromDate(span.num, CaiData, TodayDtos);
                //最小误差
                span = this.GetNextTest(span);

                //最近出现的总次数及每日次数
                string numsql = " where p < " + pBegin + " order by p desc";
                List<DwNumber> numdtos = nda.SelectTopN((1008 + (10 * CaiData.PeriodPerDay)), numsql, new string[] { "P", "D1", "N", "F2", "Date" });
                span = this.GetTimesByNum(span, CaiData, numdtos);
                span.TimesDay1 = span.Next.Split(',').Length - 1;

                //最近周期
                span = this.GetHotTrends(span, CaiData, numdtos);

                //周期热度
                if (span.Times < 5)
                    span.HotType = -1;
                else if (span.Times >= 12)
                    span.HotType = 1;
                else
                    span.HotType = 0;


                spans.Add(span);
            }

            //序列化保存至缓存
            BizBase.XMLSerialize(spans, CaiData);
            return spans;
        }

        /// <summary>
        /// 获取指定号码的热度趋势
        /// </summary>
        /// <param name="span"></param>
        /// <param name="CaiData"></param>
        /// <returns></returns>
        public NumSpanData GetHotTrends(NumSpanData span, CaiConfigData CaiData, List<DwNumber> dtos)
        {
            List<int> times = new List<int>();
            int max = dtos.Count >= 1008 ? 1008 : dtos.Count;
            for (int i = 0; i < 10; i++)
            {
                List<DwNumber> list = dtos.GetRange(i * CaiData.PeriodPerDay, max);
                times.Add(list.Where(x => x.F2 == span.num).ToList().Count);
            }
            //判断趋向热
            if (times[0] == times.Max() && times[times.Count - 1] == times.Min() && times.Max() - times.Min() >= 3)
            {
                span.HotTrend = 1;
            }
            else if (times[0] == times.Min() && times[times.Count - 1] == times.Max() && times.Max() - times.Min() >= 3)
            {
                span.HotTrend = -1;
            }
            else if (times[0] != times.Max() && times[times.Count - 1] != times.Max() && times.Max() - times.Min() >= 3)
            {
                span.HotTrend = -1;
            }
            else if (times[0] != times.Min() && times[times.Count - 1] != times.Min() && times.Max() - times.Min() >= 3)
            {
                span.HotTrend = 1;
            }
            else
            {
                span.HotTrend = 0;
            }
            span.HotRecent = BizBase.ListToString(times);

            return span;
        }


        /// <summary>
        /// 获取指定号码最近出现的次数分布
        /// </summary>
        /// <param name="span"></param>
        /// <param name="CaiData"></param>
        /// <returns></returns>
        public NumSpanData GetTimesByNum(NumSpanData span, CaiConfigData CaiData, List<DwNumber> dtos)
        {
            span.Times = 0;
            span.TimesDay1 = 0;
            span.TimesDay2 = 0;
            span.TimesDay3 = 0;
            span.TimesDay4 = 0;
            span.TimesDay5 = 0;
            span.TimesDay6 = 0;
            span.TimesDay7 = 0;
            DateTime now = CaiData.NowCaculate;
            int max = dtos.Count >= 1008 ? 1008 : dtos.Count;
            foreach (DwNumber dto in dtos.GetRange(0, max).ToList())
            {
                if (dto.F2 == span.num)
                {
                    span.Times++;
                    string date = dto.Date.ToString();
                    TimeSpan ts = now - Convert.ToDateTime(date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2));
                    switch (ts.Days)
                    {
                        case 0:
                            span.TimesDay1 += 1;
                            break;
                        case 1:
                            span.TimesDay2 += 1;
                            break;
                        case 2:
                            span.TimesDay3 += 1;
                            break;
                        case 3:
                            span.TimesDay4 += 1;
                            break;
                        case 4:
                            span.TimesDay5 += 1;
                            break;
                        case 5:
                            span.TimesDay6 += 1;
                            break;
                        case 6:
                            span.TimesDay7 += 1;
                            break;
                    }
                }
            }
            return span;
        }


        /// <summary>
        /// 获取指定号码的可能周期
        /// </summary>
        /// <param name="span">周期对象数据</param>
        /// <param name="spans">所有周期样本</param>
        /// <param name="CaiData">配置数据对象</param>
        /// <returns></returns>
        public string GetNextCyclesByNum(NumSpanData span, List<int> spans, CaiConfigData CaiData)
        {
            string num = span.num;
            int avg = span.SpanAvg;
            int lastp = span.SpanTillNow;

            List<int> cycles = new List<int>();
            for (int i = 3; i < 94; i++)
            {
                int cycle = 0;
                for (int j = 0; j < i - 1; j++)
                {
                    int currentspan = spans[j];
                    cycle += currentspan;
                }
                int next = avg * i - cycle;
                next = next - lastp;
                int cycleMax = CaiData.PeriodPerDay * 6;
                if (next > 0 && next < cycleMax)//6天总周期
                {
                    if (next <= (CaiData.PeriodPerDay * 2))
                        cycles.Add(next);

                }
            }

            cycles = cycles.OrderBy(x => x).ToList();
            return BizBase.ListToString(cycles, true);

        }

        /// <summary>
        /// 获取指定数字在指定日期的第二天出现的期数
        /// </summary>
        /// <param name="num">数字</param>
        /// <param name="CaiData">配置数据对象，日期</param>
        /// <param name="dtos">第二天出现的数据</param>
        /// <returns></returns>
        public string GetNFromDate(string num, CaiConfigData CaiData, List<DwNumber> dtos)
        {
            string N = "";
            foreach (DwNumber dto in dtos)
            {
                if (dto.F2 == num)
                {
                    N += dto.N.ToString() + ",";
                }
            }
            return N;
        }

        /// <summary>
        /// 获取下一期可能性的误差
        /// </summary>
        /// <param name="nsd">周期数据对象</param>
        /// <returns></returns>
        public NumSpanData GetNextTest(NumSpanData span)
        {

            if (span.Next == "" || span.NextAll == "")
            {
                span.NextTest = -1;
                return span;
            }
            int next = 0;
            if (span.Next.IndexOf(",") != -1)
                next = int.Parse(span.Next.Substring(0, span.Next.IndexOf(",")));
            else
                next = int.Parse(span.Next);

            string[] nextall = span.NextAll.Split(',');
            List<int> tests = new List<int>();
            foreach (string nextStr in nextall)
            {
                int nextInt = 0;
                if (nextStr != "")
                {
                    nextInt = int.Parse(nextStr);
                    tests.Add(Math.Abs(nextInt - next));
                }
            }
            span.NextTest = tests.Min();
            return span;
        }


        /// <summary>
        /// 获取最大遗漏
        /// </summary>
        /// <param name="CaiData"></param>
        /// <param name="day">天数</param>
        /// <returns></returns>
        public List<NumSpanData> GetMaxLeft(CaiConfigData CaiData, int day)
        {
            List<NumSpanData> spans = new List<NumSpanData>();
            DwNumberDAO da = new DwNumberDAO(ConfigHelper.GetConnString(CaiData.CaiType));
            DwSpanDAO spanda = new DwSpanDAO(ConfigHelper.GetDwSpanTableName(CaiData.NumType), ConfigHelper.GetConnString(CaiData.CaiType));
            string pBegin = BizBase.GetPByDate(CaiData.NowCaculate, CaiData);//开始计算的时间
            string condition = " where p < " + pBegin + " order by p desc";
            List<DwNumber> dtos = da.SelectTopN(day * CaiData.PeriodPerDay, condition, new string[] { "P", "D1", "N", "F2", "Date" });
            string[] numList = NumberBiz.Instance.GetNumberIds(CaiData.NumType).Keys.ToArray<string>();

            foreach (string num in numList)
            {
                NumSpanData span = new NumSpanData();
                span.num = num;
                span.p = da.GetPeroidBefore(span.num, CaiData.NumType, CaiData.NowCaculate);
                span.SpanMax = spanda.SelectMaxSpan(span.num);
                span.SpanTillNow = BizBase.GetSpanTillNow(span.p, CaiData);
                span.SpanAvg = spanda.SelectAvgSpan(span.num);
                span = this.GetTimesByNum(span, CaiData, dtos);
                spans.Add(span);
            }

            return spans;
        }
    }
}

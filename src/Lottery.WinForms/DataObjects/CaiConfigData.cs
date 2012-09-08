using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.WinForms.DataObjects
{
    public class CaiConfigData
    {
        /// <summary>
        /// 彩种名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 彩种
        /// </summary>
        public string CaiType { get; set; }
        /// <summary>
        /// 每天的期数
        /// </summary>
        public int PeriodPerDay { get; set; }
        /// <summary>
        /// 每期的时间
        /// </summary>
        public int TimePerPeriod { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public int TimeBeginHour { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public int TimeEndHour { get; set; }
        /// <summary>
        /// 统计开始时间，默认是当前时间
        /// </summary>
        public DateTime NowCaculate { get; set; }
        /// <summary>
        /// 号码类型，F2等
        /// </summary>
        public string NumType { get; set; }
        /// <summary>
        /// 计算的任务类型
        /// </summary>
        public string TaskType { get; set; }
        /// <summary>
        /// 是否从缓存加载
        /// </summary>
        public bool IsLoadFromCache { get; set; }
        /// <summary>
        /// 应用程序路径
        /// </summary>
        public string AppPath { get; set; }

        public string StatusLable { get; set; }

        public static CaiConfigData Create(string type,string numType,string appPath)
        {
            CaiConfigData caiData = new CaiConfigData();
            caiData.CaiType = type;
            caiData.NowCaculate = DateTime.Now;
            caiData.NumType = numType;
            caiData.AppPath = appPath;

            if (type.Equals("shand11x5"))
            {
                caiData.PeriodPerDay = 78;
                caiData.TimeBeginHour = 9;
                caiData.TimeEndHour = 22;
                caiData.TimePerPeriod = 10;
                caiData.Name = "山东11选5";
                return caiData;
            }

            if (type.Equals("guangd11x5"))
            {
                caiData.PeriodPerDay = 84;
                caiData.TimeBeginHour = 9;
                caiData.TimeEndHour = 23;
                caiData.TimePerPeriod = 10;
                caiData.Name = "广东11选5";
                return caiData;
            }

            caiData.PeriodPerDay = 65;
            caiData.TimeBeginHour = 9;
            caiData.TimeEndHour = 22;
            caiData.TimePerPeriod = 12;
            caiData.Name = "江西11选5";

            return caiData;
        }
    }
}

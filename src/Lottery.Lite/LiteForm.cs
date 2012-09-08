using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lottery.Lite
{
    public partial class LiteForm : Form
    {
        public LiteForm()
        {
            InitializeComponent();

            //初始化时间及相关数据
            for (int i = 0; i < 7; i++)
            {
                comboBoxDate.Items.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"));
                if (i > 3)
                    comboBoxSType.Items.Add((i + 1).ToString() + "天遗漏");
            }


        }

        #region 初始化数据


        /// <summary>
        /// listview数据对象用来存放每次计算的结果，异步添加到tabpage
        /// </summary>
        public ListViewData list = new ListViewData();
        /// <summary>
        /// 彩种基本数据
        /// </summary>
        public CaiConfigData CaiData = new CaiConfigData();


        /// <summary>
        /// 初始化数据
        /// </summary>
        private void initType()
        {
            /**
             * GD 84 | YDJ 78 | JX 65
             * JX 12 | 10
             * */
            CaiData.CaiType = ComboBoxType.Text;
            switch (CaiData.CaiType)
            {
                case "shand11x5":
                    CaiData.PeriodPerDay = 78;
                    CaiData.TimeBeginHour = 9;
                    CaiData.TimeEndHour = 22;
                    CaiData.TimePerPeriod = 10;
                    this.Text = "老11选5";
                    break;
                case "jiangx11x5":
                    CaiData.PeriodPerDay = 65;
                    CaiData.TimeBeginHour = 9;
                    CaiData.TimeEndHour = 22;
                    CaiData.TimePerPeriod = 12;
                    this.Text = "11选5";
                    break;
                case "guangd11x5":
                    CaiData.PeriodPerDay = 84;
                    CaiData.TimeBeginHour = 9;
                    CaiData.TimeEndHour = 23;
                    CaiData.TimePerPeriod = 10;
                    this.Text = "新11选5";
                    break;
            }
            //设置计算时间默认为当前时间
            CaiData.NowCaculate = DateTime.Now;
            CaiData.NumType = "F2";
            
            CaiData.AppPath = Application.StartupPath;



            //显示最新的数据
            //showNewNumber();
        }

        #endregion
        

    }
}

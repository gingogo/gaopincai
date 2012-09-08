using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lottery.Data.SQLServer.D11X5;
using Lottery.Model.D11X5;
using Lottery.Configuration;

namespace Lottery.Lite
{
    public partial class LiteForm : Form
    {
        public LiteForm()
        {
            InitializeComponent();

            setSelectType();

            initType();
           


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
            ShowNewNumber();
        }


        private void setSelectType()
        {
            //初始化时间及相关数据
            for (int i = 0; i < 7; i++)
            {
                comboBoxDate.Items.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"));
                if (i > 3)
                    comboBoxSType.Items.Add((i + 1).ToString() + " Days Left");
            }
        }



        #endregion


        #region 公共控件方法 LISTVIEW
        private ListView getCurrentListView()
        {
            try
            {
                return (ListView)tabControl1.TabPages[tabControl1.SelectedIndex].Controls[0];
            }
            catch
            {
                return null;
            }
        }

        public ListView GetShownListView()
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = null;
            if (tp.Name != "tabPage")
                lv = (ListView)tp.Controls[0];
            return lv;
        }

        /// <summary>
        /// 创建一个TAB,并添加一个ListView
        /// </summary>
        /// <param name="lvd"></param>
        public void CreateListView(ListViewData lvd)
        {
            TabPage tp = new TabPage();
            tp.Dock = DockStyle.Fill;
            tp.Text = lvd.name;
            tp.Parent = tabControl1;
            ListView lv = new ListView();
            //ListView lv = listView1;
            lv.Dock = DockStyle.Fill;
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            tp.Controls.Add(lv);
            SetListView(lv, lvd);
            tabControl1.SelectedTab = tp;
            //lv.ContextMenuStrip = contextMenuStripListView;
        }

        /// <summary>
        /// 设置指定listview的数据
        /// </summary>
        /// <param name="lv">listview控件</param>
        /// <param name="lvd">listview数据对象</param>
        private void SetListView(ListView lv, ListViewData lvd)
        {
            //清空listview里边的数据
            lv.Clear();
            //添加表头
            foreach (string title in lvd.title)
            {
                lv.Columns.Add(title, 60);
            }

            //设置宽度
            if (lvd.width != null)
            {
                for (int w = 0; w < lvd.width.Length; w++)
                {
                    lv.Columns[w].Width = lvd.width[w];
                }
            }

            //设置各列的值
            if (lvd.values.Count > 0)
            {
                ListViewItem[] items = new ListViewItem[lvd.values.Count];
                for (int l = 0; l < lvd.values.Count; l++)
                {
                    items[l] = new ListViewItem(lvd.values[l]);
                    //item[l].SubItems[0].BackColor = Color.Red; //用于设置某行的背景颜色
                }
                lv.Items.AddRange(items);
            }
        }


        //关闭TAB 
        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != tabPageHall)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        #endregion


        #region 异步控件方法 backgroundworker

        void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStat.Enabled = true;
            if (list.values != null && list.values.Count > 0)
                this.CreateListView(list);
        }


        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            switch (CaiData.TaskType)
            {
                case "All Spans":
                    AnalysisSpanCycle();
                    break;
                case "5 Days Left":
                    CaculateLeftSpan(5);
                    break;
                case "6 Days Left":
                    CaculateLeftSpan(6);
                    break;
                case "7 Days Left":
                    CaculateLeftSpan(7);
                    break;
            }
        }
        #endregion


        #region 查找并高亮指定数字

        /// <summary>
        /// 查找指定number在当前的LISTVIEW中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFindClick(object sender, EventArgs e)
        {
            FindeNumber();
        }

        /// <summary>
        /// 查找指定number在当前的LISTVIEW中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFindTextChanged(object sender, EventArgs e)
        {
            FindeNumber();
        }

        /// <summary>
        /// 查找指定number
        /// </summary>
        private void FindeNumber()
        {
            ListView lv = this.getCurrentListView();
            var text = textBoxFind.Text;
            if (lv != null && text.Length == 4)
            {
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    if (lv.Items[i].Text == text)
                    {
                        lv.Items[i].BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        lv.Items[i].ForeColor = Color.FromKnownColor(KnownColor.HighlightText);
                        break;
                    }
                }
            }
            if (lv != null && text == "")
            {
                for (int x = 0; x < lv.Items.Count; x++)
                {
                    lv.Items[x].BackColor = Color.FromKnownColor(KnownColor.Window);
                    lv.Items[x].ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                }
            }
        }
        #endregion


        #region 界面控件方法

        /// <summary>
        /// 切换彩种
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            initType();
        }



        /// <summary>
        /// 切换计算时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxDateSelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime dueToDate = Convert.ToDateTime(comboBoxDate.Text);
            //TimeSpan ts = DateTime.Now - dueToDate;
            //CaiData.NowCaculate = DateTime.Now.AddDays(-ts.Days);
            CaiData.NowCaculate = dueToDate;

        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            ShowNewNumber();
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            CaiData.TaskType = comboBoxSType.Text;
            CaiData.IsLoadFromCache = false;
            backgroundWorker.RunWorkerAsync();
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            CaiData.TaskType = comboBoxSType.Text;
            CaiData.IsLoadFromCache = true;
            backgroundWorker.RunWorkerAsync();
        }

        #endregion


        #region 业务逻辑方法


        /// <summary>
        /// 显示最新开出的数字
        /// </summary>
        private void ShowNewNumber()
        {
            string date = BizBase.GetDateNow();
            if (DateTime.Now.Hour < CaiData.TimeBeginHour)
                date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");

            DwNumberDAO da = new DwNumberDAO(ConfigHelper.GetConnString(CaiData.CaiType));
            string condition = "where date= " + date + " order by p desc";
            List<DwNumber> lists = da.SelectTopN(CaiData.PeriodPerDay, condition, null);
            ListViewData lvd = new ListViewData();
            lvd.name = CaiData.CaiType + " NEW";
            lvd.title = new string[] { "f2", "n", "f5" };
            lvd.width = new int[] { 60, 60, 100 };
            lvd.values = new List<string[]>();
            foreach (DwNumber dto in lists)
            {
                string[] values = new string[] { dto.F2, dto.N.ToString(), dto.F5.ToString() };
                lvd.values.Add(values);
            }
            this.SetListView(listViewRealTime, lvd);
            groupBox1.Text = "Real Time " + DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        }


        /// <summary>
        /// 实时计算span cyle
        /// </summary>
        public void AnalysisSpanCycle()
        {
            Statatics stat = new Statatics();
            List<NumSpanData> spans = stat.GetSpanCount(CaiData);
            ListViewData lvd = new ListViewData();
            lvd.name = CaiData.CaiType + " " + CaiData.NumType + " 周期 " + CaiData.NowCaculate.ToString("yyyy-MM-dd");
            lvd.title = new string[] { CaiData.NumType, "p", "now", "next", "nexttest", "nextall", "max", "avg",
            	"times","1day","2day","3day","4day","5day","6days","7days","hot","hottrend","hotrec"};
            lvd.values = new List<string[]>();

            foreach (NumSpanData span in spans)
            {
                string[] values = new string[] { span.num,span.p, span.SpanTillNow.ToString(),span.Next,span.NextTest.ToString(),span.NextAll, span.SpanMax.ToString(), span.SpanAvg.ToString(),
            		span.Times.ToString(),span.TimesDay1.ToString(),span.TimesDay2.ToString(),
            		span.TimesDay3.ToString(),span.TimesDay4.ToString(),span.TimesDay5.ToString(),
            		span.TimesDay6.ToString(),span.TimesDay7.ToString(),
            		span.HotType.ToString(),span.HotTrend.ToString(),span.HotRecent};
                lvd.values.Add(values);
            }
            lvd.values = lvd.values.OrderBy(x => int.Parse(x[8])).ToList();
            list = lvd;

        }

        /// <summary>
        /// 计算遗漏
        /// </summary>
        public void CaculateLeftSpan(int day)
        {
            //5天 6天 7天遗漏
            //F2 NOW MAX MIN 
            Statatics stat = new Statatics();
            List<NumSpanData> spans = stat.GetMaxLeft(CaiData, day);
            ListViewData lvd = new ListViewData();
            lvd.name = CaiData.CaiType + " " + CaiData.NumType + " 遗漏 " + CaiData.NowCaculate.ToString("MM-dd");
            lvd.title = new string[] { CaiData.NumType, "p", "now", "max", "avg",
            	"times","1day","2day","3day","4day","5day","6days","7days"};
            lvd.values = new List<string[]>();

            foreach (NumSpanData span in spans)
            {
                string[] values = new string[] { 
            		span.num,
            		span.p,
            		span.SpanTillNow.ToString(),
            		span.SpanMax.ToString(), 
            		span.SpanAvg.ToString(),
            		span.Times.ToString(),
            		span.TimesDay1.ToString(),
            		span.TimesDay2.ToString(),
            		span.TimesDay3.ToString(),
            		span.TimesDay4.ToString(),
            		span.TimesDay5.ToString(),
            		span.TimesDay6.ToString(),
            		span.TimesDay7.ToString()
            	};
                lvd.values.Add(values);
            }
            lvd.values = lvd.values.OrderBy(x => int.Parse(x[5])).ToList();
            list = lvd;
        }

        #endregion

       


    }
}

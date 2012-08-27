using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms
{
    using Biz;
    using Configuration;
    using Data.SQLServer.D11X5;
    using DataObjects;
    using Model.D11X5;

    public partial class MainForm : Form
    {
        #region 私有字段

        /// <summary>
        /// listview数据对象用来存放每次计算的结果，异步添加到tabpage
        /// </summary>
        private ListViewData list = new ListViewData();
        /// <summary>
        /// 彩种基本数据
        /// </summary>
        private CaiConfigData CaiData = new CaiConfigData();

        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        #region 初始化数据方法

        /// <summary>
        /// 初始化数据。
        /// </summary>
        private void InitializeData()
        {
            this.LoadCaiConfigData();
            this.LoadDateTimeData();
            this.timerRefresh.Start();
        }

        /// <summary>
        /// 初始化彩种配置数据
        /// </summary>
        private void LoadCaiConfigData()
        {
            /**
             * GD 84 | YDJ 78 | JX 65
             * JX 12 | 10
             * */
            this.CaiData = CaiConfigData.Create(ComboBoxType.Text,
                ComboBoxNumberType.Text,
                Application.StartupPath);
            //显示最新的数据
            SetStatus("Selected: " + CaiData.Name + "...", false);
            ShowNewNumber();
        }

        /// <summary>
        /// 初始化时间
        /// </summary>
        private void LoadDateTimeData()
        {
            for (int i = 0; i < 7; i++)
            {
                comboBoxDate.Items.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"));
                if (i > 3)
                    comboBoxSType.Items.Add((i + 1).ToString() + "天遗漏");
            }
        }

        #endregion

        #region reminder提醒

        /// <summary>
        /// 提醒列表
        /// </summary>
        public List<MentionData> mdlist = new List<MentionData>();
        private void AddToReminderToolStripMenuItemClick(object sender, EventArgs e)
        {
            ListView lv = getCurrentListView();
            if (lv != null)
            {
                if (lv.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in lv.SelectedItems)
                    {
                        MentionData md = new MentionData();
                        md.num = item.SubItems[0].Text;
                        md.type = CaiData.CaiType;
                        md.numtype = CaiData.NumType;
                        if (mdlist.Find(x => x.num == md.num) == null)
                            mdlist.Add(md);
                    }
                    setReminderListView();
                    timerMention.Interval = 180000;
                    timerMention.Start();
                }
            }

        }

        /// <summary>
        /// 设置提醒的listview数据
        /// </summary>
        private void setReminderListView()
        {
            listViewReminder.Clear();
            ListViewData lvd = new ListViewData();
            lvd.title = new string[] { "F2", "N", "TYPE" };
            lvd.width = new int[] { 60, 60, 100 };
            lvd.values = new List<string[]>();
            foreach (MentionData md in mdlist)
            {
                string[] arr = new string[] { md.num, md.n, md.type };
                lvd.values.Add(arr);
            }
            groupBox3.Text = "Reminder " + DateTime.Now.ToString("yyyy-MM-dd hh:mm");
            SetListView(listViewReminder, lvd);
        }

        /// <summary>
        /// 提醒时钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerMentionTick(object sender, EventArgs e)
        {
            SetStatus(DateTime.Now.ToString());
            timerMention.Stop();
            bool checkedNew = false;
            foreach (MentionData md in mdlist)
            {
                if (md.n == null)
                {
                    DwNumberDAO da = new DwNumberDAO(ConfigHelper.GetConnString(md.type));
                    md.n = da.GetPeroidInToday(md.num, md.numtype);
                    if (md.n != null)
                    {
                        notifyIcon.BalloonTipTitle = "Tips";
                        notifyIcon.BalloonTipText = "Congratulations!!" + "\r\n" + md.num + "\r\n" + md.n;
                        notifyIcon.ShowBalloonTip(5000);
                        PlayNoticeSound();
                        setReminderListView();
                        checkedNew = true;
                    }
                }
            }
            if (!checkedNew)
                timerMention.Start();
        }

        /// <summary>
        /// 播放中奖提醒声音
        /// </summary>
        private void PlayNoticeSound()
        {
            string soundFileLocation = Application.StartupPath + @"\" + WinFormAppConfigManager.NoticeSoundFileName;
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFileLocation))
            {
                player.LoadAsync();
                player.PlaySync();
            }
        }

        /// <summary>
        /// 关闭提醒气泡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIconBalloonTipClosed(object sender, EventArgs e)
        {
            timerMention.Start();
        }

        /// <summary>
        /// 清除全部提醒数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ClearReminderToolStripMenuItemClick(object sender, EventArgs e)
        {
            listViewReminder.Clear();
            mdlist.Clear();
            timerMention.Stop();
        }

        /// <summary>
        /// 删除指定的提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewReminder.SelectedItems)
            {
                mdlist.Remove(mdlist.Find(x => x.num == item.SubItems[0].Text));
            }
            setReminderListView();
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
            lv.ContextMenuStrip = contextMenuStripListView;
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
            if (tabControl1.SelectedTab != tabPageSet)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        #endregion

        #region 异步控件方法 progressbar backgroudworker

        private void SetStatus(string text)
        {
            SetStatus(text, true);
        }

        private void SetStatus(string text, bool asyn)
        {
            if (asyn)
            {//异步
                statusStrip1.Invoke((Action)delegate() { toolStripStatusLabel1.Text = text; });
            }
            else
            {
                toolStripStatusLabel1.Text = text;
            }
        }

        private void SetProgress(int value)
        {
            progressBar.Value = progressBar.Maximum * value;
        }

        void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetProgress(0);
            SetStatus("Processed...");
            pictureBoxLoading.Visible = false;
            buttonStat.Enabled = true;
            buttonDBCount.Enabled = true;
            if (list.values != null && list.values.Count > 0)
                this.CreateListView(list);
        }


        #endregion

        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {

            switch (CaiData.TaskType)
            {
                case "所有周期":
                    AnalysisSpanCycle();
                    break;
                case "5天遗漏":
                    CaculateLeftSpan(5);
                    break;
                case "6天遗漏":
                    CaculateLeftSpan(6);
                    break;
                case "7天遗漏":
                    CaculateLeftSpan(7);
                    break;
            }

        }

        #region 查找并高亮指定数字

        /// <summary>
        /// 查找指定number在当前的LISTVIEW中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFindClick(object sender, EventArgs e)
        {
            findNumber();
        }

        /// <summary>
        /// 查找指定number在当前的LISTVIEW中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFindTextChanged(object sender, EventArgs e)
        {
            findNumber();
        }

        /// <summary>
        /// 查找指定number
        /// </summary>
        private void findNumber()
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
                for (int x = 0; x < listView1.Items.Count; x++)
                {
                    lv.Items[x].BackColor = Color.FromKnownColor(KnownColor.Window);
                    lv.Items[x].ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                }
            }
        }
        #endregion


        /// <summary>
        /// 切换彩种
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCaiConfigData();
        }

        /// <summary>
        /// 实时计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ButtonDBCountClick(object sender, EventArgs e)
        {
            CaiData.TaskType = comboBoxSType.Text;
            CaiData.NumType = ComboBoxNumberType.Text;
            CaiData.IsLoadFromCache = false;
            buttonDBCount.Enabled = false;
            pictureBoxLoading.Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStat_Click(object sender, EventArgs e)
        {
            CaiData.TaskType = comboBoxSType.Text;
            CaiData.NumType = ComboBoxNumberType.Text;
            CaiData.IsLoadFromCache = true;
            buttonStat.Enabled = false;
            pictureBoxLoading.Visible = true;
            backgroundWorker.RunWorkerAsync();
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

        //刷新最新数据
        void TimerRefreshTick(object sender, EventArgs e)
        {
            ShowNewNumber();
        }

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
    }
}


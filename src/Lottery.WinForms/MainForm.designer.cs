namespace Lottery.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.contextMenuStripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.tabPageSet = new System.Windows.Forms.TabPage();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.listViewReminder = new System.Windows.Forms.ListView();
        	this.contextMenuStripReminder = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.clearReminderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.listView1 = new System.Windows.Forms.ListView();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.listViewRealTime = new System.Windows.Forms.ListView();
        	this.timerMention = new System.Windows.Forms.Timer(this.components);
        	this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
        	this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
        	this.ComboBoxType = new System.Windows.Forms.ComboBox();
        	this.comboBoxSType = new System.Windows.Forms.ComboBox();
        	this.buttonStat = new System.Windows.Forms.Button();
        	this.ComboBoxNumberType = new System.Windows.Forms.ComboBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.comboBoxDate = new System.Windows.Forms.ComboBox();
        	this.textBoxFind = new System.Windows.Forms.TextBox();
        	this.buttonFind = new System.Windows.Forms.Button();
        	this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
        	this.progressBar = new System.Windows.Forms.ProgressBar();
        	this.contextMenuStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.toolStripMenuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
        	this.timerRefresh = new System.Windows.Forms.Timer(this.components);
        	this.buttonDBCount = new System.Windows.Forms.Button();
        	this.statusStrip1.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.contextMenuStripTab.SuspendLayout();
        	this.tabPageSet.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.contextMenuStripReminder.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
        	this.contextMenuStripListView.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripStatusLabel1});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 477);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(864, 22);
        	this.statusStrip1.TabIndex = 2;
        	// 
        	// toolStripStatusLabel1
        	// 
        	this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        	this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 17);
        	this.toolStripStatusLabel1.Text = "Ready";
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.tabControl1.ContextMenuStrip = this.contextMenuStripTab;
        	this.tabControl1.Controls.Add(this.tabPageSet);
        	this.tabControl1.Location = new System.Drawing.Point(5, 35);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(856, 441);
        	this.tabControl1.TabIndex = 3;
        	// 
        	// contextMenuStripTab
        	// 
        	this.contextMenuStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.closeToolStripMenuItem});
        	this.contextMenuStripTab.Name = "contextMenuStripTab";
        	this.contextMenuStripTab.Size = new System.Drawing.Size(153, 48);
        	// 
        	// closeToolStripMenuItem
        	// 
        	this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        	this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.closeToolStripMenuItem.Text = "Close";
        	this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
        	// 
        	// tabPageSet
        	// 
        	this.tabPageSet.Controls.Add(this.groupBox3);
        	this.tabPageSet.Controls.Add(this.groupBox2);
        	this.tabPageSet.Controls.Add(this.groupBox1);
        	this.tabPageSet.Location = new System.Drawing.Point(4, 21);
        	this.tabPageSet.Name = "tabPageSet";
        	this.tabPageSet.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageSet.Size = new System.Drawing.Size(848, 416);
        	this.tabPageSet.TabIndex = 1;
        	this.tabPageSet.Text = "Reminder";
        	this.tabPageSet.UseVisualStyleBackColor = true;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.listViewReminder);
        	this.groupBox3.Location = new System.Drawing.Point(566, 6);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(273, 217);
        	this.groupBox3.TabIndex = 3;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Reminder";
        	// 
        	// listViewReminder
        	// 
        	this.listViewReminder.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.listViewReminder.ContextMenuStrip = this.contextMenuStripReminder;
        	this.listViewReminder.FullRowSelect = true;
        	this.listViewReminder.GridLines = true;
        	this.listViewReminder.Location = new System.Drawing.Point(6, 18);
        	this.listViewReminder.Name = "listViewReminder";
        	this.listViewReminder.Size = new System.Drawing.Size(261, 194);
        	this.listViewReminder.TabIndex = 4;
        	this.listViewReminder.UseCompatibleStateImageBehavior = false;
        	this.listViewReminder.View = System.Windows.Forms.View.Details;
        	// 
        	// contextMenuStripReminder
        	// 
        	this.contextMenuStripReminder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripMenuItemDelete,
        	        	        	this.toolStripSeparator4,
        	        	        	this.clearReminderToolStripMenuItem});
        	this.contextMenuStripReminder.Name = "contextMenuStrip";
        	this.contextMenuStripReminder.Size = new System.Drawing.Size(107, 54);
        	// 
        	// toolStripMenuItemDelete
        	// 
        	this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
        	this.toolStripMenuItemDelete.Size = new System.Drawing.Size(106, 22);
        	this.toolStripMenuItemDelete.Text = "Delete";
        	this.toolStripMenuItemDelete.Click += new System.EventHandler(this.ToolStripMenuItemDeleteClick);
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(103, 6);
        	// 
        	// clearReminderToolStripMenuItem
        	// 
        	this.clearReminderToolStripMenuItem.Name = "clearReminderToolStripMenuItem";
        	this.clearReminderToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
        	this.clearReminderToolStripMenuItem.Text = "Clear";
        	this.clearReminderToolStripMenuItem.Click += new System.EventHandler(this.ClearReminderToolStripMenuItemClick);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.listView1);
        	this.groupBox2.Location = new System.Drawing.Point(287, 6);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(273, 217);
        	this.groupBox2.TabIndex = 2;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Recomended";
        	// 
        	// listView1
        	// 
        	this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.listView1.FullRowSelect = true;
        	this.listView1.GridLines = true;
        	this.listView1.Location = new System.Drawing.Point(6, 18);
        	this.listView1.Name = "listView1";
        	this.listView1.Size = new System.Drawing.Size(261, 194);
        	this.listView1.TabIndex = 1;
        	this.listView1.UseCompatibleStateImageBehavior = false;
        	this.listView1.View = System.Windows.Forms.View.Details;
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.listViewRealTime);
        	this.groupBox1.Location = new System.Drawing.Point(8, 6);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(273, 217);
        	this.groupBox1.TabIndex = 1;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Real Time";
        	// 
        	// listViewRealTime
        	// 
        	this.listViewRealTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.listViewRealTime.FullRowSelect = true;
        	this.listViewRealTime.GridLines = true;
        	this.listViewRealTime.Location = new System.Drawing.Point(6, 18);
        	this.listViewRealTime.Name = "listViewRealTime";
        	this.listViewRealTime.Size = new System.Drawing.Size(261, 194);
        	this.listViewRealTime.TabIndex = 0;
        	this.listViewRealTime.UseCompatibleStateImageBehavior = false;
        	this.listViewRealTime.View = System.Windows.Forms.View.Details;
        	// 
        	// timerMention
        	// 
        	this.timerMention.Enabled = true;
        	this.timerMention.Tick += new System.EventHandler(this.TimerMentionTick);
        	// 
        	// notifyIcon
        	// 
        	this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        	this.notifyIcon.Text = "Mention";
        	this.notifyIcon.Visible = true;
        	this.notifyIcon.BalloonTipClosed += new System.EventHandler(this.NotifyIconBalloonTipClosed);
        	// 
        	// backgroundWorker
        	// 
        	this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
        	this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
        	// 
        	// ComboBoxType
        	// 
        	this.ComboBoxType.FormattingEnabled = true;
        	this.ComboBoxType.Items.AddRange(new object[] {
        	        	        	"shand11x5",
        	        	        	"jiangx11x5",
        	        	        	"guangd11x5"});
        	this.ComboBoxType.Location = new System.Drawing.Point(5, 9);
        	this.ComboBoxType.Name = "ComboBoxType";
        	this.ComboBoxType.Size = new System.Drawing.Size(100, 20);
        	this.ComboBoxType.TabIndex = 7;
        	this.ComboBoxType.Text = "jiangx11x5";
        	this.ComboBoxType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType_SelectedIndexChanged);
        	// 
        	// comboBoxSType
        	// 
        	this.comboBoxSType.FormattingEnabled = true;
        	this.comboBoxSType.Items.AddRange(new object[] {
        	        	        	"所有周期"});
        	this.comboBoxSType.Location = new System.Drawing.Point(307, 9);
        	this.comboBoxSType.Name = "comboBoxSType";
        	this.comboBoxSType.Size = new System.Drawing.Size(121, 20);
        	this.comboBoxSType.TabIndex = 8;
        	this.comboBoxSType.Text = "Choose One Type";
        	// 
        	// buttonStat
        	// 
        	this.buttonStat.Location = new System.Drawing.Point(434, 9);
        	this.buttonStat.Name = "buttonStat";
        	this.buttonStat.Size = new System.Drawing.Size(82, 21);
        	this.buttonStat.TabIndex = 9;
        	this.buttonStat.Text = "CacheSTAT";
        	this.buttonStat.UseVisualStyleBackColor = true;
        	this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
        	// 
        	// ComboBoxNumberType
        	// 
        	this.ComboBoxNumberType.FormattingEnabled = true;
        	this.ComboBoxNumberType.Location = new System.Drawing.Point(111, 9);
        	this.ComboBoxNumberType.Name = "ComboBoxNumberType";
        	this.ComboBoxNumberType.Size = new System.Drawing.Size(50, 20);
        	this.ComboBoxNumberType.TabIndex = 11;
        	this.ComboBoxNumberType.Text = "F2";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(165, 13);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(11, 12);
        	this.label1.TabIndex = 13;
        	this.label1.Text = "|";
        	// 
        	// comboBoxDate
        	// 
        	this.comboBoxDate.FormattingEnabled = true;
        	this.comboBoxDate.Location = new System.Drawing.Point(180, 9);
        	this.comboBoxDate.Name = "comboBoxDate";
        	this.comboBoxDate.Size = new System.Drawing.Size(121, 20);
        	this.comboBoxDate.TabIndex = 15;
        	this.comboBoxDate.Text = "Choose Due Date";
        	this.comboBoxDate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDateSelectedIndexChanged);
        	// 
        	// textBoxFind
        	// 
        	this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.textBoxFind.Location = new System.Drawing.Point(723, 9);
        	this.textBoxFind.Name = "textBoxFind";
        	this.textBoxFind.Size = new System.Drawing.Size(75, 21);
        	this.textBoxFind.TabIndex = 17;
        	this.textBoxFind.TextChanged += new System.EventHandler(this.TextBoxFindTextChanged);
        	// 
        	// buttonFind
        	// 
        	this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.buttonFind.Location = new System.Drawing.Point(804, 9);
        	this.buttonFind.Name = "buttonFind";
        	this.buttonFind.Size = new System.Drawing.Size(53, 21);
        	this.buttonFind.TabIndex = 18;
        	this.buttonFind.Text = "Find";
        	this.buttonFind.UseVisualStyleBackColor = true;
        	this.buttonFind.Click += new System.EventHandler(this.ButtonFindClick);
        	// 
        	// pictureBoxLoading
        	// 
        	this.pictureBoxLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.pictureBoxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLoading.Image")));
        	this.pictureBoxLoading.InitialImage = null;
        	this.pictureBoxLoading.Location = new System.Drawing.Point(784, 484);
        	this.pictureBoxLoading.Name = "pictureBoxLoading";
        	this.pictureBoxLoading.Size = new System.Drawing.Size(58, 10);
        	this.pictureBoxLoading.TabIndex = 19;
        	this.pictureBoxLoading.TabStop = false;
        	this.pictureBoxLoading.Visible = false;
        	// 
        	// progressBar
        	// 
        	this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.progressBar.Location = new System.Drawing.Point(239, 479);
        	this.progressBar.Name = "progressBar";
        	this.progressBar.Size = new System.Drawing.Size(520, 20);
        	this.progressBar.Step = 1;
        	this.progressBar.TabIndex = 20;
        	this.progressBar.Visible = false;
        	// 
        	// contextMenuStripListView
        	// 
        	this.contextMenuStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripMenuItemAdd});
        	this.contextMenuStripListView.Name = "contextMenuStripListView";
        	this.contextMenuStripListView.Size = new System.Drawing.Size(161, 26);
        	// 
        	// toolStripMenuItemAdd
        	// 
        	this.toolStripMenuItemAdd.Name = "toolStripMenuItemAdd";
        	this.toolStripMenuItemAdd.Size = new System.Drawing.Size(160, 22);
        	this.toolStripMenuItemAdd.Text = "Add To Reminder";
        	this.toolStripMenuItemAdd.Click += new System.EventHandler(this.AddToReminderToolStripMenuItemClick);
        	// 
        	// timerRefresh
        	// 
        	this.timerRefresh.Interval = 180000;
        	this.timerRefresh.Tick += new System.EventHandler(this.TimerRefreshTick);
        	// 
        	// buttonDBCount
        	// 
        	this.buttonDBCount.Location = new System.Drawing.Point(522, 9);
        	this.buttonDBCount.Name = "buttonDBCount";
        	this.buttonDBCount.Size = new System.Drawing.Size(77, 21);
        	this.buttonDBCount.TabIndex = 21;
        	this.buttonDBCount.Text = "DBSTAT";
        	this.buttonDBCount.UseVisualStyleBackColor = true;
        	this.buttonDBCount.Click += new System.EventHandler(this.ButtonDBCountClick);
        	// 
        	// MainForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(864, 499);
        	this.Controls.Add(this.buttonDBCount);
        	this.Controls.Add(this.progressBar);
        	this.Controls.Add(this.buttonFind);
        	this.Controls.Add(this.textBoxFind);
        	this.Controls.Add(this.comboBoxDate);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.ComboBoxNumberType);
        	this.Controls.Add(this.buttonStat);
        	this.Controls.Add(this.comboBoxSType);
        	this.Controls.Add(this.ComboBoxType);
        	this.Controls.Add(this.pictureBoxLoading);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.statusStrip1);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "MainForm";
        	this.Text = "Lottery";
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.tabControl1.ResumeLayout(false);
        	this.contextMenuStripTab.ResumeLayout(false);
        	this.tabPageSet.ResumeLayout(false);
        	this.groupBox3.ResumeLayout(false);
        	this.contextMenuStripReminder.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
        	this.contextMenuStripListView.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button buttonDBCount;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTab;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripListView;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem clearReminderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ListView listViewRealTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPageSet;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripReminder;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timerMention;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox ComboBoxType;
        private System.Windows.Forms.ComboBox comboBoxSType;
        private System.Windows.Forms.Button buttonStat;
        private System.Windows.Forms.ComboBox ComboBoxNumberType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.ListView listViewReminder;
        private System.Windows.Forms.ListView listView1;
    }
}


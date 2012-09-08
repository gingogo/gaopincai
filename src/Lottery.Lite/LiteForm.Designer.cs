namespace Lottery.Lite
{
    partial class LiteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiteForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHall = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewRealTime = new System.Windows.Forms.ListView();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.buttonStat = new System.Windows.Forms.Button();
            this.comboBoxSType = new System.Windows.Forms.ComboBox();
            this.ComboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.timerReport = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPageHall.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageHall);
            this.tabControl1.Location = new System.Drawing.Point(6, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 273);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageHall
            // 
            this.tabPageHall.Controls.Add(this.groupBox1);
            this.tabPageHall.Location = new System.Drawing.Point(4, 22);
            this.tabPageHall.Name = "tabPageHall";
            this.tabPageHall.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHall.Size = new System.Drawing.Size(562, 247);
            this.tabPageHall.TabIndex = 0;
            this.tabPageHall.Text = "Hall";
            this.tabPageHall.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewRealTime);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 235);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Real Time";
            // 
            // listViewRealTime
            // 
            this.listViewRealTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewRealTime.FullRowSelect = true;
            this.listViewRealTime.GridLines = true;
            this.listViewRealTime.Location = new System.Drawing.Point(6, 20);
            this.listViewRealTime.Name = "listViewRealTime";
            this.listViewRealTime.Size = new System.Drawing.Size(249, 210);
            this.listViewRealTime.TabIndex = 0;
            this.listViewRealTime.UseCompatibleStateImageBehavior = false;
            this.listViewRealTime.View = System.Windows.Forms.View.Details;
            // 
            // buttonFind
            // 
            this.buttonFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFind.Location = new System.Drawing.Point(554, 5);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(22, 23);
            this.buttonFind.TabIndex = 29;
            this.buttonFind.Text = "S";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFind.Location = new System.Drawing.Point(489, 7);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(59, 20);
            this.textBoxFind.TabIndex = 28;
            this.textBoxFind.TextChanged += new System.EventHandler(this.TextBoxFindTextChanged);
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Location = new System.Drawing.Point(92, 7);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(83, 21);
            this.comboBoxDate.TabIndex = 27;
            this.comboBoxDate.Text = "Due Date";
            this.comboBoxDate.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDateSelectedIndexChanged);
            // 
            // buttonStat
            // 
            this.buttonStat.Location = new System.Drawing.Point(329, 5);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(99, 23);
            this.buttonStat.TabIndex = 24;
            this.buttonStat.Text = "Caulate";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
            // 
            // comboBoxSType
            // 
            this.comboBoxSType.FormattingEnabled = true;
            this.comboBoxSType.Items.AddRange(new object[] {
            "All Spans",
            "1008 Spans"});
            this.comboBoxSType.Location = new System.Drawing.Point(181, 7);
            this.comboBoxSType.Name = "comboBoxSType";
            this.comboBoxSType.Size = new System.Drawing.Size(90, 21);
            this.comboBoxSType.TabIndex = 23;
            this.comboBoxSType.Text = "Analysis Type";
            // 
            // ComboBoxType
            // 
            this.ComboBoxType.FormattingEnabled = true;
            this.ComboBoxType.Items.AddRange(new object[] {
            "shand11x5",
            "jiangx11x5",
            "guangd11x5"});
            this.ComboBoxType.Location = new System.Drawing.Point(6, 7);
            this.ComboBoxType.Name = "ComboBoxType";
            this.ComboBoxType.Size = new System.Drawing.Size(79, 21);
            this.ComboBoxType.TabIndex = 22;
            this.ComboBoxType.Text = "jiangx11x5";
            this.ComboBoxType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType_SelectedIndexChanged);
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(277, 5);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(46, 23);
            this.buttonShow.TabIndex = 30;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 180000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // contextMenuStripTab
            // 
            this.contextMenuStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.contextMenuStripTab.Name = "contextMenuStripTab";
            this.contextMenuStripTab.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStripTab";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // timerReport
            // 
            this.timerReport.Interval = 1000;
            this.timerReport.Tick += new System.EventHandler(this.timerReport_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 312);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // LiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 334);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.comboBoxDate);
            this.Controls.Add(this.buttonStat);
            this.Controls.Add(this.comboBoxSType);
            this.Controls.Add(this.ComboBoxType);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LiteForm";
            this.Text = "LotteryLite";
            this.tabControl1.ResumeLayout(false);
            this.tabPageHall.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.contextMenuStripTab.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.ComboBox comboBoxDate;
        private System.Windows.Forms.Button buttonStat;
        private System.Windows.Forms.ComboBox comboBoxSType;
        private System.Windows.Forms.ComboBox ComboBoxType;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.TabPage tabPageHall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewRealTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTab;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Timer timerReport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;

    }
}
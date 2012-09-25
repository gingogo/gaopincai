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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tssReadyLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.leftTab = new System.Windows.Forms.TabControl();
            this.leftRealPage = new System.Windows.Forms.TabPage();
            this.cbxRealStat = new System.Windows.Forms.ComboBox();
            this.lblRealStat = new System.Windows.Forms.Label();
            this.btnReal = new System.Windows.Forms.Button();
            this.cbxRealDimesion = new System.Windows.Forms.ComboBox();
            this.lblRealDimension = new System.Windows.Forms.Label();
            this.cbxRealNumberType = new System.Windows.Forms.ComboBox();
            this.lblRealNumberType = new System.Windows.Forms.Label();
            this.cbxRealCategory = new System.Windows.Forms.ComboBox();
            this.lblRealCategory = new System.Windows.Forms.Label();
            this.leftOmissionPage = new System.Windows.Forms.TabPage();
            this.btnOmisson = new System.Windows.Forms.Button();
            this.nudOmissonPrecision = new System.Windows.Forms.NumericUpDown();
            this.lblOmissonPrecision = new System.Windows.Forms.Label();
            this.txtOmissonStartDC = new System.Windows.Forms.TextBox();
            this.lblOmissonEndDC = new System.Windows.Forms.Label();
            this.txtOmissonEndDC = new System.Windows.Forms.TextBox();
            this.lblOmissonStartDC = new System.Windows.Forms.Label();
            this.cbxOmissonDimesion = new System.Windows.Forms.ComboBox();
            this.lblOmissonDimension = new System.Windows.Forms.Label();
            this.cbxOmissonNumberType = new System.Windows.Forms.ComboBox();
            this.lblOmissonNumberType = new System.Windows.Forms.Label();
            this.cbxOmissonCategory = new System.Windows.Forms.ComboBox();
            this.lblOmissonCategory = new System.Windows.Forms.Label();
            this.leftFilterPage = new System.Windows.Forms.TabPage();
            this.leftComposiePage = new System.Windows.Forms.TabPage();
            this.rightTab = new System.Windows.Forms.TabControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.funcMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.ctxMenuRightTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asyncEventWorker = new Lottery.Components.AsyncEventWorker(this.components);
            this.ctxMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.leftTab.SuspendLayout();
            this.leftRealPage.SuspendLayout();
            this.leftOmissionPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOmissonPrecision)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.ctxMenuRightTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssReadyLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 477);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(864, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // tssReadyLabel
            // 
            this.tssReadyLabel.Name = "tssReadyLabel";
            this.tssReadyLabel.Size = new System.Drawing.Size(29, 17);
            this.tssReadyLabel.Text = "准备";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Mention";
            this.notifyIcon.Visible = true;
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
            this.progressBar.Location = new System.Drawing.Point(239, 480);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(520, 16);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 20;
            this.progressBar.Visible = false;
            // 
            // leftTab
            // 
            this.leftTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.leftTab.Controls.Add(this.leftRealPage);
            this.leftTab.Controls.Add(this.leftOmissionPage);
            this.leftTab.Controls.Add(this.leftFilterPage);
            this.leftTab.Controls.Add(this.leftComposiePage);
            this.leftTab.Location = new System.Drawing.Point(0, 50);
            this.leftTab.Margin = new System.Windows.Forms.Padding(0);
            this.leftTab.Multiline = true;
            this.leftTab.Name = "leftTab";
            this.leftTab.Padding = new System.Drawing.Point(6, 6);
            this.leftTab.SelectedIndex = 0;
            this.leftTab.Size = new System.Drawing.Size(291, 426);
            this.leftTab.TabIndex = 21;
            // 
            // leftRealPage
            // 
            this.leftRealPage.Controls.Add(this.cbxRealStat);
            this.leftRealPage.Controls.Add(this.lblRealStat);
            this.leftRealPage.Controls.Add(this.btnReal);
            this.leftRealPage.Controls.Add(this.cbxRealDimesion);
            this.leftRealPage.Controls.Add(this.lblRealDimension);
            this.leftRealPage.Controls.Add(this.cbxRealNumberType);
            this.leftRealPage.Controls.Add(this.lblRealNumberType);
            this.leftRealPage.Controls.Add(this.cbxRealCategory);
            this.leftRealPage.Controls.Add(this.lblRealCategory);
            this.leftRealPage.Location = new System.Drawing.Point(4, 28);
            this.leftRealPage.Name = "leftRealPage";
            this.leftRealPage.Size = new System.Drawing.Size(283, 394);
            this.leftRealPage.TabIndex = 3;
            this.leftRealPage.Text = "实时数据";
            this.leftRealPage.UseVisualStyleBackColor = true;
            // 
            // cbxRealStat
            // 
            this.cbxRealStat.FormattingEnabled = true;
            this.cbxRealStat.Location = new System.Drawing.Point(89, 140);
            this.cbxRealStat.Name = "cbxRealStat";
            this.cbxRealStat.Size = new System.Drawing.Size(140, 20);
            this.cbxRealStat.TabIndex = 27;
            // 
            // lblRealStat
            // 
            this.lblRealStat.AutoSize = true;
            this.lblRealStat.Location = new System.Drawing.Point(16, 148);
            this.lblRealStat.Name = "lblRealStat";
            this.lblRealStat.Size = new System.Drawing.Size(59, 12);
            this.lblRealStat.TabIndex = 26;
            this.lblRealStat.Text = "统计指标:";
            // 
            // btnReal
            // 
            this.btnReal.Location = new System.Drawing.Point(154, 183);
            this.btnReal.Name = "btnReal";
            this.btnReal.Size = new System.Drawing.Size(75, 23);
            this.btnReal.TabIndex = 25;
            this.btnReal.Text = "确定(&C)";
            this.btnReal.UseVisualStyleBackColor = true;
            this.btnReal.Click += new System.EventHandler(this.btnReal_Click);
            // 
            // cbxRealDimesion
            // 
            this.cbxRealDimesion.FormattingEnabled = true;
            this.cbxRealDimesion.Location = new System.Drawing.Point(89, 102);
            this.cbxRealDimesion.Name = "cbxRealDimesion";
            this.cbxRealDimesion.Size = new System.Drawing.Size(140, 20);
            this.cbxRealDimesion.TabIndex = 18;
            // 
            // lblRealDimension
            // 
            this.lblRealDimension.AutoSize = true;
            this.lblRealDimension.Location = new System.Drawing.Point(16, 110);
            this.lblRealDimension.Name = "lblRealDimension";
            this.lblRealDimension.Size = new System.Drawing.Size(35, 12);
            this.lblRealDimension.TabIndex = 17;
            this.lblRealDimension.Text = "维度:";
            // 
            // cbxRealNumberType
            // 
            this.cbxRealNumberType.FormattingEnabled = true;
            this.cbxRealNumberType.Location = new System.Drawing.Point(89, 61);
            this.cbxRealNumberType.Name = "cbxRealNumberType";
            this.cbxRealNumberType.Size = new System.Drawing.Size(140, 20);
            this.cbxRealNumberType.TabIndex = 16;
            this.cbxRealNumberType.SelectedIndexChanged += new System.EventHandler(this.cbxRealNumberType_SelectedIndexChanged);
            // 
            // lblRealNumberType
            // 
            this.lblRealNumberType.AutoSize = true;
            this.lblRealNumberType.Location = new System.Drawing.Point(16, 69);
            this.lblRealNumberType.Name = "lblRealNumberType";
            this.lblRealNumberType.Size = new System.Drawing.Size(59, 12);
            this.lblRealNumberType.TabIndex = 15;
            this.lblRealNumberType.Text = "号码类型:";
            // 
            // cbxRealCategory
            // 
            this.cbxRealCategory.FormattingEnabled = true;
            this.cbxRealCategory.Location = new System.Drawing.Point(89, 20);
            this.cbxRealCategory.Name = "cbxRealCategory";
            this.cbxRealCategory.Size = new System.Drawing.Size(140, 20);
            this.cbxRealCategory.TabIndex = 14;
            this.cbxRealCategory.SelectedIndexChanged += new System.EventHandler(this.cbxRealCategory_SelectedIndexChanged);
            // 
            // lblRealCategory
            // 
            this.lblRealCategory.AutoSize = true;
            this.lblRealCategory.Location = new System.Drawing.Point(16, 28);
            this.lblRealCategory.Name = "lblRealCategory";
            this.lblRealCategory.Size = new System.Drawing.Size(35, 12);
            this.lblRealCategory.TabIndex = 13;
            this.lblRealCategory.Text = "彩种:";
            // 
            // leftOmissionPage
            // 
            this.leftOmissionPage.Controls.Add(this.btnOmisson);
            this.leftOmissionPage.Controls.Add(this.nudOmissonPrecision);
            this.leftOmissionPage.Controls.Add(this.lblOmissonPrecision);
            this.leftOmissionPage.Controls.Add(this.txtOmissonStartDC);
            this.leftOmissionPage.Controls.Add(this.lblOmissonEndDC);
            this.leftOmissionPage.Controls.Add(this.txtOmissonEndDC);
            this.leftOmissionPage.Controls.Add(this.lblOmissonStartDC);
            this.leftOmissionPage.Controls.Add(this.cbxOmissonDimesion);
            this.leftOmissionPage.Controls.Add(this.lblOmissonDimension);
            this.leftOmissionPage.Controls.Add(this.cbxOmissonNumberType);
            this.leftOmissionPage.Controls.Add(this.lblOmissonNumberType);
            this.leftOmissionPage.Controls.Add(this.cbxOmissonCategory);
            this.leftOmissionPage.Controls.Add(this.lblOmissonCategory);
            this.leftOmissionPage.Location = new System.Drawing.Point(4, 28);
            this.leftOmissionPage.Name = "leftOmissionPage";
            this.leftOmissionPage.Padding = new System.Windows.Forms.Padding(3);
            this.leftOmissionPage.Size = new System.Drawing.Size(283, 394);
            this.leftOmissionPage.TabIndex = 0;
            this.leftOmissionPage.Text = "遗漏分析";
            this.leftOmissionPage.UseVisualStyleBackColor = true;
            // 
            // btnOmisson
            // 
            this.btnOmisson.Location = new System.Drawing.Point(154, 272);
            this.btnOmisson.Name = "btnOmisson";
            this.btnOmisson.Size = new System.Drawing.Size(75, 23);
            this.btnOmisson.TabIndex = 12;
            this.btnOmisson.Text = "确定(&C)";
            this.btnOmisson.UseVisualStyleBackColor = true;
            this.btnOmisson.Click += new System.EventHandler(this.btnOmisson_Click);
            // 
            // nudOmissonPrecision
            // 
            this.nudOmissonPrecision.Location = new System.Drawing.Point(89, 227);
            this.nudOmissonPrecision.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudOmissonPrecision.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudOmissonPrecision.Name = "nudOmissonPrecision";
            this.nudOmissonPrecision.Size = new System.Drawing.Size(140, 21);
            this.nudOmissonPrecision.TabIndex = 11;
            this.nudOmissonPrecision.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblOmissonPrecision
            // 
            this.lblOmissonPrecision.AutoSize = true;
            this.lblOmissonPrecision.Location = new System.Drawing.Point(16, 236);
            this.lblOmissonPrecision.Name = "lblOmissonPrecision";
            this.lblOmissonPrecision.Size = new System.Drawing.Size(59, 12);
            this.lblOmissonPrecision.TabIndex = 10;
            this.lblOmissonPrecision.Text = "数字精度:";
            // 
            // txtOmissonStartDC
            // 
            this.txtOmissonStartDC.Location = new System.Drawing.Point(129, 142);
            this.txtOmissonStartDC.Name = "txtOmissonStartDC";
            this.txtOmissonStartDC.Size = new System.Drawing.Size(100, 21);
            this.txtOmissonStartDC.TabIndex = 9;
            this.txtOmissonStartDC.Text = "0.9800";
            // 
            // lblOmissonEndDC
            // 
            this.lblOmissonEndDC.AutoSize = true;
            this.lblOmissonEndDC.Location = new System.Drawing.Point(16, 195);
            this.lblOmissonEndDC.Name = "lblOmissonEndDC";
            this.lblOmissonEndDC.Size = new System.Drawing.Size(95, 12);
            this.lblOmissonEndDC.TabIndex = 8;
            this.lblOmissonEndDC.Text = "守冷止损确定度:";
            // 
            // txtOmissonEndDC
            // 
            this.txtOmissonEndDC.Location = new System.Drawing.Point(129, 186);
            this.txtOmissonEndDC.Name = "txtOmissonEndDC";
            this.txtOmissonEndDC.Size = new System.Drawing.Size(100, 21);
            this.txtOmissonEndDC.TabIndex = 7;
            this.txtOmissonEndDC.Text = "0.9999";
            // 
            // lblOmissonStartDC
            // 
            this.lblOmissonStartDC.AutoSize = true;
            this.lblOmissonStartDC.Location = new System.Drawing.Point(16, 151);
            this.lblOmissonStartDC.Name = "lblOmissonStartDC";
            this.lblOmissonStartDC.Size = new System.Drawing.Size(95, 12);
            this.lblOmissonStartDC.TabIndex = 6;
            this.lblOmissonStartDC.Text = "守冷起始确定度:";
            // 
            // cbxOmissonDimesion
            // 
            this.cbxOmissonDimesion.FormattingEnabled = true;
            this.cbxOmissonDimesion.Location = new System.Drawing.Point(89, 102);
            this.cbxOmissonDimesion.Name = "cbxOmissonDimesion";
            this.cbxOmissonDimesion.Size = new System.Drawing.Size(140, 20);
            this.cbxOmissonDimesion.TabIndex = 5;
            // 
            // lblOmissonDimension
            // 
            this.lblOmissonDimension.AutoSize = true;
            this.lblOmissonDimension.Location = new System.Drawing.Point(16, 110);
            this.lblOmissonDimension.Name = "lblOmissonDimension";
            this.lblOmissonDimension.Size = new System.Drawing.Size(35, 12);
            this.lblOmissonDimension.TabIndex = 4;
            this.lblOmissonDimension.Text = "维度:";
            // 
            // cbxOmissonNumberType
            // 
            this.cbxOmissonNumberType.FormattingEnabled = true;
            this.cbxOmissonNumberType.Location = new System.Drawing.Point(89, 61);
            this.cbxOmissonNumberType.Name = "cbxOmissonNumberType";
            this.cbxOmissonNumberType.Size = new System.Drawing.Size(140, 20);
            this.cbxOmissonNumberType.TabIndex = 3;
            this.cbxOmissonNumberType.SelectedIndexChanged += new System.EventHandler(this.cbxOmissonNumberType_SelectedIndexChanged);
            // 
            // lblOmissonNumberType
            // 
            this.lblOmissonNumberType.AutoSize = true;
            this.lblOmissonNumberType.Location = new System.Drawing.Point(16, 69);
            this.lblOmissonNumberType.Name = "lblOmissonNumberType";
            this.lblOmissonNumberType.Size = new System.Drawing.Size(59, 12);
            this.lblOmissonNumberType.TabIndex = 2;
            this.lblOmissonNumberType.Text = "号码类型:";
            // 
            // cbxOmissonCategory
            // 
            this.cbxOmissonCategory.FormattingEnabled = true;
            this.cbxOmissonCategory.Location = new System.Drawing.Point(89, 20);
            this.cbxOmissonCategory.Name = "cbxOmissonCategory";
            this.cbxOmissonCategory.Size = new System.Drawing.Size(140, 20);
            this.cbxOmissonCategory.TabIndex = 1;
            this.cbxOmissonCategory.SelectedIndexChanged += new System.EventHandler(this.cbxOmissonCategory_SelectedIndexChanged);
            // 
            // lblOmissonCategory
            // 
            this.lblOmissonCategory.AutoSize = true;
            this.lblOmissonCategory.Location = new System.Drawing.Point(16, 28);
            this.lblOmissonCategory.Name = "lblOmissonCategory";
            this.lblOmissonCategory.Size = new System.Drawing.Size(35, 12);
            this.lblOmissonCategory.TabIndex = 0;
            this.lblOmissonCategory.Text = "彩种:";
            // 
            // leftFilterPage
            // 
            this.leftFilterPage.Location = new System.Drawing.Point(4, 28);
            this.leftFilterPage.Name = "leftFilterPage";
            this.leftFilterPage.Padding = new System.Windows.Forms.Padding(3);
            this.leftFilterPage.Size = new System.Drawing.Size(283, 394);
            this.leftFilterPage.TabIndex = 1;
            this.leftFilterPage.Text = "过滤查询";
            this.leftFilterPage.UseVisualStyleBackColor = true;
            // 
            // leftComposiePage
            // 
            this.leftComposiePage.Location = new System.Drawing.Point(4, 28);
            this.leftComposiePage.Name = "leftComposiePage";
            this.leftComposiePage.Size = new System.Drawing.Size(283, 394);
            this.leftComposiePage.TabIndex = 2;
            this.leftComposiePage.Text = "综合分析";
            this.leftComposiePage.UseVisualStyleBackColor = true;
            // 
            // rightTab
            // 
            this.rightTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rightTab.ContextMenuStrip = this.ctxMenuRightTab;
            this.rightTab.Location = new System.Drawing.Point(292, 50);
            this.rightTab.Margin = new System.Windows.Forms.Padding(0);
            this.rightTab.Name = "rightTab";
            this.rightTab.Padding = new System.Drawing.Point(6, 6);
            this.rightTab.SelectedIndex = 0;
            this.rightTab.Size = new System.Drawing.Size(571, 426);
            this.rightTab.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcMenuItem,
            this.setMenuItem,
            this.helpMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(864, 24);
            this.menuStrip.TabIndex = 22;
            this.menuStrip.Text = "menuStrip1";
            // 
            // funcMenuItem
            // 
            this.funcMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcExitMenuItem});
            this.funcMenuItem.Name = "funcMenuItem";
            this.funcMenuItem.Size = new System.Drawing.Size(59, 20);
            this.funcMenuItem.Text = "功能(&F)";
            // 
            // funcExitMenuItem
            // 
            this.funcExitMenuItem.Name = "funcExitMenuItem";
            this.funcExitMenuItem.Size = new System.Drawing.Size(112, 22);
            this.funcExitMenuItem.Text = "退出(&E)";
            // 
            // setMenuItem
            // 
            this.setMenuItem.Name = "setMenuItem";
            this.setMenuItem.Size = new System.Drawing.Size(59, 20);
            this.setMenuItem.Text = "设置(&S)";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(59, 20);
            this.helpMenuItem.Text = "帮助(&H)";
            // 
            // toolStrip
            // 
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(864, 25);
            this.toolStrip.TabIndex = 23;
            this.toolStrip.Text = "toolStrip";
            // 
            // ctxMenuRightTab
            // 
            this.ctxMenuRightTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuItemClose,
            this.ctxMenuItemCloseAll});
            this.ctxMenuRightTab.Name = "omValueCtxMenu";
            this.ctxMenuRightTab.Size = new System.Drawing.Size(137, 48);
            // 
            // asyncEventWorker
            // 
            this.asyncEventWorker.DoWork += new Lottery.Components.DoWorkEventHandler(this.asyncEventWorker_DoWork);
            this.asyncEventWorker.Completed += new Lottery.Components.WorkerCompletedEventHandler(this.asyncEventWorker_Completed);
            this.asyncEventWorker.ProgressChanged += new Lottery.Components.ProgressChangedEventHandler(this.asyncEventWorker_ProgressChanged);
            // 
            // ctxMenuItemClose
            // 
            this.ctxMenuItemClose.Name = "ctxMenuItemClose";
            this.ctxMenuItemClose.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuItemClose.Text = "关闭(&C)";
            this.ctxMenuItemClose.Click += new System.EventHandler(this.ctxMenuItemClose_Click);
            // 
            // ctxMenuItemCloseAll
            // 
            this.ctxMenuItemCloseAll.Name = "ctxMenuItemCloseAll";
            this.ctxMenuItemCloseAll.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuItemCloseAll.Text = "关闭所有(&A)";
            this.ctxMenuItemCloseAll.Click += new System.EventHandler(this.ctxMenuItemCloseAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 499);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.rightTab);
            this.Controls.Add(this.leftTab);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBoxLoading);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Lottery";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.leftTab.ResumeLayout(false);
            this.leftRealPage.ResumeLayout(false);
            this.leftRealPage.PerformLayout();
            this.leftOmissionPage.ResumeLayout(false);
            this.leftOmissionPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOmissonPrecision)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ctxMenuRightTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripStatusLabel tssReadyLabel;

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl leftTab;
        private System.Windows.Forms.TabPage leftOmissionPage;
        private System.Windows.Forms.TabPage leftFilterPage;
        private System.Windows.Forms.TabControl rightTab;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem funcMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem funcExitMenuItem;
        private System.Windows.Forms.TabPage leftComposiePage;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRightTab;
        private Components.AsyncEventWorker asyncEventWorker;
        private System.Windows.Forms.Label lblOmissonPrecision;
        private System.Windows.Forms.TextBox txtOmissonStartDC;
        private System.Windows.Forms.Label lblOmissonEndDC;
        private System.Windows.Forms.TextBox txtOmissonEndDC;
        private System.Windows.Forms.Label lblOmissonStartDC;
        private System.Windows.Forms.ComboBox cbxOmissonDimesion;
        private System.Windows.Forms.Label lblOmissonDimension;
        private System.Windows.Forms.ComboBox cbxOmissonNumberType;
        private System.Windows.Forms.Label lblOmissonNumberType;
        private System.Windows.Forms.ComboBox cbxOmissonCategory;
        private System.Windows.Forms.Label lblOmissonCategory;
        private System.Windows.Forms.Button btnOmisson;
        private System.Windows.Forms.NumericUpDown nudOmissonPrecision;
        private System.Windows.Forms.TabPage leftRealPage;
        private System.Windows.Forms.Button btnReal;
        private System.Windows.Forms.ComboBox cbxRealDimesion;
        private System.Windows.Forms.Label lblRealDimension;
        private System.Windows.Forms.ComboBox cbxRealNumberType;
        private System.Windows.Forms.Label lblRealNumberType;
        private System.Windows.Forms.ComboBox cbxRealCategory;
        private System.Windows.Forms.Label lblRealCategory;
        private System.Windows.Forms.ComboBox cbxRealStat;
        private System.Windows.Forms.Label lblRealStat;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemClose;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuItemCloseAll;
    }
}


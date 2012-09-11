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
            this.leftIndexPage = new System.Windows.Forms.TabPage();
            this.leftFilterPage = new System.Windows.Forms.TabPage();
            this.leftComposiePage = new System.Windows.Forms.TabPage();
            this.rightTab = new System.Windows.Forms.TabControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.funcMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.leftTab.SuspendLayout();
            this.menuStrip.SuspendLayout();
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
            this.leftTab.Controls.Add(this.leftIndexPage);
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
            // leftIndexPage
            // 
            this.leftIndexPage.Location = new System.Drawing.Point(4, 28);
            this.leftIndexPage.Name = "leftIndexPage";
            this.leftIndexPage.Padding = new System.Windows.Forms.Padding(3);
            this.leftIndexPage.Size = new System.Drawing.Size(283, 394);
            this.leftIndexPage.TabIndex = 0;
            this.leftIndexPage.Text = "指标分析";
            this.leftIndexPage.UseVisualStyleBackColor = true;
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
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
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
        private System.Windows.Forms.TabPage leftIndexPage;
        private System.Windows.Forms.TabPage leftFilterPage;
        private System.Windows.Forms.TabControl rightTab;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem funcMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem funcExitMenuItem;
        private System.Windows.Forms.TabPage leftComposiePage;
    }
}


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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.comboBoxDate = new System.Windows.Forms.ComboBox();
            this.buttonStat = new System.Windows.Forms.Button();
            this.comboBoxSType = new System.Windows.Forms.ComboBox();
            this.ComboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(6, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 410);
            this.tabControl1.TabIndex = 4;
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
            // 
            // comboBoxDate
            // 
            this.comboBoxDate.FormattingEnabled = true;
            this.comboBoxDate.Location = new System.Drawing.Point(92, 7);
            this.comboBoxDate.Name = "comboBoxDate";
            this.comboBoxDate.Size = new System.Drawing.Size(83, 21);
            this.comboBoxDate.TabIndex = 27;
            this.comboBoxDate.Text = "Due Date";
            // 
            // buttonStat
            // 
            this.buttonStat.Location = new System.Drawing.Point(329, 5);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(66, 23);
            this.buttonStat.TabIndex = 24;
            this.buttonStat.Text = "Caulate";
            this.buttonStat.UseVisualStyleBackColor = true;
            // 
            // comboBoxSType
            // 
            this.comboBoxSType.FormattingEnabled = true;
            this.comboBoxSType.Items.AddRange(new object[] {
            "所有周期"});
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
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(277, 5);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(46, 23);
            this.buttonShow.TabIndex = 30;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // LiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 449);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.comboBoxDate);
            this.Controls.Add(this.buttonStat);
            this.Controls.Add(this.comboBoxSType);
            this.Controls.Add(this.ComboBoxType);
            this.Controls.Add(this.tabControl1);
            this.Name = "LiteForm";
            this.Text = "LotteryLite";
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

    }
}
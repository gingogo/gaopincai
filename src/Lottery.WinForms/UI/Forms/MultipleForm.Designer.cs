namespace Lottery.WinForms.UI
{
    partial class MultipleForm
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
            this.gboxBasic = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtMaxMultiNums = new System.Windows.Forms.TextBox();
            this.txtStartMultiNums = new System.Windows.Forms.TextBox();
            this.txtNums = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPeroidNums = new System.Windows.Forms.TextBox();
            this.lblMaxMultiNums = new System.Windows.Forms.Label();
            this.lblStartMultiNums = new System.Windows.Forms.Label();
            this.lblNums = new System.Windows.Forms.Label();
            this.lblPeroid = new System.Windows.Forms.Label();
            this.gboxProfit = new System.Windows.Forms.GroupBox();
            this.btnCompute = new System.Windows.Forms.Button();
            this.lblYuan = new System.Windows.Forms.Label();
            this.txtMinProfitAmount = new System.Windows.Forms.TextBox();
            this.chkMinProfit = new System.Windows.Forms.CheckBox();
            this.lblPercent3 = new System.Windows.Forms.Label();
            this.lblPercent2 = new System.Windows.Forms.Label();
            this.txtPrevRating = new System.Windows.Forms.TextBox();
            this.lblPrevRating = new System.Windows.Forms.Label();
            this.txtRestRating = new System.Windows.Forms.TextBox();
            this.lblRestRating = new System.Windows.Forms.Label();
            this.txtPrevPeroidNums = new System.Windows.Forms.TextBox();
            this.lblPercent1 = new System.Windows.Forms.Label();
            this.txtGlobalRating = new System.Windows.Forms.TextBox();
            this.rdPeroidRating = new System.Windows.Forms.RadioButton();
            this.rdGlobalRating = new System.Windows.Forms.RadioButton();
            this.listView = new System.Windows.Forms.ListView();
            this.chPeroid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMultiNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCurrentAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCurrentProfit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalProfit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProfitRating = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gboxBasic.SuspendLayout();
            this.gboxProfit.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBasic
            // 
            this.gboxBasic.Controls.Add(this.textBox5);
            this.gboxBasic.Controls.Add(this.txtMaxMultiNums);
            this.gboxBasic.Controls.Add(this.txtStartMultiNums);
            this.gboxBasic.Controls.Add(this.txtNums);
            this.gboxBasic.Controls.Add(this.label5);
            this.gboxBasic.Controls.Add(this.txtPeroidNums);
            this.gboxBasic.Controls.Add(this.lblMaxMultiNums);
            this.gboxBasic.Controls.Add(this.lblStartMultiNums);
            this.gboxBasic.Controls.Add(this.lblNums);
            this.gboxBasic.Controls.Add(this.lblPeroid);
            this.gboxBasic.Location = new System.Drawing.Point(0, 0);
            this.gboxBasic.Name = "gboxBasic";
            this.gboxBasic.Size = new System.Drawing.Size(227, 155);
            this.gboxBasic.TabIndex = 0;
            this.gboxBasic.TabStop = false;
            this.gboxBasic.Text = "基本设置";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(84, 124);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(123, 21);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "130";
            // 
            // txtMaxMultiNums
            // 
            this.txtMaxMultiNums.Location = new System.Drawing.Point(84, 97);
            this.txtMaxMultiNums.Name = "txtMaxMultiNums";
            this.txtMaxMultiNums.Size = new System.Drawing.Size(123, 21);
            this.txtMaxMultiNums.TabIndex = 8;
            this.txtMaxMultiNums.Text = "100";
            // 
            // txtStartMultiNums
            // 
            this.txtStartMultiNums.Location = new System.Drawing.Point(84, 70);
            this.txtStartMultiNums.Name = "txtStartMultiNums";
            this.txtStartMultiNums.Size = new System.Drawing.Size(123, 21);
            this.txtStartMultiNums.TabIndex = 7;
            this.txtStartMultiNums.Text = "1";
            // 
            // txtNums
            // 
            this.txtNums.Location = new System.Drawing.Point(84, 43);
            this.txtNums.Name = "txtNums";
            this.txtNums.Size = new System.Drawing.Size(123, 21);
            this.txtNums.TabIndex = 6;
            this.txtNums.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "单倍奖金:";
            // 
            // txtPeroidNums
            // 
            this.txtPeroidNums.Location = new System.Drawing.Point(84, 16);
            this.txtPeroidNums.Name = "txtPeroidNums";
            this.txtPeroidNums.Size = new System.Drawing.Size(123, 21);
            this.txtPeroidNums.TabIndex = 4;
            this.txtPeroidNums.Text = "10";
            // 
            // lblMaxMultiNums
            // 
            this.lblMaxMultiNums.AutoSize = true;
            this.lblMaxMultiNums.Location = new System.Drawing.Point(19, 106);
            this.lblMaxMultiNums.Name = "lblMaxMultiNums";
            this.lblMaxMultiNums.Size = new System.Drawing.Size(59, 12);
            this.lblMaxMultiNums.TabIndex = 3;
            this.lblMaxMultiNums.Text = "最大倍数:";
            // 
            // lblStartMultiNums
            // 
            this.lblStartMultiNums.AutoSize = true;
            this.lblStartMultiNums.Location = new System.Drawing.Point(19, 79);
            this.lblStartMultiNums.Name = "lblStartMultiNums";
            this.lblStartMultiNums.Size = new System.Drawing.Size(59, 12);
            this.lblStartMultiNums.TabIndex = 2;
            this.lblStartMultiNums.Text = "起始倍数:";
            // 
            // lblNums
            // 
            this.lblNums.AutoSize = true;
            this.lblNums.Location = new System.Drawing.Point(19, 52);
            this.lblNums.Name = "lblNums";
            this.lblNums.Size = new System.Drawing.Size(59, 12);
            this.lblNums.TabIndex = 1;
            this.lblNums.Text = "投入注数:";
            // 
            // lblPeroid
            // 
            this.lblPeroid.AutoSize = true;
            this.lblPeroid.Location = new System.Drawing.Point(19, 25);
            this.lblPeroid.Name = "lblPeroid";
            this.lblPeroid.Size = new System.Drawing.Size(59, 12);
            this.lblPeroid.TabIndex = 0;
            this.lblPeroid.Text = "方案期数:";
            // 
            // gboxProfit
            // 
            this.gboxProfit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxProfit.Controls.Add(this.btnCompute);
            this.gboxProfit.Controls.Add(this.lblYuan);
            this.gboxProfit.Controls.Add(this.txtMinProfitAmount);
            this.gboxProfit.Controls.Add(this.chkMinProfit);
            this.gboxProfit.Controls.Add(this.lblPercent3);
            this.gboxProfit.Controls.Add(this.lblPercent2);
            this.gboxProfit.Controls.Add(this.txtPrevRating);
            this.gboxProfit.Controls.Add(this.lblPrevRating);
            this.gboxProfit.Controls.Add(this.txtRestRating);
            this.gboxProfit.Controls.Add(this.lblRestRating);
            this.gboxProfit.Controls.Add(this.txtPrevPeroidNums);
            this.gboxProfit.Controls.Add(this.lblPercent1);
            this.gboxProfit.Controls.Add(this.txtGlobalRating);
            this.gboxProfit.Controls.Add(this.rdPeroidRating);
            this.gboxProfit.Controls.Add(this.rdGlobalRating);
            this.gboxProfit.Location = new System.Drawing.Point(0, 161);
            this.gboxProfit.Name = "gboxProfit";
            this.gboxProfit.Size = new System.Drawing.Size(227, 237);
            this.gboxProfit.TabIndex = 0;
            this.gboxProfit.TabStop = false;
            this.gboxProfit.Text = "收益率设置";
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(132, 162);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(75, 23);
            this.btnCompute.TabIndex = 14;
            this.btnCompute.Text = "计算(&C)";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // lblYuan
            // 
            this.lblYuan.AutoSize = true;
            this.lblYuan.Location = new System.Drawing.Point(168, 129);
            this.lblYuan.Name = "lblYuan";
            this.lblYuan.Size = new System.Drawing.Size(17, 12);
            this.lblYuan.TabIndex = 13;
            this.lblYuan.Text = "元";
            // 
            // txtMinProfitAmount
            // 
            this.txtMinProfitAmount.Location = new System.Drawing.Point(107, 120);
            this.txtMinProfitAmount.Name = "txtMinProfitAmount";
            this.txtMinProfitAmount.Size = new System.Drawing.Size(55, 21);
            this.txtMinProfitAmount.TabIndex = 12;
            this.txtMinProfitAmount.Text = "100";
            // 
            // chkMinProfit
            // 
            this.chkMinProfit.AutoSize = true;
            this.chkMinProfit.Checked = true;
            this.chkMinProfit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMinProfit.Location = new System.Drawing.Point(21, 125);
            this.chkMinProfit.Name = "chkMinProfit";
            this.chkMinProfit.Size = new System.Drawing.Size(78, 16);
            this.chkMinProfit.TabIndex = 11;
            this.chkMinProfit.Text = "最低收益:";
            this.chkMinProfit.UseVisualStyleBackColor = true;
            // 
            // lblPercent3
            // 
            this.lblPercent3.AutoSize = true;
            this.lblPercent3.Location = new System.Drawing.Point(168, 97);
            this.lblPercent3.Name = "lblPercent3";
            this.lblPercent3.Size = new System.Drawing.Size(11, 12);
            this.lblPercent3.TabIndex = 10;
            this.lblPercent3.Text = "%";
            // 
            // lblPercent2
            // 
            this.lblPercent2.AutoSize = true;
            this.lblPercent2.Location = new System.Drawing.Point(210, 67);
            this.lblPercent2.Name = "lblPercent2";
            this.lblPercent2.Size = new System.Drawing.Size(11, 12);
            this.lblPercent2.TabIndex = 9;
            this.lblPercent2.Text = "%";
            // 
            // txtPrevRating
            // 
            this.txtPrevRating.Location = new System.Drawing.Point(160, 58);
            this.txtPrevRating.Name = "txtPrevRating";
            this.txtPrevRating.Size = new System.Drawing.Size(43, 21);
            this.txtPrevRating.TabIndex = 8;
            this.txtPrevRating.Text = "10";
            // 
            // lblPrevRating
            // 
            this.lblPrevRating.AutoSize = true;
            this.lblPrevRating.Location = new System.Drawing.Point(102, 67);
            this.lblPrevRating.Name = "lblPrevRating";
            this.lblPrevRating.Size = new System.Drawing.Size(59, 12);
            this.lblPrevRating.TabIndex = 7;
            this.lblPrevRating.Text = "期收益率:";
            // 
            // txtRestRating
            // 
            this.txtRestRating.Location = new System.Drawing.Point(114, 88);
            this.txtRestRating.Name = "txtRestRating";
            this.txtRestRating.Size = new System.Drawing.Size(48, 21);
            this.txtRestRating.TabIndex = 6;
            this.txtRestRating.Text = "50";
            // 
            // lblRestRating
            // 
            this.lblRestRating.AutoSize = true;
            this.lblRestRating.Location = new System.Drawing.Point(37, 97);
            this.lblRestRating.Name = "lblRestRating";
            this.lblRestRating.Size = new System.Drawing.Size(71, 12);
            this.lblRestRating.TabIndex = 5;
            this.lblRestRating.Text = "之后收益率:";
            // 
            // txtPrevPeroidNums
            // 
            this.txtPrevPeroidNums.Location = new System.Drawing.Point(62, 60);
            this.txtPrevPeroidNums.Name = "txtPrevPeroidNums";
            this.txtPrevPeroidNums.Size = new System.Drawing.Size(35, 21);
            this.txtPrevPeroidNums.TabIndex = 4;
            this.txtPrevPeroidNums.Text = "5";
            // 
            // lblPercent1
            // 
            this.lblPercent1.AutoSize = true;
            this.lblPercent1.Location = new System.Drawing.Point(168, 35);
            this.lblPercent1.Name = "lblPercent1";
            this.lblPercent1.Size = new System.Drawing.Size(11, 12);
            this.lblPercent1.TabIndex = 3;
            this.lblPercent1.Text = "%";
            // 
            // txtGlobalRating
            // 
            this.txtGlobalRating.Location = new System.Drawing.Point(107, 26);
            this.txtGlobalRating.Name = "txtGlobalRating";
            this.txtGlobalRating.Size = new System.Drawing.Size(55, 21);
            this.txtGlobalRating.TabIndex = 2;
            this.txtGlobalRating.Text = "50";
            // 
            // rdPeroidRating
            // 
            this.rdPeroidRating.AutoSize = true;
            this.rdPeroidRating.Location = new System.Drawing.Point(21, 65);
            this.rdPeroidRating.Name = "rdPeroidRating";
            this.rdPeroidRating.Size = new System.Drawing.Size(35, 16);
            this.rdPeroidRating.TabIndex = 1;
            this.rdPeroidRating.Text = "前";
            this.rdPeroidRating.UseVisualStyleBackColor = true;
            // 
            // rdGlobalRating
            // 
            this.rdGlobalRating.AutoSize = true;
            this.rdGlobalRating.Checked = true;
            this.rdGlobalRating.Location = new System.Drawing.Point(21, 31);
            this.rdGlobalRating.Name = "rdGlobalRating";
            this.rdGlobalRating.Size = new System.Drawing.Size(89, 16);
            this.rdGlobalRating.TabIndex = 0;
            this.rdGlobalRating.TabStop = true;
            this.rdGlobalRating.Text = "全程收益率:";
            this.rdGlobalRating.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPeroid,
            this.chMultiNum,
            this.chCurrentAmount,
            this.chTotalAmount,
            this.chCurrentProfit,
            this.chTotalProfit,
            this.chProfitRating});
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(232, 8);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(558, 390);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // chPeroid
            // 
            this.chPeroid.Text = "期数";
            // 
            // chMultiNum
            // 
            this.chMultiNum.Text = "投入倍数";
            this.chMultiNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chMultiNum.Width = 80;
            // 
            // chCurrentAmount
            // 
            this.chCurrentAmount.Text = "本期投入";
            this.chCurrentAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCurrentAmount.Width = 80;
            // 
            // chTotalAmount
            // 
            this.chTotalAmount.Text = "累计投入";
            this.chTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTotalAmount.Width = 80;
            // 
            // chCurrentProfit
            // 
            this.chCurrentProfit.Text = "本期收益";
            this.chCurrentProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCurrentProfit.Width = 80;
            // 
            // chTotalProfit
            // 
            this.chTotalProfit.Text = "盈利收益";
            this.chTotalProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTotalProfit.Width = 80;
            // 
            // chProfitRating
            // 
            this.chProfitRating.Text = "收益率";
            this.chProfitRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chProfitRating.Width = 80;
            // 
            // MultipleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 403);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.gboxProfit);
            this.Controls.Add(this.gboxBasic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MultipleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "倍投计算器";
            this.gboxBasic.ResumeLayout(false);
            this.gboxBasic.PerformLayout();
            this.gboxProfit.ResumeLayout(false);
            this.gboxProfit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxBasic;
        private System.Windows.Forms.GroupBox gboxProfit;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader chPeroid;
        private System.Windows.Forms.ColumnHeader chMultiNum;
        private System.Windows.Forms.ColumnHeader chCurrentAmount;
        private System.Windows.Forms.ColumnHeader chTotalAmount;
        private System.Windows.Forms.ColumnHeader chCurrentProfit;
        private System.Windows.Forms.ColumnHeader chTotalProfit;
        private System.Windows.Forms.ColumnHeader chProfitRating;
        private System.Windows.Forms.TextBox txtPeroidNums;
        private System.Windows.Forms.Label lblMaxMultiNums;
        private System.Windows.Forms.Label lblStartMultiNums;
        private System.Windows.Forms.Label lblNums;
        private System.Windows.Forms.Label lblPeroid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtMaxMultiNums;
        private System.Windows.Forms.TextBox txtStartMultiNums;
        private System.Windows.Forms.TextBox txtNums;
        private System.Windows.Forms.Label lblPercent1;
        private System.Windows.Forms.TextBox txtGlobalRating;
        private System.Windows.Forms.RadioButton rdPeroidRating;
        private System.Windows.Forms.RadioButton rdGlobalRating;
        private System.Windows.Forms.TextBox txtPrevPeroidNums;
        private System.Windows.Forms.Label lblPercent3;
        private System.Windows.Forms.Label lblPercent2;
        private System.Windows.Forms.TextBox txtPrevRating;
        private System.Windows.Forms.Label lblPrevRating;
        private System.Windows.Forms.TextBox txtRestRating;
        private System.Windows.Forms.Label lblRestRating;
        private System.Windows.Forms.Label lblYuan;
        private System.Windows.Forms.TextBox txtMinProfitAmount;
        private System.Windows.Forms.CheckBox chkMinProfit;
        private System.Windows.Forms.Button btnCompute;
    }
}
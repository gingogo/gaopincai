using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms
{
    using Caching;
    using Components;
    using Configuration;
    using Data.SQLServer.Common;
    using Helpers;
    using Model.Common;
    using Task;
    using Utils;
    using UI;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        #region Initialize Data

        private void InitializeData()
        {
            this.SetLeftTabControlComboBoxItems();
        }

        #endregion

        #region Menu Handlers

        private void funcExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ToolStrip Handlers

        private void tsbCaculator_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void tsbMultiple_Click(object sender, EventArgs e)
        {
            using (MultipleForm form = new MultipleForm())
            {
                form.ShowDialog();
            }
        }

        #endregion

        #region Context Menu Handlers

        private void ctxMenuItemClose_Click(object sender, EventArgs e)
        {
            this.rightTab.Controls.RemoveAt(this.rightTab.SelectedIndex);
        }

        private void ctxMenuItemCloseAll_Click(object sender, EventArgs e)
        {
            this.rightTab.Controls.Clear();
        }

        #endregion

        #region Left TabControl Handlers

        private void cbxRealCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox categoryComboBox = sender as ComboBox;
            if (categoryComboBox == null) return;

            Category category = categoryComboBox.SelectedItem as Category;
            if (category == null) return;

            this.SetNumberTypeComboBox(category.RuleType, this.cbxRealNumberType);
        }

        private void cbxRealNumberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox numberTypeComboBox = sender as ComboBox;
            if (numberTypeComboBox == null) return;

            NumberType numberType = numberTypeComboBox.SelectedItem as NumberType;
            if (numberType == null) return;

            Category category = this.cbxRealCategory.SelectedItem as Category;
            if (category == null) return;

            this.SetDimensionComboBox(category.Type, numberType.Code, this.cbxRealDimesion);
        }

        private void cbxOmissonCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox categoryComboBox = sender as ComboBox;
            if (categoryComboBox == null) return;

            Category category = categoryComboBox.SelectedItem as Category;
            if (category == null) return;

            this.SetNumberTypeComboBox(category.RuleType, this.cbxOmissonNumberType);
        }

        private void cbxOmissonNumberType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox numberTypeComboBox = sender as ComboBox;
            if (numberTypeComboBox == null) return;

            NumberType numberType = numberTypeComboBox.SelectedItem as NumberType;
            if (numberType == null) return;

            Category category = this.cbxOmissonCategory.SelectedItem as Category;
            if (category == null) return;

            this.SetDimensionComboBox(category.Type, numberType.Code, this.cbxOmissonDimesion);
        }

        private void btnReal_Click(object sender, EventArgs e)
        {
        }

        private void btnOmisson_Click(object sender, EventArgs e)
        {
            this.btnOmisson.Enabled = false;

            Category category = this.cbxOmissonCategory.SelectedItem as Category;
            NumberType numberType = this.cbxOmissonNumberType.SelectedItem as NumberType;
            Dimension dimension = this.cbxOmissonDimesion.SelectedItem as Dimension;
            
            OmissionParameter parameter = new OmissionParameter();
            parameter.Sender = sender as Button;
            parameter.Worker = this.asyncEventWorker;
            parameter.CategoryName = category.Name;
            parameter.NumberTypeName = numberType.Name;
            parameter.DimensionName = dimension.Name;
            parameter.DbName = category.DbName;
            parameter.RuleType = category.RuleType;
            parameter.NumberType = numberType.Code;
            parameter.Dimension = dimension.Code;
            parameter.StartDC = ConvertHelper.GetDouble(this.txtOmissonStartDC.Text, 0.989);
            parameter.EndDC = ConvertHelper.GetDouble(this.txtOmissonEndDC.Text, 0.9999);
            parameter.Precision = (int)this.nudOmissonPrecision.Value;
            parameter.Target = this.rightTab;
            parameter.OrderByColName = "CurrentSpans";
            parameter.SortType = "DESC";
            parameter.Filter = string.Empty;
            parameter.UserState = Guid.NewGuid();
            parameter.Owner = this;

            TaskArguments arguments = new TaskArguments(new OmissionValueTask(), parameter);
            this.asyncEventWorker.RunAsync(parameter.UserState, arguments);

            this.SetProgressBar();
        }

        #endregion

        #region AsyncEventWorker Handlers

        private void asyncEventWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            TaskArguments arguments = args.Argument as TaskArguments;
            if (arguments == null) return;
            arguments.Task.Start(arguments.Parameter);
        }

        private void asyncEventWorker_ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            this.progressBar.Value = args.ProgressPercentage;
            this.SetStatusText(args.ProgressPercentage.ToString() + "%");
        }

        private void asyncEventWorker_Completed(object sender, WorkerCompletedEventArgs args)
        {
            TaskArguments arguments = args.Argument as TaskArguments;
            if (arguments == null) return;

            arguments.Parameter.Sender.Enabled = true;
            try
            {
                arguments.Task.Complete(arguments.Parameter);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.DisplayFailure(ex.Message);
            }

            this.pictureBoxLoading.Visible = false;
            this.progressBar.Visible = false;
        }

        #endregion

        #region Outer Control Handlers

        public void OmissionValueListViewColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView == null) return;

            OmissionParameter parameter = listView.Tag as OmissionParameter;
            if (parameter == null) return;

            parameter.UserState = Guid.NewGuid();
            parameter.StartDC = ConvertHelper.GetDouble(this.txtOmissonStartDC.Text, 0.989);
            parameter.EndDC = ConvertHelper.GetDouble(this.txtOmissonEndDC.Text, 0.9999);
            parameter.OrderByColName = listView.Columns[e.Column].Name;
            parameter.SortType = parameter.SortType.Equals("DESC") ? "ASC" : "DESC";

            TaskArguments arguments = new TaskArguments(new OmissionValueTask(), parameter);
            this.asyncEventWorker.RunAsync(parameter.UserState, arguments);

            this.SetProgressBar();
        }

        public void OmissionValueListViewContextMenuItemClick(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem == null) return;

            OmissionParameter parameter = menuItem.Tag as OmissionParameter;
            if (parameter == null) return;

            if (menuItem.Name.Contains("refresh"))
            {
                parameter.UserState = Guid.NewGuid();
                parameter.StartDC = ConvertHelper.GetDouble(this.txtOmissonStartDC.Text, 0.989);
                parameter.EndDC = ConvertHelper.GetDouble(this.txtOmissonEndDC.Text, 0.9999);
                TaskArguments arguments = new TaskArguments(new OmissionValueTask(), parameter);
                this.asyncEventWorker.RunAsync(parameter.UserState, arguments);

                this.SetProgressBar();
                return;
            }
        }

        #endregion

        #region Helper methods for modifying the UI display

        private void SetLeftTabControlComboBoxItems()
        {
            this.cbxOmissonCategory.Items.Clear();
            this.cbxRealCategory.Items.Clear();

            this.cbxRealCategory.DisplayMember = Category.C_Name;
            this.cbxOmissonCategory.DisplayMember = Category.C_Name;

            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories();
            foreach (var category in categories)
            {
                this.cbxRealCategory.Items.Add(category);
                this.cbxOmissonCategory.Items.Add(category);
            }

            this.cbxOmissonCategory.SelectedIndex = 0;
            this.cbxRealCategory.SelectedIndex = 0;
        }

        private void SetNumberTypeComboBox(string ruleType, ComboBox numberTypeComboBox)
        {
            numberTypeComboBox.Items.Clear();
            numberTypeComboBox.DisplayMember = NumberType.C_Name;

            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetList(ruleType);
            foreach (var numberType in numberTypes)
            {
                numberTypeComboBox.Items.Add(numberType);
            }

            numberTypeComboBox.SelectedIndex = 0;
        }

        private void SetDimensionComboBox(string ruleType, string numberType, ComboBox dimensionComboBox)
        {
            dimensionComboBox.Items.Clear();
            dimensionComboBox.DisplayMember = Dimension.C_Name;

            List<Dimension> dimensions = DimensionNumberTypeBiz.Instance.GetDimensions(ruleType, numberType);
            foreach (var dimension in dimensions)
            {
                dimensionComboBox.Items.Add(dimension);
            }

            dimensionComboBox.SelectedIndex = 0;
        }

        private void SetProgressBar()
        {
            this.progressBar.Visible = true;
            this.progressBar.Value = 0;
            this.pictureBoxLoading.Visible = true;
        }

        public void SetStatusText(string readyText)
        {
            this.SetStatusText(readyText, string.Empty, string.Empty);
        }

        public void SetStatusText(string categoryText, string countText)
        {
            this.SetStatusText("完成", categoryText, countText);
        }

        public void SetStatusText(string readyText,string categoryText,string countText)
        {
            this.tssReadyLabel.Text = readyText;
            this.tssLblCategory.Text = categoryText;
            this.tssLblCount.Text = countText;
        }

        #endregion
    }
}


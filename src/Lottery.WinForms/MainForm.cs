using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms
{
    using Components;
    using Configuration;
    using Data.SQLServer.Common;
    using Model.Common;
    using Task;
    using Utils;

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
            parameter.StartDC = ConvertHelper.GetDouble(this.txtOmissonStartDC.Text, 0.959);
            parameter.EndDC = ConvertHelper.GetDouble(this.txtOmissonEndDC.Text, 0.999);
            parameter.Precision = (int)this.nudOmissonPrecision.Value;
            parameter.Target = this.rightTab;
            parameter.OrderByColName = "CurrentSpans";
            parameter.SortType = "DESC";
            parameter.Filter = string.Empty;
            parameter.UserState = Guid.NewGuid();

            TaskArguments arguments = new TaskArguments(new OmissionValueTask(), parameter);
            this.asyncEventWorker.RunAsync(parameter.UserState, arguments);

            this.progressBar.Visible = true;
            this.progressBar.Value = 0;
            this.pictureBoxLoading.Visible = true;
            this.btnOmisson.Enabled = false;
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
            this.SetStatus(args.ProgressPercentage.ToString() + "%");
        }

        private void asyncEventWorker_Completed(object sender, WorkerCompletedEventArgs args)
        {
            TaskArguments arguments = args.Argument as TaskArguments;
            if (arguments == null) return;

            arguments.Parameter.Sender.Enabled = true;
            arguments.Task.Set(arguments.Parameter);

            this.pictureBoxLoading.Visible = false;
            this.progressBar.Visible = false;
            this.SetStatus("完成");
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

        private void SetStatus(string text)
        {
            this.tssReadyLabel.Text = text;
        }

        #endregion
    }
}


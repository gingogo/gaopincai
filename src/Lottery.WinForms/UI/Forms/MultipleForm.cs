using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lottery.WinForms.UI
{
    using Model.Analysis;
    using Analysis.Formula;
    using ViewData;
    using Utils;

    public partial class MultipleForm : Form
    {
        public MultipleForm()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            MultiParameter parameter = new MultiParameter();
            parameter.PeroidNums = ConvertHelper.GetInt32(this.txtPeroidNums.Text);
            parameter.Nums = ConvertHelper.GetInt32(this.txtNums.Text);
            parameter.StartMultiNums = ConvertHelper.GetInt32(this.txtStartMultiNums.Text);
            parameter.MaxMultiNums = ConvertHelper.GetInt32(this.txtMaxMultiNums.Text);
            parameter.Prize = ConvertHelper.GetDouble(this.txtPrize.Text);
            parameter.IsGlobal = this.rdGlobalRating.Checked;
            parameter.GlobalRating = ConvertHelper.GetDouble(this.txtGlobalRating.Text) / 100.0;
            parameter.PrevPeroidNums = ConvertHelper.GetInt32(this.txtPrevPeroidNums.Text);
            parameter.PrevPeroidRating = ConvertHelper.GetDouble(this.txtPrevPeroidNums.Text) / 100.0;
            parameter.RestPeroidRating = ConvertHelper.GetDouble(this.txtRestRating.Text) / 100.0;
            parameter.MinProfitAmount = ConvertHelper.GetDouble(this.txtMinProfitAmount.Text);

            this.FillListView(ProfitOrLoss.GetMultiProfitRates(parameter));
        }

        private void FillListView(List<ProfitRate> profitRates)
        {
            foreach (var profitRate in profitRates)
            {
                var viewData = new ProfitRateViewData(profitRate);
                ListViewItem item = new ListViewItem(viewData.PeroidNums);
                item.Tag = viewData.PeroidNums;
                item.SubItems.Add(viewData.MultiNums);
                item.SubItems.Add(viewData.CurrentAmount);
                item.SubItems.Add(viewData.TotalAmount);
                item.SubItems.Add(viewData.CurrentProfit);
                item.SubItems.Add(viewData.TotalProfit);
                item.SubItems.Add(viewData.ProfitRating);
                this.listView.Items.Add(item);
            }
        }
    }
}

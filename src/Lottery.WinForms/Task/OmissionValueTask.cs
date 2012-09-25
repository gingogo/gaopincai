using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms.Task
{
    using Analysis.Common;
    using Caching;
    using Data.SQLServer.Analysis;
    using Model.Analysis;
    using ViewData;

    public class OmissionValueTask : ITask
    {
        private List<OmissionValueViewData> viewDatas;

        public void Start(Parameter parameter)
        {
            OmissionParameter param = parameter as OmissionParameter;
            if (param == null) return;

            var omValues = this.GetSortedOmissionValues(param);
            this.viewDatas = new List<OmissionValueViewData>(omValues.Count);

            int progressCount = 0;
            int total = omValues.Count;
            foreach (var omv in omValues)
            {
                this.viewDatas.Add(new OmissionValueViewData(param.StartDC, param.EndDC, omv));
                int percent = (int)((float)(++progressCount) / (float)total * 100);
                param.Worker.ReportProgress(percent, param.UserState);
            }
        }

        public void Set(Parameter parameter)
        {
            OmissionParameter param = parameter as OmissionParameter;
            if (param == null) return;

            TabControl target = parameter.Target as TabControl;
            if (target == null) return;

            string pageKey = string.Format("{0}|{1}|{2}", param.DbName, param.NumberType, param.Dimension);
            string pageText = string.Format("{0}|{1}|{2}", param.CategoryName, param.NumberTypeName, param.DimensionName);
            string listViewKey = "omv_" + pageKey;

            TabPage tabPage = this.GetTabPage(target, pageKey, pageText);
            ListView listView = this.GetListView(tabPage, listViewKey, param);
            this.FillListView(listView, param.Precision);

            target.SelectedTab = tabPage;

            param.Owner.SetStatusText(pageText, string.Format("号码个数:{0}", this.viewDatas.Count));
        }

        private List<OmissionValue> GetSortedOmissionValues(OmissionParameter param)
        {
            OmissionValueLys lys = new OmissionValueLys(param.DbName);
            List<OmissionValue> omValues = null;

            if (Cache.OmissonValueColumnHeaders[param.OrderByColName].IsDbSort)
            {
                omValues = lys.GetOmissionValues(param.RuleType, param.NumberType, param.Dimension, param.Filter, param.OrderByColName, param.SortType);
            }
            else
            {
                omValues = lys.GetOmissionValues(param.RuleType, param.NumberType, param.Dimension, param.Filter);
                omValues = param.SortType.Equals("DESC") ?
                    omValues.OrderByDescending(x => x[param.OrderByColName]).ToList() :
                    omValues.OrderBy(x => x[param.OrderByColName]).ToList();
            }

            return omValues;
        }

        private TabPage GetTabPage(TabControl target, string key, string text)
        {
            if (target.Controls.ContainsKey(key))
                return target.Controls[key] as TabPage;

            TabPage tabPage = new TabPage(text);
            tabPage.Dock = DockStyle.Fill;
            tabPage.Name = key;
            target.Controls.Add(tabPage);

            return tabPage;
        }

        private ListView GetListView(Control tabPage, string key, OmissionParameter param)
        {
            ListView listView = null;

            if (tabPage.Controls.ContainsKey(key))
            {
                listView = tabPage.Controls[key] as ListView;
                listView.Items.Clear();
                listView.Tag = param;
                return listView;
            }

            listView = new ListView();
            listView.Name = key;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Tag = param;

            this.AddListViewColumnHeaders(listView);
            this.AddListViewEvents(listView, param);
            tabPage.Controls.Add(listView);

            return listView;
        }

        private void AddListViewColumnHeaders(ListView listView)
        {
            foreach (var kv in Cache.OmissonValueColumnHeaders)
            {
                ColumnHeader colHeader = new ColumnHeader();
                colHeader.Text = kv.Value.Text;
                colHeader.Width = kv.Value.Width;
                colHeader.Name = kv.Value.Key;
                listView.Columns.Add(colHeader);
            }
        }

        private void AddListViewEvents(ListView listView, OmissionParameter param)
        {
            listView.ColumnClick += new ColumnClickEventHandler(param.Owner.OmissionValueListViewColumnClick);

            listView.ContextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem("查看(&V)", param.Owner.OmissionValueListViewContextMenuItemClick);
            menuItem.Name = "omv_view";
            listView.ContextMenu.MenuItems.Add(menuItem);
            menuItem = new MenuItem("公式(&F)", param.Owner.OmissionValueListViewContextMenuItemClick);
            menuItem.Name = "omv_formula";
            listView.ContextMenu.MenuItems.Add(menuItem);
        }

        private void FillListView(ListView listView, int precision)
        {
            var maxAvgDcDict = this.viewDatas.GroupBy(x => x.Nums)
                .ToDictionary(x => x.Key, y => new MaxAvgDC(y.Max(z => z.HistoryMaxDC), y.Average(z => z.HistoryMaxDC)));
  
            string prec = string.Format("F{0}", precision);
            foreach (var viewData in this.viewDatas)
            {
                string tag = string.Format("{0}-{1}-{2}-{3}",
                    viewData.RuleType, viewData.NumberType, viewData.Dimension, viewData.NumberId);
                ListViewItem item = new ListViewItem(viewData.NumberId);
                item.Tag = tag;
                item.SubItems.Add(viewData.CurrentSpans.ToString());
                item.SubItems.Add(viewData.LastSpans.ToString());
                item.SubItems.Add(viewData.MaxSpans.ToString());
                item.SubItems.Add(viewData.AvgSpans.ToString(prec));
                item.SubItems.Add(viewData.CurrentDC.ToString(prec));
                item.SubItems.Add(viewData.HistoryMaxDC.ToString(prec));
                item.SubItems.Add(maxAvgDcDict[viewData.Nums].AvgDC.ToString(prec));
                item.SubItems.Add(maxAvgDcDict[viewData.Nums].MaxDC.ToString(prec));
                item.SubItems.Add(viewData.WatchColdN.ToString("F2"));
                item.SubItems.Add(viewData.State.ToString("F2"));
                item.SubItems.Add(viewData.OccurRating.ToString(prec));
                item.SubItems.Add(viewData.InvestmentValue.ToString(prec));
                item.SubItems.Add(viewData.ReturnRating.ToString(prec));
                item.SubItems.Add(viewData.PeroidCount.ToString());
                item.SubItems.Add(viewData.Cycle.ToString());
                item.SubItems.Add(viewData.ActualTimes.ToString());
                item.SubItems.Add(viewData.TheoryTimes.ToString());
                item.SubItems.Add(viewData.Frequency.ToString(prec));           
                item.SubItems.Add(viewData.Nums.ToString());
                item.SubItems.Add(viewData.Probability.ToString(prec));
                item.SubItems.Add(viewData.Prize.ToString("F2"));
                item.SubItems.Add(viewData.Amount.ToString("F2"));
                item.BackColor = this.GetColor(viewData, maxAvgDcDict[viewData.Nums]);
                listView.Items.Add(item);
            }
        }

        private Color GetColor(OmissionValueViewData viewData, MaxAvgDC maxAvgDc)
        {
            if (viewData.CurrentDC >= maxAvgDc.MaxDC) return Color.Red;
            if (viewData.CurrentDC >= viewData.EndDC) return Color.Yellow;
            if (viewData.CurrentDC >= maxAvgDc.AvgDC) return Color.Violet;
            if (viewData.CurrentDC >= viewData.HistoryMaxDC && viewData.CurrentDC >= viewData.StartDC) return Color.YellowGreen;
            if (viewData.CurrentDC >= viewData.StartDC) return Color.GreenYellow;
            return Color.White;
        }

        private class MaxAvgDC
        {
            public MaxAvgDC(double maxDC, double avgDC)
            {
                this.MaxDC = maxDC;
                this.AvgDC = avgDC;
            }

            public double MaxDC { get; set; }

            public double AvgDC { get; set; }
        }
    }

    public class OmissionParameter : Parameter
    {
        public OmissionParameter() { }

        public string CategoryName { get; set; }

        public string NumberTypeName { get; set; }

        public string DimensionName { get; set; }

        public string DbName { get; set; }

        public string RuleType { get; set; }

        public string NumberType { get; set; }

        public string Dimension { get; set; }

        public double StartDC { get; set; }

        public double EndDC { get; set; }

        public int Precision { get; set; }

        public string OrderByColName { get; set; }

        public string Filter { get; set; }

        public string SortType { get; set; }
    }
}

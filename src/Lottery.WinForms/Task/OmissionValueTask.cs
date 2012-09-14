using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery.WinForms.Task
{
    using Analysis.Common;
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

            OmissionValueLys lys = new OmissionValueLys(param.DbName);
            List<OmissionValue> omValues = lys.GetOmissionValues(param.RuleType, param.NumberType, param.Dimension,
                param.Filter, param.OrderByColName, param.SortType);
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

            string pageKey = string.Format("{0}-{1}-{2}", param.DbName, param.NumberType, param.Dimension);
            string pageText = string.Format("{0}-{1}-{2}", param.CategoryName, param.NumberTypeName, param.DimensionName);
            string listViewKey = "listview1";

            Control target = parameter.Target;
            TabPage tabPage = this.GetTabPage(target, pageKey, pageText);
            ListView listView = this.GetListView(tabPage, listViewKey);
            this.FillListView(listView, param.Precision);
        }

        private TabPage GetTabPage(Control target, string key, string text)
        {
            if (target.Controls.ContainsKey(key))
            {
                return target.Controls[key] as TabPage;
            }

            TabPage tabPage = new TabPage(text);
            tabPage.Dock = DockStyle.Fill;
            tabPage.Name = key;
            target.Controls.Add(tabPage);

            return tabPage;
        }

        private ListView GetListView(Control tabPage, string key)
        {
            if (tabPage.Controls.ContainsKey(key))
            {
                ListView oldListView = tabPage.Controls[key] as ListView;
                oldListView.Items.Clear();
                return oldListView;
            }

            ListView listView = new ListView();
            listView.Name = key;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            tabPage.Controls.Add(listView);

            Dictionary<string, string> header = this.GetHeader();
            foreach (var kv in header)
            {
                listView.Columns.Add(kv.Key, kv.Value, kv.Value.Length * 20);
            }

            return listView;
        }

        private void FillListView(ListView listView, int precision)
        {
            var maxDcDict = this.viewDatas.GroupBy(x => x.Nums).ToDictionary(x => x.Key, y => y.Max(z => z.MaxDC));
            string prec = string.Format("F{0}", precision);
            foreach (var viewData in this.viewDatas)
            {
                string tag = string.Format("{0}-{1}-{2}-{3}",
                    viewData.RuleType, viewData.NumberType, viewData.Dimension, viewData.NumberType);
                ListViewItem item = new ListViewItem(viewData.NumberId);
                item.Tag = tag;
                item.SubItems.Add(viewData.CurrentSpans.ToString());
                item.SubItems.Add(viewData.LastSpans.ToString());
                item.SubItems.Add(viewData.MaxSpans.ToString());
                item.SubItems.Add(viewData.AvgSpans.ToString(prec));
                item.SubItems.Add(viewData.DC.ToString(prec));
                item.SubItems.Add(maxDcDict[viewData.Nums].ToString(prec));
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
                item.BackColor = this.GetColor(viewData.StartDC, viewData.EndDC, maxDcDict[viewData.Nums], viewData.DC);
                listView.Items.Add(item);
            }
        }

        private Dictionary<string, string> GetHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>(25);
            header.Add("NumberId", "号码");
            header.Add("CurrentSpans", "本期遗漏");
            header.Add("LastSpans", "上期遗漏");
            header.Add("MaxSpans", "最大遗漏");
            header.Add("AvgSpans", "平均遗漏");
            header.Add("DC", "当前确定度");
            header.Add("MaxDC", "最大确定度");
            header.Add("WatchColdN", "守冷期数");
            header.Add("State", "偏态值");
            header.Add("OccurRating", "欲出几率");
            header.Add("InvestmentValue", "投资价值");
            header.Add("ReturnRating", "回补几率");
            header.Add("PeroidCount", "总期数"); 
            header.Add("Cycle", "循环周期");
            header.Add("ActualTimes", "出现次数");
            header.Add("TheoryTimes", "理论出现次数");
            header.Add("Frequency", "出现频率");
            header.Add("Nums", "注数");
            header.Add("Probability", "概率");
            header.Add("Prize", "奖金");
            header.Add("Amount", "投注金额"); 

            return header;
        }

        private Color GetColor(double startDC, double endDC, double maxDC,double currentDC)
        {
            Color color = Color.White;
            if (currentDC >= startDC) color = Color.Violet;
            if (currentDC >= maxDC) color = Color.Yellow;
            if (currentDC >= endDC) color = Color.Red;
            return color;
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

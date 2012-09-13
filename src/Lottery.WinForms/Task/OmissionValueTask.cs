using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lottery.WinForms.Task
{
    using Components;
    using Data.SQLServer.Common;
    using Model.Common;
    using ViewData;

    public class OmissionValueTask : ITask
    {
        private List<OmissionValueViewData> viewDatas;

        public void Start(Parameter parameter)
        {
            OmissionParameter param = parameter as OmissionParameter;
            if (param == null) return;

            OmissionValueBiz biz = new OmissionValueBiz(param.DbName);
            List<OmissionValue> omValues = biz.GetAll(param.RuleType, param.NumberType, param.Dimension,
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

            return listView;
        }

        private void FillListView(ListView listView, int precision)
        {
            Dictionary<string,string> header = this.GetHeader();
            foreach (var kv in header)
            {
                listView.Columns.Add(kv.Key, kv.Value, kv.Value.Length * 20);
            }

            string prec = string.Format("F{0}", precision);
            //设置各列的值
            ListViewItem[] items = new ListViewItem[this.viewDatas.Count];
            for (int i = 0; i < viewDatas.Count; i++)
            {
                string tag = string.Format("{0}-{1}-{2}-{3}",
                    viewDatas[i].RuleType, viewDatas[i].NumberType, viewDatas[i].Dimension, viewDatas[i].NumberType);
                items[i] = new ListViewItem(viewDatas[i].NumberId);
                items[i].Tag = tag;
                items[i].SubItems.Add(viewDatas[i].CurrentSpans.ToString());
                items[i].SubItems.Add(viewDatas[i].DC.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].MaxSpans.ToString());
                items[i].SubItems.Add(viewDatas[i].MaxDC.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].WatchColdN.ToString("F2"));
                items[i].SubItems.Add(viewDatas[i].State.ToString("F2"));
                items[i].SubItems.Add(viewDatas[i].OccurRating.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].InvestmentValue.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].ReturnRating.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].PeroidCount.ToString());
                items[i].SubItems.Add(viewDatas[i].Cycle.ToString());
                items[i].SubItems.Add(viewDatas[i].ActualTimes.ToString());
                items[i].SubItems.Add(viewDatas[i].TheoryTimes.ToString());
                items[i].SubItems.Add(viewDatas[i].Frequency.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].LastSpans.ToString());
                items[i].SubItems.Add(viewDatas[i].AvgSpans.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].Nums.ToString());
                items[i].SubItems.Add(viewDatas[i].Probability.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].Prize.ToString("F2"));
                items[i].SubItems.Add(viewDatas[i].Amount.ToString("F2"));
                items[i].SubItems.Add(viewDatas[i].StDev.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].StDevP.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].Var.ToString(prec));
                items[i].SubItems.Add(viewDatas[i].VarP.ToString(prec));
                items[i].BackColor = this.GetColor(viewDatas[i].StartDC, viewDatas[i].EndDC, viewDatas[i].MaxDC, viewDatas[i].DC);
            }
            listView.Items.AddRange(items);
        }

        private Dictionary<string, string> GetHeader()
        {
            Dictionary<string, string> header = new Dictionary<string, string>(25);
            header.Add("NumberId", "号码");
            header.Add("CurrentSpans", "本期遗漏");
            header.Add("DC", "当前确定度");
            header.Add("MaxSpans", "最大遗漏");
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
            header.Add("LastSpans", "上期遗漏");
            header.Add("AvgSpans", "平均遗漏");
            header.Add("Nums", "注数");
            header.Add("Probability", "概率");
            header.Add("Prize", "奖金");
            header.Add("Amount", "投注金额"); 
            header.Add("StDev", "标准偏差"); 
            header.Add("StDevP", "总体标准偏差");
            header.Add("Var", "方差"); 
            header.Add("VarP", "总体方差");

            return header;
        }

        private Color GetColor(double startDC, double endDC, double maxDC,double currentDC)
        {
            if (currentDC >= maxDC) return Color.Red;
            if (currentDC >= endDC) return Color.Yellow;
            if (currentDC >= startDC) return Color.Violet;
            return Color.White;
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

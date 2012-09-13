using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //添加表头
            for(int i=0;i<20;i++)
            {
                listView.Columns.Add(i.ToString(), 60);
            }

            //设置宽度
            //if (lvd.width != null)
            //{
            //    for (int w = 0; w < lvd.width.Length; w++)
            //    {
            //        lv.Columns[w].Width = lvd.width[w];
            //    }
            //}

            //设置各列的值
            ListViewItem[] items = new ListViewItem[this.viewDatas.Count];
            for (int l = 0; l < viewDatas.Count; l++)
            {
                items[l] = new ListViewItem(viewDatas[l].NumberId);
                //item[l].SubItems[0].BackColor = Color.Red; //用于设置某行的背景颜色
            }
            listView.Items.AddRange(items);
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

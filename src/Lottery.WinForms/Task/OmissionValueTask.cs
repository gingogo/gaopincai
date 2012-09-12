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

    public class OmissionValueTask : ITask
    {
        public void Start(object userState, Parameter parameter)
        {
            OmissionParameter param = parameter as OmissionParameter;
            if (param == null) return;

            OmissionValueBiz biz = new OmissionValueBiz(param.DbName);
            List<OmissionValue> omValues = biz.GetAll(param.RuleType, param.NumberType, param.Dimension,
                param.Filter, param.OrderByColName, param.SortType);
        }
    }

    public class OmissionParameter : Parameter
    {
        public OmissionParameter() { }

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

        public TabControl RightTabControl { get; set; }
    }
}

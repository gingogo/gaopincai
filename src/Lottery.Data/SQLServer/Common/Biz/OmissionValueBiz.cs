using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Configuration;

    public class OmissionValueBiz : CommonBiz<OmissionValueDAO, OmissionValue>
    {
        public OmissionValueBiz(string dbName)
            : base(new OmissionValueDAO(ConfigHelper.GetConnString(dbName)))
        {
        }

        public override List<OmissionValue> GetAll(params string[] columnNames)
        {
            return new List<OmissionValue>();
        }

        public List<OmissionValue> GetAll(string ruleType, string numberType, string dimension, string filter,
            string orderByColName, SortTypeEnum sortType)
        {
            return this.DataAccessor.SelectOmissionValues(ruleType, numberType, dimension, filter, orderByColName, sortType);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Analysis.Common
{
    using Configuration;
    using Data.SQLServer.Analysis;
    using Model.Analysis;

    public class OmissionValueLys
    {
        private OmissionValueDAO _dao;

        public OmissionValueLys(string dbName)
        {
            this._dao = new OmissionValueDAO(ConfigHelper.GetConnString(dbName));
        }

        public List<OmissionValue> GetOmissionValues(string ruleType, string numberType, string dimension, string filter,
            string orderByColName, string sortType)
        {
            return this._dao.SelectOmissionValues(ruleType, numberType, dimension, filter, orderByColName, sortType);
        }
    }
}

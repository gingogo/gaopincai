using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;

    public class DwNumberDAO : SinglePKDataAccess<DwNumber>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DwNumberDAO(string connectionString)
            : base(DwNumber.EntityName, DwNumber.C_P, connectionString)
        { }

        public DwNumberDAO(string tableName, string connectionString)
            : base(tableName, DwNumber.C_P, connectionString)
        {
        }

        public DwNumberDAO(string tableName, string primaryKey, string connectionString)
            : base(tableName, primaryKey, connectionString)
        {
        }

        protected override DwNumber DataReaderToEntity(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr", "未将对象引用到实例");
            }
            return EntityMapper.GetEntity<DwNumber>(dr, new DwNumber(), this._tableName);
        }

        protected override DataFieldMapTable GetDataFieldMapTable(DwNumber dto, params string[] columnNames)
        {
            if (dto == null)
            {
                throw new ArgumentNullException("dto", "未将对象引用到实例");
            }
            return EntityMapper.GetMapTable<DwNumber>(dto, columnNames);
        }

        public int SelectLatestDate(string condition)
        {
            string sqlCmd = string.Format("SELECT Max(date) as date FROM {0} {1} ", this._tableName, condition);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sqlCmd));
        }

        public List<DwNumber> SelectDistinctDate()
        {
            string sqlCmd = string.Format("select distinct date from {0} order by date asc", this._tableName);
            List<DwNumber> entities = base.GetEntities(sqlCmd, new string[] { DwNumber.C_Date });
            return entities;
        }

        public DwNumber SelectLastOneBySeq(string numberId, string columnName, string filter)
        {
            string condition = string.Format("where {0} = '{1}' {2} ", columnName, numberId.Trim(), filter);
            var list = this.SelectTopN(1, condition, DwNumber.C_Seq, SortTypeEnum.DESC, null);
            return (list == null || list.Count == 0) ? null : list[0];
        }

        public Dictionary<string, int> SelectPeroidSpansByNumberTypes(DwNumber number, string filter,params string[] numberTypes)
        {
            if (numberTypes == null || numberTypes.Length == 0)
                numberTypes = new string[] { "D1", "F2", "F3", "C2", "C3", "A5" };

            string sqlFormat = "select top 1 {0},{1} from {2} where {0} = '{3}' {4} order by {1} desc;" ;
            StringBuilder batchSqlBuilder = new StringBuilder();
            foreach (string numberType in numberTypes)
            {
                batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName,
                    number[numberType].ToString(), filter);
            }

            List<DwNumber> list = this.GetEntities(batchSqlBuilder.ToString());
            Dictionary<string, int> spanDict = new Dictionary<string, int>(6);
            foreach (string numberType in numberTypes)
            {
                string value = number[numberType].ToString();
                DwNumber dwNumber = list.FirstOrDefault(x => x[numberType] != null && x[numberType].ToString().Equals(value));
                if (dwNumber == null)
                {
                    spanDict.Add(numberType, -1);
                    continue;
                }
                spanDict.Add(numberType, number.Seq - dwNumber.Seq - 1);
            }

            return spanDict;
        }

        /// <summary>
        /// 获取指定号码在今天出现的期数，来判断该号码今天是否出现
        /// </summary>
        /// <param name="numberId">号码</param>
        /// <param name="columnName">号码类型</param>
        /// <returns></returns>
        public string GetPeroidInToday(string numberId, string columnName)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string sql = "select n from " + this.TableName + " where numberId = '" + numberId + "' and date = '" + today + "'";
            object result = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql);
            if (result != null)
                return result.ToString();
            else
                return null;
        }

        /// <summary>
        /// 获取指定号码在指定日期前最后一次出现的期数
        /// </summary>
        /// <param name="numberId">号码</param>
        /// <param name="columnName">号码类型</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public string GetPeroidBefore(string numberId, string columnName, DateTime dt)
        {
            string today = dt.ToString("yyyyMMdd");
            string sql = string.Format("select top 1 p from {0} where {1} = '{2}' and date < {3} ", this._tableName, columnName, numberId, today);
            object result = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql);
            return (result != null) ? result.ToString() : null;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lottery.Data.SQLServer.SSC
{
    using Model.SSC;
    using Utils;

    public class DwNumberDAO : SinglePKDataAccess<DwNumber>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DwNumberDAO(string connectionString)
            : base(DwNumber.ENTITYNAME, DwNumber.C_P, connectionString)
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

        /// <summary>
        /// 获取开奖号码每个维度的间隔.
        /// </summary>
        /// <param name="number">开奖号码</param>
        /// <param name="dmName">维度名称(区分大小写,取值为:Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="numberTypes">号码类型</param>
        /// <returns></returns>
        public Dictionary<string, int> SelectSpansByNumberTypes(DwNumber number, string dmName, string filter, params string[] numberTypes)
        {
            if (numberTypes == null || numberTypes.Length == 0)
                numberTypes = new string[] { "D1", "P2", "P3", "P4", "P5", "C2", "C3" };

            if (dmName.Equals("Peroid"))
                return this.SelectPeroidSpansByNumberTypes(number, filter, numberTypes);

            string sqlCmd = this.GetBatchSql(number, dmName, filter, numberTypes);
            List<DwDmFCANumber> list = this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToDwDmFCANumber);
            Dictionary<string, int> spanDict = new Dictionary<string, int>(6);

            foreach (string numberType in numberTypes)
            {
                DwDmFCANumber dwNumber = list.FirstOrDefault(x => x.Id != null && x.Id.Equals(numberType));
                if (dwNumber == null || dwNumber.Seq == 0)
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
            string sql = "select p from " + this.TableName + " where " + columnName + " = '" + numberId + "' and date = '" + today + "'";
            object result = SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sql);
            if (result != null)
                return result.ToString();
            else
                return null;
        }

        public List<DwDmFCANumber> SelectDmNumbersOrderBySeq(string numberType, SortTypeEnum sortType)
        {
           string sqlFormat = "select t1.*,t2.{0},t2.Seq from Dm{0} t1,{1} t2 where t1.Id = t2.{0} order by t2.Seq {2};";
           string sqlCmd = string.Format(sqlFormat, numberType, this._tableName, sortType.ToString());
           return this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToDwDmFCANumber);
        }

        #region 私有方法

        private Dictionary<string, int> SelectPeroidSpansByNumberTypes(DwNumber number, string filter, params string[] numberTypes)
        {
            string sqlCmd = this.GetBatchSql(number, "Peroid", filter, numberTypes);
            List<DwNumber> list = this.GetEntities(sqlCmd);
            Dictionary<string, int> spanDict = new Dictionary<string, int>(6);

            foreach (string numberType in numberTypes)
            {
                DwNumber dwNumber = list.FirstOrDefault(x => x.C2 != null && x.C2.Equals(numberType));
                if (dwNumber == null || dwNumber.Seq == 0)
                {
                    spanDict.Add(numberType, -1);
                    continue;
                }
                spanDict.Add(numberType, number.Seq - dwNumber.Seq - 1);
            }

            return spanDict;
        }

        private string GetBatchSql(DwNumber number, string dmName, string filter, string[] numberTypes)
        {
            string sqlFormat = string.Empty;
            StringBuilder batchSqlBuilder = new StringBuilder();

            if (dmName.Equals("Peroid"))
            {
                //select "D1|P2|P3|xxx" C2,Max(Seq) Seq from DwNumber where A5 = 'xxxxx';
                sqlFormat = "select '{0}' C2,Max({1}) {1} from {2} where {0} = '{3}' {4};";
                foreach (string numberType in numberTypes)
                {
                    string typeValue = number[numberType].ToString();
                    batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName, typeValue, filter);
                }

                return batchSqlBuilder.ToString();
            }

            //select top 1 'D1|P2|P3|xxx' Id,Max(t2.Seq) Seq from DmP5 t1,DwNumber t2 where t1.Id = t2.P5 and t1.DaXiao = 'x|x|x|x|x';
            sqlFormat = "select '{0}' Id,Max(t2.{1}) Seq from Dm{0} t1,{2} t2 where t1.Id = t2.{0} and t1.{3} = '{4}' {5};"; 
            foreach (string numberType in numberTypes)
            {
                string dmValue = number[numberType].GetDmValue(1, dmName, 4);
                batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName, dmName, dmValue, filter);
            }

            return batchSqlBuilder.ToString();
        }

        private DwDmFCANumber DataReaderToDwDmFCANumber(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr", "未将对象引用到实例");
            }
            return EntityMapper.GetEntity<DwDmFCANumber>(dr, new DwDmFCANumber(), this._tableName);
        }

        #endregion
    }
}


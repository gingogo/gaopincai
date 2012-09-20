using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lottery.Data.SQLServer.D3
{
    using Model.D3;
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

        #region 公有方法

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
        /// <param name="numberTypes">号码类型</param>
        /// <returns></returns>
        public Dictionary<string, int> SelectSpansByNumberTypes(DwNumber number, string dmName, string[] numberTypes)
        {
            if (numberTypes == null || numberTypes.Length == 0)
                throw new ArgumentException("numberTypes is null or length is zero", "numberTypes");

            string sqlCmd = this.GetBatchSpanQuerySql(number, dmName,numberTypes);
            List<NumberIdSeq> list = this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToNumberIdSeq);
            Dictionary<string, int> numberIdSeqDict = list.ToDictionary(x => x.Id, y => y.Seq);
            Dictionary<string, int> spanDict = new Dictionary<string, int>(7);

            foreach (string numberType in numberTypes)
            {
                int seq = numberIdSeqDict.ContainsKey(numberType) ? numberIdSeqDict[numberType] : 0;
                if (seq == 0)
                {
                    spanDict.Add(numberType, -1);
                    continue;
                }
                spanDict.Add(numberType, number.Seq - seq - 1);
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

        #endregion

        #region 私有方法

        private string GetBatchSpanQuerySql(DwNumber number, string dmName, string[] numberTypes)
        {
            string sqlFormat = string.Empty;
            StringBuilder batchSqlBuilder = new StringBuilder();

            if (dmName.Equals("Peroid"))
            {
                //select "D1|P2|xx" Id,Max(Seq) Seq from DwNumber where C5 = 'xxxxx';
                sqlFormat = "select '{0}' Id,Max({1}) {1} from {2} where {0} = '{3}';";
                foreach (string numberType in numberTypes)
                {
                    string typeValue = number[numberType].ToString();
                    batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName, typeValue);
                }
                return batchSqlBuilder.ToString();
            }

            //select top 1 'D1|P2|C5|xxx' Id,Max(t2.Seq) Seq from DmC5 t1,DwNumber t2 where t1.Id = t2.C5 and t1.DaXiao = 'x|x|x|x|x';
            sqlFormat = "select '{0}' Id,Max(t2.{1}) {1} from Dm{5} t1,{2} t2 where t1.Id = t2.{0} and t1.{3} = '{4}';";
            foreach (string numberType in numberTypes)
            {
                string dmValue = number[numberType].GetDmValue(1, dmName, 4);
                batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName, dmName, dmValue, numberType.GetDmTableSuffix());
            }
            return batchSqlBuilder.ToString();
        }

        private NumberIdSeq DataReaderToNumberIdSeq(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr", "未将对象引用到实例");
            }
            return EntityMapper.GetEntity<NumberIdSeq>(dr, new NumberIdSeq(), this._tableName);
        }

        private string GetTableSuffix(string numberType)
        {
            return (numberType[0] == 'D') ? "Dx" : numberType;
        }

        #endregion

        #region 内部类

        /// <summary>
        /// 号码Id与Seq对。
        /// </summary>
        private class NumberIdSeq
        {
            private string _id;
            private int _seq;

            public NumberIdSeq() { }

            /// <summary>
            /// 获取或设置号码的ID
            /// </summary>
            [Column("Id")]
            public string Id
            {
                get { return this._id; }
                set { this._id = value; }
            }

            /// <summary>
            /// 获取或设置号码出现的顺序
            /// </summary>
            [Column("Seq")]
            public int Seq
            {
                get { return this._seq; }
                set { this._seq = value; }
            }
        }

        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.Common;
    using Model.D11X5;
    using Utils;

    /// <summary>
    /// DwC5CXSpan提供表(DwC5C[2,3,4,6,7,8]Span)的相关数据访问操作的类。
    /// </summary>
    public class DwC5CXSpanDAO
        : BaseDataAccess<DwC5CXSpan>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="tableName">表名</param>  
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DwC5CXSpanDAO(string tableName, string connectionString)
            : base(tableName, connectionString)
        { }

        #region 实现BaseDataAccess类的抽象方法

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的字段（列）名</param>
        /// <returns>数据传输对象实例</returns>
        protected override DwC5CXSpan DataReaderToEntity(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
                throw new ArgumentNullException("dr", "未将对象引用到实例");

            return EntityMapper.GetEntity(dr, new DwC5CXSpan(), this._tableName);
        }

        /// <summary>
        /// 将数据传输对象的属性值转化为DataFieldMap对应的键值(用于插入或者更新操作)
        /// </summary>
        /// <param name="dto">有效的数据传输对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的列名</param>
        /// <returns>包含键值映射的DataFieldMap</returns>
        protected override DataFieldMapTable GetDataFieldMapTable(DwC5CXSpan dto, params string[] columnNames)
        {
            if (dto == null)
                throw new ArgumentNullException("dto", "未将对象引用到实例");

            return EntityMapper.GetMapTable(dto, columnNames);
        }

        #endregion

        #region 特定数据访问方法

        public long SelectLatestPeroid(string condition)
        {
            string sqlCmd = string.Format("SELECT Max(P) as P FROM {0} {1} ", this._tableName, condition);
            return Convert.ToInt64(SqlHelper.ExecuteScalar(this.ConnectionString, CommandType.Text, sqlCmd));
        }

        /// <summary>
        /// 获取开奖号码每个维度的间隔.
        /// </summary>
        /// <param name="c5cxNumbers">c5cx号码集合</param>
        /// <param name="currentSeq">当前期数</param>
        /// <param name="tableName">DwC5C2|3|4|6|7|8Spans</param>
        /// <param name="dmNames">维度名称(区分大小写,取值为:Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, int>> SelectLastSpans(List<DmC5CX> c5cxNumbers,int currentSeq, string tableName, string[] dmNames)
        {
            if (c5cxNumbers == null || c5cxNumbers.Count == 0)
                throw new ArgumentException("c5cxNumbers is null or count is zero", "c5cxNumbers");

            Dictionary<string, Dictionary<string, int>> lastSpanDict = new Dictionary<string, Dictionary<string, int>>(dmNames.Length);

            foreach (string dmName in dmNames)
            {
                Dictionary<string, int> dmSpanDict = new Dictionary<string, int>(c5cxNumbers.Count);
                string sqlCmd = this.GetBatchSpanQuerySql(c5cxNumbers, tableName, dmName);
                List<NumberIdSeq> numberIdSeqs = this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToNumberIdSeq);
                foreach (var numberIdSeq in numberIdSeqs)
                {
                    int spans = dmSpanDict.ContainsKey(numberIdSeq.Id) ? -1 : (currentSeq - numberIdSeq.Seq - 1);
                    dmSpanDict.Add(numberIdSeq.Id, spans);
                }
                lastSpanDict.Add(dmName, dmSpanDict);
            }

            return lastSpanDict;
        }

        #endregion

        #region 私有方法

        private string GetBatchSpanQuerySql(List<DmC5CX> c5cxNumbers, string tableName,string dmName)
        {
            string sqlFormat = string.Empty;
            StringBuilder batchSqlBuilder = new StringBuilder();

            if (dmName.Equals("Peroid"))
            {
                //select "CX" Id,Max(Seq) Seq from tableName where CX = 'xxxxx';
                sqlFormat = "select '{0}' Id,Max({1}) {1} from {2} where CX = '{0}';";
                foreach (var c5cxNumber in c5cxNumbers)
                {
                    batchSqlBuilder.AppendFormat(sqlFormat, c5cxNumber.CX, "Seq", tableName);
                }
                return batchSqlBuilder.ToString();
            }

            //select 'CX' Id,Max(t2.Seq) Seq from DmC5 t1,DwNumber t2 where t1.Id = t2.C5 and t1.He = 'x|x|x|x|x';
            sqlFormat = "select '{0}' Id,Max(t2.{1}) {1} from Dm{5} t1,{2} t2 where t1.Id = t2.{0} and t1.{3} = '{4}';";
            foreach (var c5cxNumber in c5cxNumbers)
            {
                //string dmValue = number[numberType].GetDmValue(2, dmName, 5);
                //batchSqlBuilder.AppendFormat(sqlFormat, numberType, DwNumber.C_Seq, this._tableName, dmName, dmValue, numberType.GetDmTableSuffix());
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
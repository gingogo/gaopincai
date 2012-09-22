using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Lottery.Data.SQLServer.Analysis
{
    using Model.Analysis;
    using Configuration;
    using Utils;

    /// <summary>
    /// OmissionValueDAO提供表(OmissionValue)的相关数据访问操作的类。
    /// </summary>
    public class OmissionValueDAO : BaseSelect<OmissionValue>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public OmissionValueDAO(string connectionString)
            : base(OmissionValue.ENTITYNAME, connectionString)
        { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="tableName">表名</param>  
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public OmissionValueDAO(string tableName, string connectionString)
            : base(tableName, connectionString)
        { }

        #region 实现BaseDataAccess类的抽象方法

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的字段（列）名</param>
        /// <returns>数据传输对象实例</returns>
        protected override OmissionValue DataReaderToEntity(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
                throw new ArgumentNullException("dr", "未将对象引用到实例");

            return EntityMapper.GetEntity(dr, new OmissionValue(), OmissionValue.ENTITYNAME);
        }

        #endregion

        #region 特定数据访问方法

        public List<OmissionValue> SelectOmissionValues(string ruleType, string numberType, string dimension, string filter,
            string orderByColName, string sortType)
        {
            string sqlCmd = this.GetSqlCommand(ruleType, numberType, dimension, filter, orderByColName, sortType);
            return this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToEntity);
        }

        #endregion

        #region 私有方法

        private string GetSqlCommand(string ruleType, string numberType, string dimension, string filter, string orderByColName, string sortType)
        {
            if (dimension.Equals("Peroid"))
                return this.GetPeroidDimSqlCommand(ruleType, numberType, filter, orderByColName, sortType);
            return this.GetOtherDimSqlCommand(ruleType, numberType, dimension, filter, orderByColName, sortType);
        }

        private string GetPeroidDimSqlCommand(string ruleType, string numberType, string filter, string orderByColName, string sortType)
        {
            string spanColNamePrefix = numberType.GetSpanColumnPrefix();
            string dmTableNameSuffix = numberType.GetDmTableSuffix();
            string normNumberType = numberType.GetNormNumberType();

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT tmp.RuleType,tmp.NumberType,tmp.Dimension,tmp.NumberId,");
            sqlBuilder.Append("tmp.PeroidCount,'1' as Nums,tmp.ActualTimes,");
            sqlBuilder.AppendFormat("tmp.CurrentSpans,tmp.MaxSpans,t2.{0}Spans as LastSpans,", spanColNamePrefix);
            sqlBuilder.Append("tmp.AvgSpans,t3.Probability,t3.Prize,t3.Amount FROM ( ");
            sqlBuilder.Append("SELECT ");
            sqlBuilder.AppendFormat("'{0}' as RuleType,", ruleType);
            sqlBuilder.AppendFormat("'{0}' as NumberType,", numberType);
            sqlBuilder.Append("'Peroid' as Dimension,");
            sqlBuilder.AppendFormat("t1.{0} as NumberId,", spanColNamePrefix);
            sqlBuilder.Append("Max(t1.P) as P,");
            sqlBuilder.AppendFormat("(SELECT COUNT(*) FROM DwNumber) as PeroidCount,");
            sqlBuilder.Append("COUNT(*) as ActualTimes,");
            sqlBuilder.Append("(SELECT COUNT(*) FROM DwNumber)-MAX(t1.Seq) as CurrentSpans,");
            sqlBuilder.AppendFormat("MAX(t2.{0}Spans) as MaxSpans,", spanColNamePrefix);
            sqlBuilder.AppendFormat("AVG(Convert(float,t2.{0}Spans)) as AvgSpans ", spanColNamePrefix);
            sqlBuilder.AppendFormat("FROM DwNumber t1,DwPeroidSpan t2,Dm{0} t3 ", dmTableNameSuffix);
            sqlBuilder.AppendFormat("WHERE t1.P = t2.P and t1.{0} = t3.Id and t3.NumberType = '{1}' ", spanColNamePrefix, normNumberType);
            sqlBuilder.AppendFormat("GROUP BY t1.{0}) as tmp,DwPeroidSpan t2,{1}.dbo.NumberType t3 ", spanColNamePrefix, ConfigHelper.CommonDBName);
            sqlBuilder.AppendFormat("WHERE tmp.P = t2.P and tmp.NumberType = t3.Code and tmp.RuleType = t3.RuleType {0} ", filter);
            sqlBuilder.AppendFormat("ORDER BY tmp.{0} {1}", orderByColName, sortType);

            return sqlBuilder.ToString();
        }

        private string GetOtherDimSqlCommand(string ruleType, string numberType, string dimension, string filter, string orderByColName, string sortType)
        {
            string spanColNamePrefix = numberType.GetSpanColumnPrefix();
            string dmTableNameSuffix = numberType.GetDmTableSuffix();
            string normNumberType = numberType.GetNormNumberType();

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT tmp.RuleType,tmp.NumberType,tmp.Dimension,tmp.NumberId,");
            sqlBuilder.Append("tmp.PeroidCount,t4.Nums,tmp.ActualTimes,");
            sqlBuilder.AppendFormat("tmp.CurrentSpans,tmp.MaxSpans,t2.{0}Spans as LastSpans,", spanColNamePrefix);
            sqlBuilder.Append("tmp.AvgSpans,t4.Probability,t3.Prize,t4.Amount FROM ( ");
            sqlBuilder.Append("SELECT ");
            sqlBuilder.AppendFormat("'{0}' as RuleType,", ruleType);
            sqlBuilder.AppendFormat("'{0}' as NumberType,", numberType);
            sqlBuilder.AppendFormat("'{0}' as Dimension,", dimension);
            sqlBuilder.AppendFormat("t3.{0} as NumberId,", dimension);
            sqlBuilder.Append("Max(t1.P) as P,");
            sqlBuilder.Append("(SELECT COUNT(*) FROM DwNumber) as PeroidCount,");
            sqlBuilder.Append("COUNT(*) as ActualTimes,");
            sqlBuilder.Append("(SELECT COUNT(*) FROM DwNumber)-MAX(t1.Seq) as CurrentSpans,");
            sqlBuilder.AppendFormat("MAX(t2.{0}Spans) as MaxSpans,", spanColNamePrefix);
            sqlBuilder.AppendFormat("AVG(Convert(float,t2.{0}Spans)) as AvgSpans ", spanColNamePrefix);
            sqlBuilder.AppendFormat("FROM DwNumber t1,Dw{0}Span t2,Dm{1} t3 ", dimension, dmTableNameSuffix);
            sqlBuilder.AppendFormat("WHERE t1.P = t2.P and t1.{0} = t3.Id and t3.NumberType = '{1}' ", spanColNamePrefix, normNumberType);
            sqlBuilder.AppendFormat("GROUP BY t3.{0}) as tmp,Dw{0}Span t2,", dimension);
            sqlBuilder.AppendFormat("{0}.dbo.NumberType t3,{0}.dbo.DimensionNumberType t4 ", ConfigHelper.CommonDBName);
            sqlBuilder.Append("WHERE tmp.P = t2.P ");
            sqlBuilder.Append("and tmp.NumberType = t3.Code ");
            sqlBuilder.Append("and tmp.RuleType = t3.RuleType ");
            sqlBuilder.Append("and t4.Dimension= tmp.Dimension  ");
            sqlBuilder.Append("and t4.DimValue = tmp.NumberId  ");
            sqlBuilder.Append("and t4.NumberType = t3.Code  ");
            sqlBuilder.AppendFormat("and t4.RuleType = t3.RuleType {0} ", filter);
            sqlBuilder.AppendFormat("ORDER BY tmp.{0} {1}", orderByColName, sortType);

            return sqlBuilder.ToString();
        }


        #endregion
    }
}
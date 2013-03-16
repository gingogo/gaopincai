using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Lottery.Data.SQLServer.D3
{
    using Data.D3;
    using Model.Common;
    using Model.D3;
    using Utils;

    /// <summary>
    /// DmFCAnDAO提供表(DmDx,DmPx,DmCx)的相关数据访问操作的类。
    /// </summary>
    public class DmDPCDAO
        : SinglePKDataAccess<DmDPC>,IDmDPCDAO
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        //public DmFCAnDAO(string connectionString)
        //    : base(DmFCAnDTO.ENTITYNAME, DmFCAnDTO.C_ID, connectionString)
        //{ }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="name">表名</param>  
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DmDPCDAO(string tableName, string connectionString)
            : base(tableName, DmDPC.C_Id, connectionString)
        { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="name">表名</param>  
        /// <param name="primaryKey">表的单主键名称</param>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DmDPCDAO(string tableName, string primaryKey, string connectionString)
            : base(tableName, primaryKey, connectionString)
        { }

        #region 实现BaseDataAccess类的抽象方法

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的字段（列）名</param>
        /// <returns>数据传输对象实例</returns>
        protected override DmDPC DataReaderToEntity(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
                throw new ArgumentNullException("dr", "未将对象引用到实例");

            return EntityMapper.GetEntity(dr, new DmDPC(), this._tableName);
        }

        /// <summary>
        /// 将数据传输对象的属性值转化为DataFieldMap对应的键值(用于插入或者更新操作)
        /// </summary>
        /// <param name="dto">有效的数据传输对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的列名</param>
        /// <returns>包含键值映射的DataFieldMap</returns>
        protected override DataFieldMapTable GetDataFieldMapTable(DmDPC dto, params string[] columnNames)
        {
            if (dto == null)
                throw new ArgumentNullException("dto", "未将对象引用到实例");

            return EntityMapper.GetMapTable(dto, columnNames);
        }

        #endregion

        #region 特定数据访问方法

        public List<DimensionNumberType> SelectNumberTypeDimGroupBy(string[] dimensions, string numberType)
        {
            string sqlCmd = this.GetBatchSql(dimensions, numberType);
            return this.GetEntities(sqlCmd, null, CommandType.Text, this.DataReaderToNumberTypeDim,
                DimensionNumberType.C_Dimension, DimensionNumberType.C_DimValue, DimensionNumberType.C_Nums);
        }

        #endregion

        #region 私有方法

        private string GetBatchSql(string[] dimensions, string numberType)
        {
            string sqlFormat = string.Empty;

            StringBuilder batchSqlBuilder = new StringBuilder();
            //select 'DaXiao' Dimension, DaXiao DimValue,COUNT(*) Nums from DmD1 where NumberType = 'C2' group by DaXiao order by Nums asc;
            sqlFormat = "select '{0}' Dimension, {0} DimValue,COUNT(*) Nums from Dm{1} where NumberType='{2}' group by {0} order by Nums asc;";
            foreach (string dimension in dimensions)
            {
                batchSqlBuilder.AppendFormat(sqlFormat, dimension, numberType.GetDmTableSuffix(), numberType.GetNormNumberType());
            }

            return batchSqlBuilder.ToString();
        }


        private DimensionNumberType DataReaderToNumberTypeDim(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr", "未将对象引用到实例");
            }
            return EntityMapper.GetEntity<DimensionNumberType>(dr, new DimensionNumberType(), this._tableName);
        }
        #endregion
    }
}
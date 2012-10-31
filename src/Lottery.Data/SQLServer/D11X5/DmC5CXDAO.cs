﻿using System;
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
    /// DmC5CX提供表(DmC5CX)的相关数据访问操作的类。
    /// </summary>
    public class DmC5CXDAO
        : BaseDataAccess<DmC5CX>
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DmC5CXDAO(string connectionString)
            : base(DmC5CX.ENTITYNAME, connectionString)
        { }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="tableName">表名</param>  
        /// <param name="connectionString">当前表的数据库连接字符串</param>
        public DmC5CXDAO(string tableName, string connectionString)
            : base(tableName, connectionString)
        { }

        #region 实现BaseDataAccess类的抽象方法

        /// <summary>
        /// 将DataReader的属性值转化为实体类的属性值，返回实体类
        /// </summary>
        /// <param name="dr">有效的DataReader对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的字段（列）名</param>
        /// <returns>数据传输对象实例</returns>
        protected override DmC5CX DataReaderToEntity(SqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
        {
            if (dr == null)
                throw new ArgumentNullException("dr", "未将对象引用到实例");

            return EntityMapper.GetEntity(dr, new DmC5CX(), DmC5CX.ENTITYNAME);
        }

        /// <summary>
        /// 将数据传输对象的属性值转化为DataFieldMap对应的键值(用于插入或者更新操作)
        /// </summary>
        /// <param name="dto">有效的数据传输对象</param>
        /// <param name="columnNames">该数据传输对象中对应的数据库表的列名</param>
        /// <returns>包含键值映射的DataFieldMap</returns>
        protected override DataFieldMapTable GetDataFieldMapTable(DmC5CX dto, params string[] columnNames)
        {
            if (dto == null)
                throw new ArgumentNullException("dto", "未将对象引用到实例");

            return EntityMapper.GetMapTable(dto, columnNames);
        }

        #endregion

        #region 特定数据访问方法

        #endregion
    }
}
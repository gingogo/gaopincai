using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Lottery.Data.MySQL.D11X5
{
	using Data.D11X5;
	using Model.D11X5;

	/// <summary>
	/// DwSpanDAO提供各维度间隔表(DwXXXXSpan)的相关数据访问操作的类。
	/// </summary>
	public class DwSpanDAO
		: BaseDataAccess<DwSpan>,IDwSpanDAO
	{
		/// <summary>
		/// 构造函数。
		/// </summary>
		/// <param name="name">表名</param>
		/// <param name="connectionString">当前表的数据库连接字符串</param>
		public DwSpanDAO(string tableName, string connectionString)
			: base(tableName, connectionString)
		{ }

		#region 实现BaseDataAccess类的抽象方法

		/// <summary>
		/// 将DataReader的属性值转化为实体类的属性值，返回实体类
		/// </summary>
		/// <param name="dr">有效的DataReader对象</param>
		/// <param name="columnNames">该数据传输对象中对应的数据库表的字段（列）名</param>
		/// <returns>数据传输对象实例</returns>
		protected override DwSpan DataReaderToEntity(MySqlDataReader dr, MetaDataTable metaDataTable, params string[] columnNames)
		{
			if (dr == null)
				throw new ArgumentNullException("dr", "未将对象引用到实例");

			return EntityMapper.GetEntity(dr, new DwSpan(), this._tableName);
		}

		/// <summary>
		/// 将数据传输对象的属性值转化为DataFieldMap对应的键值(用于插入或者更新操作)
		/// </summary>
		/// <param name="dto">有效的数据传输对象</param>
		/// <param name="columnNames">该数据传输对象中对应的数据库表的列名</param>
		/// <returns>包含键值映射的DataFieldMap</returns>
		protected override DataFieldMapTable GetDataFieldMapTable(DwSpan dto, params string[] columnNames)
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
			object obj = MySqlHelper.ExecuteScalar(this.ConnectionString,  sqlCmd);
			string s = obj.ToString();
			return Convert.ToInt64(string.IsNullOrEmpty(s)? "0" : s);
		}
		
		public DataSet SelectTopNSpan(string num,int N,string p)
		{
			//判断num是前几，暂时是前2，tom改成自动的吧
			string sql = "SELECT TOP " + N + " DwNumber.P2,DwNumber.P,DwPeroidSpan.P2Spans FROM DwNumber INNER JOIN DwPeroidSpan ON DwNumber.P = DwPeroidSpan.P";
			sql = sql+  " WHERE DwNumber.P2 = '" + num + "' and DwNumber.P < '"+p+"' order by DwNumber.P desc";
			DataSet ds = MySqlHelper.ExecuteDataset(this.ConnectionString,  sql);
			return ds;
		}

		public int SelectMaxSpan(string num)
		{
			//判断num是前几，暂时是前2，tom改成自动的吧
			string sql = "SELECT max(DwPeroidSpan.P2Spans) FROM DwNumber INNER JOIN DwPeroidSpan ON DwNumber.P = DwPeroidSpan.P";
			sql += " WHERE DwNumber.P2 = '"+ num+"'";
			return (int)MySqlHelper.ExecuteScalar(this.ConnectionString,  sql);
		}

		public int SelectAvgSpan(string num)
		{
			//判断num是前几，暂时是前2，tom改成自动的吧
			string sql = "SELECT avg(DwPeroidSpan.P2Spans) FROM DwNumber INNER JOIN DwPeroidSpan ON DwNumber.P = DwPeroidSpan.P";
			sql += " WHERE DwNumber.P2 = '" + num + "'";
			return (int)MySqlHelper.ExecuteScalar(this.ConnectionString,  sql);
		}

		#endregion

		#region 私有方法

		#endregion
	}
}
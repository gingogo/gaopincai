using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Data
{
    /// <summary>
    /// 单主键实体基本业务逻辑类的泛型基类
    /// </summary>
    /// <typeparam name="U">数据访问层接口</typeparam>
    /// <typeparam name="T">实体对象</typeparam>
    public abstract class SinglePKDataAccessBiz<U, T> : BaseDataAccessBiz<U, T> 
        where U : IBaseDataAccess<T>, ISinglePKDataAccess<T>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataAccessor">数据访问器对象</param>
        protected SinglePKDataAccessBiz(U dataAccessor)
            : base(dataAccessor)
        {
        }

        /// <summary>
        /// 查询数据库,判断指定标识的记录是否存在。
        /// </summary>
        /// <param name="id">指定的记录的唯一标识</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool IsExist(int id)
        {
            return this.DataAccessor.IsExistKey(id);
        }

        /// <summary>
        /// 查询数据库,判断指定标识的记录是否存在。
        /// </summary>
        /// <param name="id">指定的记录的唯一标识</param>
        /// <returns>存在则返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool IsExist(string id)
        {
            return this.DataAccessor.IsExistKey(id);
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象(用于整型主键)。
        /// </summary>
        /// <param name="id">指定对象的ID值</param>
        /// <returns>返回影响记录的行数,-1表示操作失败,大于-1表示成功</returns>
        public virtual int Delete(int id)
        {
            return this.DataAccessor.Delete(id);
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象(用于整型主键)。
        /// </summary>
        /// <param name="id">指定对象的ID值</param>
        /// <returns>返回影响记录的行数,-1表示操作失败,大于-1表示成功</returns>
        public virtual int Delete(string id)
        {
            return this.DataAccessor.Delete(id);
        }

        /// <summary>
        /// 更新数据库表中指定主键值的记录。
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="id">表中主键的值</param>
        /// <param name="columnNames">列名集合</param>
        /// <returns>更新记录的条数</returns>
        public virtual int Modify(T entity, int id, params string[] columnNames)
        {
            return this.DataAccessor.Update(entity, id, columnNames);
        }

        /// <summary>
        /// 更新数据库表中指定主键值的记录。
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="id">表中主键的值</param>
        /// <param name="columnNames">列名集合</param>
        /// <returns>更新记录的条数</returns>
        public virtual int Modify(T entity, string id, params string[] columnNames)
        {
            return this.DataAccessor.Update(entity, id, columnNames);
        }

        /// <summary>
        /// 更新数据库表中指定主键值的记录。
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ids">表中主键的值集合(eg:1,2,3..)</param>
        /// <param name="columnNames">列名集合</param>
        /// <returns>更新记录的条数</returns>
        public virtual int ModifyIn(T entity, string ids, params string[] columnNames)
        {
            return this.DataAccessor.UpdateIn(entity, ids, columnNames);
        }

        /// <summary>
        /// 从数据库中获取指定标识的实体对象(返回值需要判断是否为null)。
        /// </summary>
        /// <param name="id">唯一标识值</param>
        /// <param name="columnNames">列名集合</param>
        /// <returns>具体的实体对象</returns>
        public virtual T GetById(string id, params string[] columnNames)
        {
            return this.DataAccessor.Select(id, columnNames);
        }

        /// <summary>
        /// 从数据库中获取指定标识的实体对象(返回值需要判断是否为null)。
        /// </summary>
        /// <param name="id">唯一标识值</param>
        /// <param name="columnNames">列名集合</param>
        /// <returns>具体的实体对象</returns>
        public virtual T GetById(int id, params string[] columnNames)
        {
            return this.DataAccessor.Select(id, columnNames);
        }
    }
}


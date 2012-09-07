using System;

namespace Lottery.Model.Common
{
    using Data;

    [Serializable]
    public class NumberType : BaseModel
    {
        public static string ENTITYNAME = "NumberType";

        #region Const Members

        /// <summary>
        /// 列名Id  
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名Name  
        /// </summary>
        public static readonly String C_Name = "Name";
        /// <summary>
        /// 列名Code  
        /// </summary>
        public static readonly String C_Code = "Code";
        /// <summary>
        /// 列名Type  
        /// </summary>
        public static readonly String C_Type = "Type";
        /// <summary>
        /// 列名P  
        /// </summary>
        public static readonly String C_P = "P";

        #endregion

        #region Field Members


        private Int32 _id;

        private String _name;

        private String _code;

        private String _type;

        private Double _p;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Id",IsIdentity=true)]
        public virtual Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Name")]
        public virtual String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Code")]
        public virtual String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Type")]
        public virtual String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P")]
        public virtual Double P
        {
            get { return this._p; }
            set { this._p = value; }
        }

        #endregion
    }
}
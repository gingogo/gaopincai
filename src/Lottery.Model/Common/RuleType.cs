using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 彩票玩法类型
    /// </summary>
    [Serializable]
    public class RuleType : BaseModel
    {
        public static string ENTITYNAME = "RuleType";

        #region Const Members

        /// <summary>
        /// 列名Id,玩法类型Id
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名Code,玩法类型代号
        /// </summary>
        public static readonly String C_Code = "Code";
        /// <summary>
        /// 列名Name,玩法类型名称
        /// </summary>
        public static readonly String C_Name = "Name";
        /// <summary>
        /// 列名Seq,玩法类型在记录集中顺序 
        /// </summary>
        public static readonly String C_Seq = "Seq";

        #endregion

        #region Field Members


        private Int32 _id;

        private String _code;

        private String _name;

        private Int32 _seq;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置玩法类型Id
        /// </summary>
        [Column(Name = "Id", IsIdentity = true)]
        public virtual Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型代号
        /// </summary>
        [Column(Name = "Code")]
        public virtual String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型名称
        /// </summary>
        [Column(Name = "Name")]
        public virtual String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型在记录集中顺序
        /// </summary>
        [Column(Name = "Seq")]
        public virtual Int32 Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        #endregion
    }
}
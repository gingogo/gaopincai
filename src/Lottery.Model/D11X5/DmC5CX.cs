using System;

namespace Lottery.Model.D11X5
{
    using Data;

    /// <summary>
    /// 所有任选排列组合维度表。
    /// </summary>
    [Serializable]
    public class DmC5CX : BaseModel
    {
        public static string ENTITYNAME = "DmC5CX";

        #region Const Members

        /// <summary>
        /// 列名C5  
        /// </summary>
        public static readonly String C_C5 = "C5";
        /// <summary>
        /// 列名CX  
        /// </summary>
        public static readonly String C_CX = "CX";
        /// <summary>
        /// 列名C5Number  
        /// </summary>
        public static readonly String C_C5Number = "C5Number";
        /// <summary>
        /// 列名CXNumber  
        /// </summary>
        public static readonly String C_CXNumber = "CXNumber";
        /// <summary>
        /// 列名NumberType  
        /// </summary>
        public static readonly String C_NumberType = "NumberType";

        #endregion

        #region Field Members


        private String _c5;

        private String _cX;

        private String _c5Number;

        private String _cXNumber;

        private String _numberType;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "C5")]
        public virtual String C5
        {
            get { return this._c5; }
            set { this._c5 = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "CX")]
        public virtual String CX
        {
            get { return this._cX; }
            set { this._cX = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "C5Number")]
        public virtual String C5Number
        {
            get { return this._c5Number; }
            set { this._c5Number = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "CXNumber")]
        public virtual String CXNumber
        {
            get { return this._cXNumber; }
            set { this._cXNumber = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "NumberType")]
        public virtual String NumberType
        {
            get { return this._numberType; }
            set { this._numberType = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", this._c5, this._cX, this._c5Number, this._cXNumber, this._numberType);
        }
    }
}
using System;

namespace Lottery.Model.D11X5
{
    using Data;

    /// <summary>
    /// 所有任选排列组合遗漏维度表。
    /// </summary>
    [Serializable]
    public class DwC5CXSpan : BaseModel
    {
        #region Const Members

        /// <summary>
        /// 列名P  
        /// </summary>
        public static readonly String C_P = "P";
        /// <summary>
        /// 列名C5  
        /// </summary>
        public static readonly String C_C5 = "C5";
        /// <summary>
        /// 列名CX  
        /// </summary>
        public static readonly String C_CX = "CX";
        /// <summary>
        /// 列名Seq
        /// </summary>
        public static readonly String C_Seq = "Seq";
        /// <summary>
        /// 列名PeroidSpans  
        /// </summary>
        public static readonly String C_PeroidSpans = "PeroidSpans";

        #endregion

        #region Field Members


        private Int64 _p;

        private String _c5;

        private String _cX;

        private Int32 _seq;

        private Int32 _peroidSpans;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P")]
        public virtual Int64 P
        {
            get { return this._p; }
            set { this._p = value; }
        }
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
        /// 获取或设置C2,C3,C4,C6,C7,C8
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
        [Column(Name = "Seq")]
        public virtual Int32 Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "PeroidSpans")]
        public virtual Int32 PeroidSpans
        {
            get { return this._peroidSpans; }
            set { this._peroidSpans = value; }
        }

        #endregion
    }
}
using System;

namespace Lottery.Model.SSL
{
    using Data;

    [Serializable]
    public class DwSpan : BaseModel
    {
        #region Const Members

        /// <summary>
        /// 列名P  
        /// </summary>
        public static readonly String C_P = "P";
        /// <summary>
        /// 列名D1Spans  
        /// </summary>
        public static readonly String C_D1Spans = "D1Spans";
        /// <summary>
        /// 列名D2Spans  
        /// </summary>
        public static readonly String C_D2Spans = "D2Spans";
        /// <summary>
        /// 列名D3Spans  
        /// </summary>
        public static readonly String C_D3Spans = "D3Spans";
        /// <summary>
        /// 列名P2Spans  
        /// </summary>
        public static readonly String C_P2Spans = "P2Spans";
        /// <summary>
        /// 列名C2Spans  
        /// </summary>
        public static readonly String C_C2Spans = "C2Spans";
        /// <summary>
        /// 列名P3Spans  
        /// </summary>
        public static readonly String C_P3Spans = "P3Spans";
        /// <summary>
        /// 列名C3Spans  
        /// </summary>
        public static readonly String C_C3Spans = "C3Spans";

        #endregion

        #region Field Members

        private Int64 _p;

        private Int32 _d1Spans;

        private Int32 _d2Spans;

        private Int32 _d3Spans;

        private Int32 _p2Spans;

        private Int32 _c2Spans;

        private Int32 _p3Spans;

        private Int32 _c3Spans;

        #endregion

        #region Table Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P", IsPrimaryKey = true)]
        public virtual Int64 P
        {
            get { return this._p; }
            set { this._p = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "D1Spans")]
        public virtual Int32 D1Spans
        {
            get { return this._d1Spans; }
            set { this._d1Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "D2Spans")]
        public virtual Int32 D2Spans
        {
            get { return this._d2Spans; }
            set { this._d2Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "D3Spans")]
        public virtual Int32 D3Spans
        {
            get { return this._d3Spans; }
            set { this._d3Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P2Spans")]
        public virtual Int32 P2Spans
        {
            get { return this._p2Spans; }
            set { this._p2Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "C2Spans")]
        public virtual Int32 C2Spans
        {
            get { return this._c2Spans; }
            set { this._c2Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P3Spans")]
        public virtual Int32 P3Spans
        {
            get { return this._p3Spans; }
            set { this._p3Spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "C3Spans")]
        public virtual Int32 C3Spans
        {
            get { return this._c3Spans; }
            set { this._c3Spans = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                this._p, this._d1Spans,this._d2Spans,this._d3Spans,
                this._p2Spans,this._c2Spans,this._p3Spans,this._c3Spans);
        }
    }
}
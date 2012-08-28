using System;

namespace Lottery.Model.SSC
{
    using Data;

    [Serializable]
    public class DwNumberSpan : DwNumber
    {
        //DwSpan表
        public static readonly String C_D1Spans = "D1Spans";
        public static readonly String C_P2Spans = "P2Spans";
        public static readonly String C_P3Spans = "P3Spans";
        public static readonly String C_P4Spans = "P4Spans";
        public static readonly String C_P5Spans = "P5Spans";
        public static readonly String C_C2Spans = "C2Spans";
        public static readonly String C_C3Spans = "C3Spans";


        //DwSpan表
        private Int32 _d1Spans;
        private Int32 _p2Spans;
        private Int32 _p3Spans;
        private Int32 _p4Spans;
        private Int32 _p5Spans;
        private Int32 _c2Spans;
        private Int32 _c3Spans;

        //DwSpan表
        [Column(Name = "D1Spans")]
        public virtual Int32 D1Spans
        {
            get { return this._d1Spans; }
            set { this._d1Spans = value; }
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

        [Column(Name = "P3Spans")]
        public virtual Int32 P3Spans
        {
            get { return this._p3Spans; }
            set { this._p3Spans = value; }
        }

        [Column(Name = "P4Spans")]
        public virtual Int32 P4Spans
        {
            get { return this._p4Spans; }
            set { this._p4Spans = value; }
        }

        [Column(Name = "P5Spans")]
        public virtual Int32 P5Spans
        {
            get { return this._p5Spans; }
            set { this._p5Spans = value; }
        }

        [Column(Name = "C2Spans")]
        public virtual Int32 C2Spans
        {
            get { return this._c2Spans; }
            set { this._c2Spans = value; }
        }

        [Column(Name = "C3Spans")]
        public virtual Int32 C3Spans
        {
            get { return this._c3Spans; }
            set { this._c3Spans = value; }
        }
    }
}

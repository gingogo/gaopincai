using System;

namespace Lottery.Model.D11X5
{
    using Data;

    [Serializable]
    public class DwNumberSpan : DwNumber
    {
        //DwSpan表
        public static readonly String C_D1Spans = "D1Spans";
        public static readonly String C_F2Spans = "F2Spans";
        public static readonly String C_F3Spans = "F3Spans";
        public static readonly String C_C2Spans = "C2Spans";
        public static readonly String C_C3Spans = "C3Spans";
        public static readonly String C_A5Spans = "A5Spans";

        //DwSpan表
        private Int32 _d1Spans;
        private Int32 _f2Spans;
        private Int32 _f3Spans;
        private Int32 _c2Spans;
        private Int32 _c3Spans;
        private Int32 _a5Spans;

        //DwSpan表
        [Column(Name = "D1Spans")]
        public virtual Int32 D1Spans
        {
            get { return this._d1Spans; }
            set { this._d1Spans = value; }
        }

        [Column(Name = "F2Spans")]
        public virtual Int32 F2Spans
        {
            get { return this._f2Spans; }
            set { this._f2Spans = value; }
        }

        [Column(Name = "F3Spans")]
        public virtual Int32 F3Spans
        {
            get { return this._f3Spans; }
            set { this._f3Spans = value; }
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

        [Column(Name = "A5Spans")]
        public virtual Int32 A5Spans
        {
            get { return this._a5Spans; }
            set { this._a5Spans = value; }
        }
    }
}

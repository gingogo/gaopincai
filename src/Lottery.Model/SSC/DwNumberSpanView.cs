using System;

namespace Lottery.Model.SSC
{
    using Data;

    [Serializable]
    public class DwNumberSpanView : BaseModel
    {
        //DwNumber表
        private long _p;
        private int _d1;
        private int _d2;
        private int _d3;
        private int _d4;
        private int _d5;
        private int _n;
        private int _seq;
        private int _date;
        private string _p2;
        private string _p3;
        private string _p4;
        private string _p5;
        private string _c2;
        private string _c3;
        private string _c33;
        private string _c36;
        private DateTime _created;

        //DwSpan表
        private Int32 _d1Spans;
        private Int32 _p2Spans;
        private Int32 _p3Spans;
        private Int32 _p4Spans;
        private Int32 _p5Spans;
        private Int32 _c2Spans;
        private Int32 _c3Spans;

        //DwNumber表
        public static readonly string C_P = "P";
        public static readonly string C_D1 = "D1";
        public static readonly string C_D2 = "D2";
        public static readonly string C_D3 = "D3";
        public static readonly string C_D4 = "D4";
        public static readonly string C_D5 = "D5";
        public static readonly string C_N = "N";
        public static readonly string C_Seq = "Seq";
        public static readonly string C_P2 = "P2";
        public static readonly string C_P3 = "P3";
        public static readonly string C_P4 = "P4";
        public static readonly string C_P5 = "P5";
        public static readonly string C_C2 = "C2";
        public static readonly string C_C3 = "C3";
        public static readonly string C_Date = "Date";
        public static readonly string C_Created = "Created";

        //DwSpan表
        public static readonly String C_D1Spans = "D1Spans";
        public static readonly String C_P2Spans = "P2Spans";
        public static readonly String C_P3Spans = "P3Spans";
        public static readonly String C_P4Spans = "P4Spans";
        public static readonly String C_P5Spans = "P5Spans";
        public static readonly String C_C2Spans = "C2Spans";
        public static readonly String C_C3Spans = "C3Spans";

        //DwNumber表
        [Column(Name = "P")]
        public long P
        {
            get
            {
                return this._p;
            }
            set
            {
                this._p = value;
            }
        }

        [Column(Name = "D1")]
        public int D1
        {
            get
            {
                return this._d1;
            }
            set
            {
                this._d1 = value;
            }
        }

        [Column(Name = "D2")]
        public int D2
        {
            get
            {
                return this._d2;
            }
            set
            {
                this._d2 = value;
            }
        }

        [Column(Name = "D3")]
        public int D3
        {
            get
            {
                return this._d3;
            }
            set
            {
                this._d3 = value;
            }
        }

        [Column(Name = "D4")]
        public int D4
        {
            get
            {
                return this._d4;
            }
            set
            {
                this._d4 = value;
            }
        }

        [Column(Name = "D5")]
        public int D5
        {
            get
            {
                return this._d5;
            }
            set
            {
                this._d5 = value;
            }
        }

        [Column(Name = "P2")]
        public string P2
        {
            get
            {
                return this._p2;
            }
            set
            {
                this._p2 = value;
            }
        }

        [Column(Name = "P3")]
        public string P3
        {
            get
            {
                return this._p3;
            }
            set
            {
                this._p3 = value;
            }
        }

        [Column(Name = "P4")]
        public string P4
        {
            get
            {
                return this._p4;
            }
            set
            {
                this._p4 = value;
            }
        }

        [Column(Name = "P5")]
        public string P5
        {
            get
            {
                return this._p5;
            }
            set
            {
                this._p5 = value;
            }
        }

        [Column(Name = "C2")]
        public string C2
        {
            get
            {
                return this._c2;
            }
            set
            {
                this._c2 = value;
            }
        }

        [Column(Name = "C3")]
        public string C3
        {
            get
            {
                return this._c3;
            }
            set
            {
                this._c3 = value;
            }
        }

        public string C33
        {
            get
            {
                return this._c33 ?? string.Empty;
            }
            set
            {
                this._c33 = value;
            }
        }

        public string C36
        {
            get
            {
                return this._c36 ?? string.Empty;
            }
            set
            {
                this._c36 = value;
            }
        }

        [Column(Name = "N")]
        public int N
        {
            get
            {
                return this._n;
            }
            set
            {
                this._n = value;
            }
        }

        [Column(Name = "Seq")]
        public int Seq
        {
            get
            {
                return this._seq;
            }
            set
            {
                this._seq = value;
            }
        }

        [Column(Name = "Date")]
        public int Date
        {
            get
            {
                return this._date;
            }
            set
            {
                this._date = value;
            }
        }

        [Column(Name = "Created")]
        public DateTime Created
        {
            get
            {
                return this._created;
            }
            set
            {
                this._created = value;
            }
        }

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

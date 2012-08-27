using System;

namespace Lottery.Model.D11X5
{
    using Data;

    [Serializable]
    public class DwNumber : BaseModel
    {
        public static string EntityName = "DwNumber";

        private long _p;
        private int _d1;
        private int _d2;
        private int _d3;
        private int _d4;
        private int _d5; 
        private int _n;
        private int _seq;
        private int _date;
        private string _f2;
        private string _c2;
        private string _f3;
        private string _c3;
        private string _f5;
        private string _a5;
        private DateTime _created;

        public static readonly string C_P = "P";
        public static readonly string C_D1 = "D1";
        public static readonly string C_D2 = "D2";
        public static readonly string C_D3 = "D3";
        public static readonly string C_D4 = "D4";
        public static readonly string C_D5 = "D5";
        public static readonly string C_N = "N";
        public static readonly string C_Seq = "Seq";
        public static readonly string C_F2 = "F2";
        public static readonly string C_C2 = "C2";
        public static readonly string C_F3 = "F3";
        public static readonly string C_C3 = "C3";
        public static readonly string C_F5 = "F5";
        public static readonly string C_A5 = "A5";
        public static readonly string C_Date = "Date";
        public static readonly string C_Created = "Created";

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

        [Column(Name="D1")]
        public  int D1
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

        [Column(Name="D2")]
        public  int D2
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

        [Column(Name="D3")]
        public  int D3
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

        [Column(Name="D4")]
        public  int D4
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

        [Column(Name="D5")]
        public  int D5
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

        [Column(Name = "F2")]
        public  string F2
        {
            get
            {
                return this._f2;
            }
            set
            {
                this._f2 = value;
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

        [Column(Name = "F3")]
        public  string F3
        {
            get
            {
                return this._f3;
            }
            set
            {
                this._f3 = value;
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

        [Column(Name = "F5")]
        public string F5
        {
            get
            {
                return this._f5;
            }
            set
            {
                this._f5 = value;
            }
        }

        [Column(Name = "A5")]
        public string A5
        {
            get
            {
                return this._a5;
            }
            set
            {
                this._a5 = value;
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

        public override string ToString()
        {
            string str = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}",
                 this._p, this._d1, this._d2, this._d3, this._d4, this._d5, this._f2, this._c2, this._f3, this._c3, this._f5, this._a5,
                this._n, this._seq, this._date, this._created);
            return str;
        }
    }
}


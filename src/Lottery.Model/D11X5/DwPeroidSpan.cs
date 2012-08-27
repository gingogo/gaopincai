using System;

namespace Lottery.Model.D11X5
{
    using Data;

    public class DwPeroidSpan : BaseModel
    {
        #region Const Members

        /// <summary>
        /// 列名NumberId  
        /// </summary>
        public static readonly String C_NumberId = "NumberId";
        /// <summary>
        /// 列名Spans  
        /// </summary>
        public static readonly String C_Spans = "Spans";
        /// <summary>
        /// 列名LastN  
        /// </summary>
        public static readonly String C_LastN = "LastN";
        /// <summary>
        /// 列名P  
        /// </summary>
        public static readonly String C_P = "P";

        #endregion

        #region Field Members


        private string _numberId;
        private int _spans;
        private int _lastN;
        private long _p;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "NumberId")]
        public virtual String NumberId
        {
            get { return this._numberId; }
            set { this._numberId = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Spans")]
        public virtual int Spans
        {
            get { return this._spans; }
            set { this._spans = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "LastN")]
        public virtual int LastN
        {
            get { return this._lastN; }
            set { this._lastN = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "P")]
        public virtual long P
        {
            get { return this._p; }
            set { this._p = value; }
        }
        #endregion
    }
}
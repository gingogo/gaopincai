using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 玩法类型实体
    /// </summary>
    [Serializable]
    public class NumberType : BaseModel
    {
        public static string ENTITYNAME = "NumberType";

        #region Const Members

        /// <summary>
        /// 列名Id,玩法类型Id 
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名Name,玩法类型名称
        /// </summary>
        public static readonly String C_Name = "Name";
        /// <summary>
        /// 列名Code,玩法类型代号  
        /// </summary>
        public static readonly String C_Code = "Code";
        /// <summary>
        /// 列名Type,玩法类型的规则类型 
        /// </summary>
        public static readonly String C_RuleType = "RuleType";
        /// <summary>
        /// 列名Length,玩法类型字符个数 
        /// </summary>
        public static readonly String C_Length = "Length";
        /// <summary>
        /// 列名Probability,玩法类型概率  
        /// </summary>
        public static readonly String C_Probability = "Probability";
        /// <summary>
        /// 列名Amount,玩法类型投注金额
        /// </summary>
        public static readonly String C_Amount = "Amount";
        /// <summary>
        /// 列名Prize,玩法类型的单注中奖金额  
        /// </summary>
        public static readonly String C_Prize = "Prize";
        /// <summary>
        /// 列名Seq,玩法类型排序号
        /// </summary>
        public static readonly String C_Seq = "Seq";
        /// <summary>
        /// 列名Status,玩法类型状态
        /// </summary>
        public static readonly String C_Status = "Status";

        #endregion

        #region Field Members


        private Int32 _id;

        private String _name;

        private String _code;

        private String _ruleType;

        private Int32 _length;

        private Double _probability;

        private Double _amount;

        private Double _prize;

        private Int32 _seq = 10;

        private Byte _status = 1;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置玩法类型类型Id
        /// </summary>
        [Column(Name = "Id",IsIdentity=true)]
        public virtual Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型规则类型
        /// </summary>
        [Column(Name = "RuleType")]
        public virtual String RuleType
        {
            get { return this._ruleType; }
            set { this._ruleType = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型类型名称
        /// </summary>
        [Column(Name = "Name")]
        public virtual String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型的规则类型
        /// </summary>
        [Column(Name = "Code")]
        public virtual String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型数字个数
        /// </summary>
        [Column(Name = "Length")]
        public Int32 Length
        {
            get { return this._length; }
            set { this._length = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型中奖概率
        /// </summary>
        [Column(Name = "Probability")]
        public virtual Double Probability
        {
            get { return this._probability; }
            set { this._probability = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型单注投注金额
        /// </summary>
        [Column(Name = "Amount")]
        public virtual Double Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }
        /// <summary>
        /// 获取或设置玩法类型的单注中奖金额
        /// </summary>
        [Column(Name = "Prize")]
        public virtual Double Prize
        {
            get { return this._prize; }
            set { this._prize = value; }
        }
        /// <summary>
        /// 获取或设置在记录集中排序号
        /// </summary>
        [Column(Name = "Seq")]
        public Int32 Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }
        /// <summary>
        /// 获取或设置状态
        /// </summary>
        [Column(Name = "Status")]
        public Byte Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        #endregion
    }
}
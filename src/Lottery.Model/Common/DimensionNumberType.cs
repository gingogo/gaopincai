using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 各维度号码玩法的中奖概率配置信息实体
    /// </summary>
    [Serializable]
    public class DimensionNumberType : BaseModel
    {
        public static string ENTITYNAME = "DimensionNumberType";

        #region Const Members

        /// <summary>
        /// 列名Id,实体标识 
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名RuleType,玩法所属规则类型(如：11x5,SSC等)  
        /// </summary>
        public static readonly String C_RuleType = "RuleType";
        /// <summary>
        /// 列名NumberType,玩法所属号码类型(如：F2,P2,C2,C3等) 
        /// </summary>
        public static readonly String C_NumberType = "NumberType";
        /// <summary>
        /// 列名Dimension，玩法所属的维度(如:He,HeWei,ZiHe,DanShuang,AC,KuaDu等) 
        /// </summary>
        public static readonly String C_Dimension = "Dimension";
        /// <summary>
        /// 列名Value,玩法所属维度的值
        /// </summary>
        public static readonly String C_DimValue = "DimValue";
        /// <summary>
        /// 列名Probability,玩法维度值的中奖概率
        /// </summary>
        public static readonly String C_Probability = "Probability";
        /// <summary>
        /// 列名Nums,玩法维度值包含玩法注数  
        /// </summary>
        public static readonly String C_Nums = "Nums";
        /// <summary>
        /// 列名Amount,单注投入金额,公式为：Nums * 该玩法类型(如:C2)单注金额   
        /// </summary>
        public static readonly String C_Amount = "Amount";

        #endregion

        #region Field Members


        private Int32 _id;

        private String _ruleType;

        private String _numberType;

        private String _dimension;

        private String _dimValue;

        private Double _probability;

        private Int32 _nums;

        private Double _amount;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置实体标识
        /// </summary>
        [Column(Name = "Id", IsIdentity = true)]
        public virtual Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置玩法所属规则类型(如：11x5,SSC等)  
        /// </summary>
        [Column(Name = "RuleType")]
        public virtual String RuleType
        {
            get { return this._ruleType; }
            set { this._ruleType = value; }
        }
        /// <summary>
        /// 获取或设置号码类型(如：F2,P2,C2,C3等)
        /// </summary>
        [Column(Name = "NumberType")]
        public virtual String NumberType
        {
            get { return this._numberType; }
            set { this._numberType = value; }
        }
        /// <summary>
        /// 获取或设置玩法所属的维度(如:He,HeWei,ZiHe,DanShuang,AC,KuaDu等)
        /// </summary>
        [Column(Name = "Dimension")]
        public virtual String Dimension
        {
            get { return this._dimension; }
            set { this._dimension = value; }
        }
        /// <summary>
        /// 获取或设置玩法所属维度的值
        /// </summary>
        [Column(Name = "DimValue")]
        public virtual String DimValue
        {
            get { return this._dimValue; }
            set { this._dimValue = value; }
        }
        /// <summary>
        /// 获取或设置玩法维度值的中奖概率
        /// </summary>
        [Column(Name = "Probability")]
        public virtual Double Probability
        {
            get { return this._probability; }
            set { this._probability = value; }
        }
        /// <summary>
        /// 获取或设置玩法维度值包含玩法注数
        /// </summary>
        [Column(Name = "Nums")]
        public virtual Int32 Nums
        {
            get { return this._nums; }
            set { this._nums = value; }
        }
        /// <summary>
        /// 获取或设置单注投入金额,公式为：Nums * 该玩法类型(如:C2)单注金额
        /// </summary>
        [Column(Name = "Amount")]
        public virtual Double Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }
        #endregion
    }
}
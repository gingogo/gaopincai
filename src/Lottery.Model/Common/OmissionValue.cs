using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 遗漏属性实体
    /// </summary>
    [Serializable]
    public class OmissionValue : BaseModel
    {
        public static string ENTITYNAME = "OmissionValue";

        private string _ruleType;
        private string _numberType;
        private string _dimension;
        private string _numberId;
        private int _peroidCount;
        private int _nums;
        private int _actualTimes;
        private int _currentSpans;
        private int _maxSpans;
        private int _lastSpans;
        private double _avgSpans;
        private double _probability;
        private double _prize;
        private double _amount;

        public OmissionValue() { }

        /// <summary>
        /// 获取或设置玩法规则
        /// </summary>
        [Column(Name = "RuleType")]
        public string RuleType
        {
            get { return this._ruleType; }
            set { this._ruleType = value; }
        }

        /// <summary>
        /// 获取或设置号码类型
        /// </summary>
        [Column(Name = "NumberType")]
        public string NumberType
        {
            get { return this._numberType; }
            set { this._numberType = value; }
        }

        /// <summary>
        /// 获取或设置维度
        /// </summary>
        [Column(Name = "Dimension")]
        public string Dimension
        {
            get { return this._dimension; }
            set { this._dimension = value; }
        } 

        /// <summary>
        /// 获取或设置玩法号码或维度值
        /// </summary>
        [Column(Name = "NumberId")]
        public string NumberId
        {
            get { return this._numberId; }
            set { this._numberId = value; }
        }

        /// <summary>
        /// 获取或设置该维度包含号码注数。
        /// </summary>
        [Column(Name = "Nums")]
        public int Nums
        {
            get { return this._nums; }
            set { this._nums = value; }
        }

        /// <summary>
        /// 获取或设置统计期数。
        /// </summary>
        [Column(Name = "PeroidCount")]
        public int PeroidCount
        {
            get { return this._peroidCount; }
            set { this._peroidCount = value; }
        }

        /// <summary>
        /// 获取或设置实际出现次数,指该号码历史上实际出现的次数。
        /// </summary>
        [Column(Name = "ActualTimes")]
        public int ActualTimes
        {
            get { return this._actualTimes; }
            set { this._actualTimes = value; }
        }

        /// <summary>
        /// 获取或设置本期遗漏,该号码自上次开出之后的遗漏次数。
        /// </summary>
        [Column(Name = "CurrentSpans")]
        public int CurrentSpans
        {
            get { return this._currentSpans; }
            set { this._currentSpans = value; }
        }

        /// <summary>
        /// 获取或设置最大遗漏,历史上遗漏的最大值。
        /// </summary>
        [Column(Name = "MaxSpans")]
        public int MaxSpans
        {
            get { return this._maxSpans; }
            set { this._maxSpans = value; }
        }

        /// <summary>
        /// 获取或设置上期遗漏,指该号码上次开出之前的遗漏次数。
        /// </summary>
        [Column(Name = "LastSpans")]
        public int LastSpans
        {
            get { return this._lastSpans; }
            set { this._lastSpans = value; }
        }

        /// <summary>
        /// 获取或设置平均遗漏,是指所有遗漏值的平均值。
        /// </summary>
        [Column(Name = "AvgSpans")]
        public double AvgSpans
        {
            get { return this._avgSpans; }
            set { this._avgSpans = value; }
        }
  
        /// <summary>
        /// 获取或设置该维度号码玩法的中奖概率
        /// </summary>
        [Column(Name = "Probability")]
        public double Probability
        {
            get { return this._probability; }
            set { this._probability = value; }
        }

        /// <summary>
        /// 获取或设置该维度号码玩法的中奖奖金
        /// </summary>
        [Column(Name = "Prize")]
        public double Prize
        {
            get { return this._prize; }
            set { this._prize = value; }
        }

        /// <summary>
        /// 获取或设置该维度号码玩法单注投注金额。
        /// </summary>
        [Column(Name = "Amount")]
        public double Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }
    }
}

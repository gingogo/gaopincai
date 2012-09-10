using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 遗漏属性实体
    /// </summary>
    [Serializable]
    public class Omission : BaseModel
    {
        private string _numberId;
        private int _peroidCount;
        private int _cycle;
        private int _actualTimes;
        private int _currentSpans;
        private double _avgSpans;
        private int _maxSpans;
        private int _lastSpans;

        public Omission() { }

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
        /// 获取或设置统计期数。
        /// </summary>
        [Column(Name = "PeroidCount")]
        public int PeroidCount
        {
            get { return this._peroidCount; }
            set { this._peroidCount = value; }
        }

        /// <summary>
        /// 获取或设置循环周期,等于某一玩法(前二)的号码类型总数,它的倒数就是某一玩法的中奖概率。
        /// 循环周期是指理想情况下该对象多少期出现一次，它是一个理论值。
        /// 一般而言，循环周期越大，则该对象的出现次数越少，循环周期越小，则该对象的出现次数越多。
        /// </summary>
        [Column(Name = "Cycle")]
        public int Cycle
        {
            get { return this._cycle; }
            set { this._cycle = value; }
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
        /// 获取或设置平均遗漏,是指所有遗漏值的平均值。
        /// </summary>
        [Column(Name = "AvgSpans")]
        public double AvgSpans
        {
            get { return this._avgSpans; }
            set { this._avgSpans = value; }
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
        /// 获取理论出现次数,【统计期数÷循环周期】指遗漏对象理论上应该出现的次数。
        /// </summary>
        public int TheoryTimes
        {
            get { return this._peroidCount / this._cycle; }
        }

        /// <summary>
        /// 获取出现频率【出现次数÷期数×100%】出现频率实际上是指该遗漏对象出现次数在全部遗漏对象中所占的比例。
        /// </summary>
        public double Frequency
        {
            get { return ((this._actualTimes * 1.0) / (this._peroidCount * 1.0)) * 100; }
        }

        /// <summary>
        /// 获取欲出几率,【本期遗漏÷平均遗漏】
        /// 欲出几率反应了该遗漏对象的理想出现几率，
        /// 如果欲出几率大于2，则该形态可称之为冷态。
        /// 欲出几率为2.55说明如果按理想状况，该号码从最近一次出现那一期到现在应该要再出现2.55次，
        /// 但实际一次未出现。因为是一个理想值，所以并不能完全反应实际情况，只能作为参考。
        /// </summary>
        public double OccurChance
        {
            get { return (this._currentSpans * 1.0) / (this._avgSpans * 1.0); }
        }

        /// <summary>
        /// 获取投资价值,【本期遗漏÷循环周期】
        /// 投资价值与欲出几率相仿，在计算方法上稍有差异。投资价值是用本期遗漏除以循环周期得到的。
        /// 相对于欲出几率而言，投资价值更趋理想化。因为欲出几率是根据平均遗漏来计算的，
        /// 平均遗漏是一个统计值，投资价值是根据循环周期来计算的，而循环周期是一个理论值。
        /// </summary>
        public double InvestmentValue
        {
            get { return (this._currentSpans * 1.0) / (this._cycle * 1.0); }
        }

        /// <summary>
        /// 获取回补几率,【(上期遗漏-本期遗漏)÷循环周期】
        /// 因为虽然某些组合会出现一个比较大的冷态，但是在冷态之后一般不会接着再出一个大冷态，
        /// 而是在一个周期内便再次出现甚至多次出现，因此回补几率越大的组合，从统计规律来看近期越容易出。
        /// </summary>
        public double ReturnChance
        {
            get { return ((this._lastSpans - this._currentSpans) * 1.0) / (this._cycle * 1.0); }
        }
    }
}

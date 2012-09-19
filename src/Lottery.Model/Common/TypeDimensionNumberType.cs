using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 彩票类型维度的号码类型。
    /// </summary>
    [Serializable]
    public class TypeDimensionNumberType : BaseModel
    {
        #region Const Members

        /// <summary>
        /// 列名Type,彩种类型
        /// </summary>
        public static readonly String C_Type = "Type";
        /// <summary>
        /// 列名Dimension,分析维度
        /// </summary>
        public static readonly String C_Dimension = "Dimension";
        /// <summary>
        /// 列名NumberType,号码类型
        /// </summary>
        public static readonly String C_NumberType = "NumberType";

        #endregion

        #region Field Members

        private String _type;

        private String _dimension;

        private String _numberType;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置彩种类型
        /// </summary>
        [Column(Name = "Type")]
        public virtual String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        /// <summary>
        /// 获取或设置分析维度
        /// </summary>
        [Column(Name = "Dimension")]
        public virtual String Dimension
        {
            get { return this._dimension; }
            set { this._dimension = value; }
        }
        /// <summary>
        /// 获取或设置号码类型
        /// </summary>
        [Column(Name = "NumberType")]
        public virtual String NumberType
        {
            get { return this._numberType; }
            set { this._numberType = value; }
        }

        #endregion
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// NumberTypeDimBiz提供业务逻辑类。
    /// </summary>
    public partial class NumberTypeDimBiz :
        SinglePKDataAccessBiz<NumberTypeDimDAO, NumberTypeDim>
    {
        #region 私有字段

        private Dictionary<int, NumberTypeDim> idDictCache;
        private Dictionary<string, NumberTypeDim> typeDimDictCache;

        #endregion

        #region 构造函数

        /// <summary>
        /// NumberTypeDimBiz类的一个单件。
        /// </summary>
        public static readonly NumberTypeDimBiz Instance = new NumberTypeDimBiz();

        protected NumberTypeDimBiz()
            : base(new NumberTypeDimDAO(ConfigHelper.CommonTableConnString))
        {
            this.LoadToCache();
        }

        #endregion

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public List<Dimension> GetDimensions(string ruleType, string numberType)
        {
            var dimCodes = this.idDictCache.Values
                .Where(x => x.RuleType.Equals(ruleType) && x.NumberType.Equals(numberType))
                .Select(x => x.Dimension)
                .Distinct();

            //加入默认维度
            Dimension peroidDim = DimensionBiz.Instance.GetByCode("Peroid");
            List<Dimension> list = new List<Dimension>(11);
            list.Add(peroidDim);

            foreach (var dimCode in dimCodes)
            {
                var dimension = DimensionBiz.Instance.GetByCode(dimCode);
                list.Add(dimension);
            }

            return list.OrderBy(x => x.Seq).ToList();
        }

        #endregion

        #region 私有方法成员

        private void LoadToCache()
        {
            if (idDictCache != null &&
                idDictCache.Count > 0) idDictCache.Clear();

            idDictCache = this.GetAll().ToDictionary(x => x.Id, y => y);
            typeDimDictCache = idDictCache.Values.ToDictionary(x =>
                string.Format("{0}-{1}-{2}-{3}", x.RuleType, x.NumberType, x.Dimension, x.DimValue), y => y);
        }

        #endregion
    }
}
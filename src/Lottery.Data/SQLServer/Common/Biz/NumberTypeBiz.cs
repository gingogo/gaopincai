using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// NumberTypeBiz提供业务逻辑类。
    /// </summary>
    public partial class NumberTypeBiz :
        SinglePKDataAccessBiz<NumberTypeDAO, NumberType>
    {
        #region 私有字段

        private List<NumberType> listCache;
        private Dictionary<string, NumberType> codeNameDictCache;
        private Dictionary<string, NumberType> nameCodeDictCache;

        #endregion

        /// <summary>
        /// NumberTypeBiz类的一个单件。
        /// </summary>
        public static readonly NumberTypeBiz Instance = new NumberTypeBiz();

        protected NumberTypeBiz()
            : base(new NumberTypeDAO(ConfigHelper.CommonTableConnString))
        {
            this.LoadToCache();
        }

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public List<NumberType> GetList()
        {
            return listCache;
        }

        public List<NumberType> GetList(string ruleType)
        {
            return listCache
                .Where(x => x.RuleType.Equals(ruleType))
                .ToList();
        }

        public NumberType GetByName(string ruleType, string name)
        {
            string key = string.Format("{0}-{1}", ruleType, name);
            return nameCodeDictCache.ContainsKey(key) ? nameCodeDictCache[key] : null;
        }

        public NumberType GetByCode(string ruleType, string code)
        {
            string key = string.Format("{0}-{1}", ruleType, code);
            return codeNameDictCache.ContainsKey(key) ? codeNameDictCache[key] : null;
        }

        #endregion

        #region 私有方法成员

        private void LoadToCache()
        {
            if (this.listCache != null &&
                this.listCache.Count > 0) this.listCache.Clear();

            listCache = this.GetAll().OrderBy(x => x.Seq).ToList();
            codeNameDictCache = listCache.ToDictionary(x => string.Format("{0}-{1}", x.RuleType,x.Code), y => y);
            nameCodeDictCache = listCache.ToDictionary(x => string.Format("{0}-{1}", x.RuleType, x.Name), y => y);
        }

        #endregion
    }
}
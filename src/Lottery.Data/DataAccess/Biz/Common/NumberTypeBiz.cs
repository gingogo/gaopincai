using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Data.Biz.Common
{
    using Configuration;
    using Data.Common;
    using Model.Common;
    using Utils;

    /// <summary>
    /// NumberTypeBiz提供业务逻辑类。
    /// </summary>
    public partial class NumberTypeBiz :
        SinglePKDataAccessBiz<INumberTypeDAO, NumberType>
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
            : base(DAOFactory.Create<INumberTypeDAO>("common"))
        {
            this.LoadToCache();
        }

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public string[] GetCodes(string ruleType)
        {
            return this.listCache
                .Where(x => x.RuleType.Equals(ruleType))
                .Select(x => x.Code).ToArray();
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
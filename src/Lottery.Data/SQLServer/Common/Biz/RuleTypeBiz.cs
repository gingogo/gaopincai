using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.SQLServer.Common
{
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// RuleTypeBiz提供业务逻辑类。
    /// </summary>
    public partial class RuleTypeBiz :
        SinglePKDataAccessBiz<RuleTypeDAO, RuleType>
    {
        #region 私有字段

        private List<RuleType> listCache;
        private Dictionary<string, RuleType> codeNameDictCache;
        private Dictionary<string, RuleType> nameCodeDictCache;

        #endregion

        #region 构造函数

        /// <summary>
        /// RuleTypeBiz类的一个单件。
        /// </summary>
        public static readonly RuleTypeBiz Instance = new RuleTypeBiz();

        protected RuleTypeBiz()
            : base(new RuleTypeDAO(ConfigHelper.CommonTableConnString))
        {
            this.LoadToCache();
        }

        #endregion

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public List<RuleType> GetList()
        {
            return listCache;
        }

        public RuleType GetByName(string name)
        {
            return nameCodeDictCache.ContainsKey(name) ? nameCodeDictCache[name] : null;
        }

        public RuleType GetByCode(string code)
        {
            return codeNameDictCache.ContainsKey(code) ? codeNameDictCache[code] : null;
        }

        #endregion

        #region 私有方法成员

        private void LoadToCache()
        {
            if (this.listCache != null &&
                this.listCache.Count > 0) this.listCache.Clear();

            listCache = this.GetAll().OrderBy(x => x.Seq).ToList();
            codeNameDictCache = listCache.ToDictionary(x => x.Code, y => y);
            nameCodeDictCache = listCache.ToDictionary(x => x.Name, y => y);
        }

        #endregion
    }
}
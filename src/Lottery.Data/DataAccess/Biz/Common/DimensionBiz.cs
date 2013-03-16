using System;
using System.Linq;
using System.Collections.Generic;

namespace Lottery.Data.Biz.Common
{
    using Data.Common;
    using Model.Common;
    using Utils;
    using Configuration;

    /// <summary>
    /// DimensionBiz提供业务逻辑类。
    /// </summary>
    public partial class DimensionBiz :
        SinglePKDataAccessBiz<IDimensionDAO, Dimension>
    {
        #region 私有字段

        private List<Dimension> listCache;
        private Dictionary<string, Dimension> codeNameDictCache;
        private Dictionary<string, Dimension> nameCodeDictCache;

        #endregion

        #region 构造函数

        /// <summary>
        /// DimensionBiz类的一个单件。
        /// </summary>
        public static readonly DimensionBiz Instance = new DimensionBiz();

        protected DimensionBiz()
            : base(DAOFactory.Create<IDimensionDAO>("common"))
        {
            this.LoadToCache();
        }

        #endregion

        #region 公共业务逻辑成员

        public void RefreshCache()
        {
            this.LoadToCache();
        }

        public string[] GetCodes()
        {
            return this.listCache.Select(x => x.Code).ToArray();
        }

        public List<Dimension> GetList()
        {
            return listCache;
        }

        public Dimension GetByName(string name)
        {
            return nameCodeDictCache.ContainsKey(name) ? nameCodeDictCache[name] : null;
        }

        public Dimension GetByCode(string code)
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
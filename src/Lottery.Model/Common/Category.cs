using System;

namespace Lottery.Model.Common
{
    using Data;

    /// <summary>
    /// 彩种实体
    /// </summary>
    [Serializable]
    public class Category : BaseModel
    {
        public static string ENTITYNAME = "Category";

        #region Const Members

        /// <summary>
        /// 列名Id,彩种Id
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名ParentId,彩种父ID
        /// </summary>
        public static readonly String C_ParentId = "ParentId";
        /// <summary>
        /// 列名Name,彩种名称 
        /// </summary>
        public static readonly String C_Name = "Name";
        /// <summary>
        /// 列名RuleType,彩种玩法类型
        /// </summary>
        public static readonly String C_RuleType = "RuleType";
        /// <summary>
        /// 列名Type,彩种类型
        /// </summary>
        public static readonly String C_Type = "Type";
        /// <summary>
        /// 列名Code,彩种代号 
        /// </summary>
        public static readonly String C_Code = "Code";
        /// <summary>
        /// 列名DbName，彩种对应的数据库名称
        /// </summary>
        public static readonly String C_DbName = "DbName";   
        /// <summary>
        /// 列名Peroid,彩种开奖周期
        /// </summary>
        public static readonly String C_Peroid = "Peroid";
        /// <summary>
        /// 列名Seq,彩种在记录集中排序号
        /// </summary>
        public static readonly String C_Seq = "Seq";
        /// <summary>
        /// 列名Enabled,彩种是否可用
        /// </summary>
        public static readonly String C_Enabled = "Enabled";
        /// <summary>
        /// 列名IsGP,彩种是否为高频彩票  
        /// </summary>
        public static readonly String C_IsGP = "IsGP";
        /// <summary>
        /// 列名Times,彩种每天开奖次数。 
        /// </summary>
        public static readonly String C_Times = "Times";
        /// <summary>
        /// 列名PeroidCount,彩种已开奖的总期数
        /// </summary>
        public static readonly String C_PeroidCount = "PeroidCount";
        /// <summary>
        /// 列名DownPageSize,彩种当前下载页的分页大小（即每页有几条记录)
        /// </summary>
        public static readonly String C_DownPageSize = "DownPageSize";
        /// <summary>
        /// 列名DownPageCount,彩种当前数据下载的总页码
        /// </summary>
        public static readonly String C_DownPageCount = "DownPageCount";
        /// <summary>
        /// 列名DownIntervals,彩种数据下载程序下载间隔时间
        /// </summary>
        public static readonly String C_DownIntervals = "DownIntervals";
        /// <summary>
        /// 列名DownPeroid,彩种数据下载程序下载周期(每天、每周、每小时或分钟)
        /// </summary>
        public static readonly String C_DownPeroid = "DownPeroid";
        /// <summary>
        /// 列名DownUrl,彩种数据下载URL
        /// </summary>
        public static readonly String C_DownUrl = "DownUrl";
        /// <summary>
        /// 列名Created,彩种记录创建时间
        /// </summary>
        public static readonly String C_Created = "Created";

        #endregion

        #region Field Members


        private Int32 _id;

        private Int32 _parentId;

        private String _name;

        private String _code;

        private String _dbName;

        private String _ruleType;

        private String _type;

        private String _peroid;

        private Int32 _seq;

        private Byte _enabled;

        private Byte _isGP;

        private Int32 _times;

        private Int32 _peroidCount;

        private Int32 _downPageSize;

        private Int32 _downPageCount;

        private String _downIntervals;

        private String _downPeroid;

        private String _downUrl;

        private DateTime _created = DateTime.Now;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置彩种Id
        /// </summary>
        [Column(Name = "Id", IsIdentity = true)]
        public Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置彩种父ID
        /// </summary>
        [Column(Name = "ParentId")]
        public Int32 ParentId
        {
            get { return this._parentId; }
            set { this._parentId = value; }
        }
        /// <summary>
        /// 获取或设置彩种玩法类型
        /// </summary>
        [Column(Name = "RuleType")]
        public String RuleType
        {
            get { return this._ruleType ?? string.Empty; }
            set { this._ruleType = value; }
        }
        /// <summary>
        /// 获取或设置彩种类型
        /// </summary>
        [Column(Name = "Type")]
        public String Type
        {
            get { return this._type ?? string.Empty; }
            set { this._type = value; }
        }
        /// <summary>
        /// 获取或设置彩种名称
        /// </summary>
        [Column(Name = "Name")]
        public String Name
        {
            get { return this._name ?? string.Empty; }
            set { this._name = value; }
        }
        /// <summary>
        /// 获取或设置彩种代号
        /// </summary>
        [Column(Name = "Code")]
        public String Code
        {
            get { return this._code ?? string.Empty; }
            set { this._code = value; }
        }
        /// <summary>
        /// 获取或设置彩种数据存储的数据库名称
        /// </summary>
        [Column(Name = "DbName")]
        public String DbName
        {
            get { return this._dbName ?? string.Empty; }
            set { this._dbName = value; }
        }
        /// <summary>
        /// 获取或设置彩种开奖周期
        /// </summary>
        [Column(Name = "Peroid")]
        public String Peroid
        {
            get { return this._peroid ?? string.Empty; }
            set { this._peroid = value; }
        }
        /// <summary>
        /// 获取或设置彩种在记录集中排序号
        /// </summary>
        [Column(Name = "Seq")]
        public Int32 Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }
        /// <summary>
        /// 获取或设置彩种是否可用
        /// </summary>
        [Column(Name = "Enabled")]
        public Byte Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }
        /// <summary>
        /// 获取或设置彩种是否为高频彩票
        /// </summary>
        [Column(Name = "IsGP")]
        public Byte IsGP
        {
            get { return this._isGP; }
            set { this._isGP = value; }
        }
        /// <summary>
        /// 获取或设置彩种每天开奖次数
        /// </summary>
        [Column(Name = "Times")]
        public Int32 Times
        {
            get { return this._times; }
            set { this._times = value; }
        }
        /// <summary>
        /// 获取或设置彩种已开奖的总期数
        /// </summary>
        [Column(Name = "PeroidCount")]
        public Int32 PeroidCount
        {
            get { return this._peroidCount; }
            set { this._peroidCount = value; }
        }
        /// <summary>
        /// 获取或设置彩种当前下载页的分页大小（即每页有几条记录)
        /// </summary>
        [Column(Name = "DownPageSize")]
        public Int32 DownPageSize
        {
            get { return this._downPageSize; }
            set { this._downPageSize = value; }
        }
        /// <summary>
        /// 获取或设置彩种当前数据下载的总页码
        /// </summary>
        [Column(Name = "DownPageCount")]
        public Int32 DownPageCount
        {
            get { return this._downPageCount; }
            set { this._downPageCount = value; }
        }
        /// <summary>
        /// 获取或设置彩种数据下载程序下载间隔时间
        /// </summary>
        [Column(Name = "DownIntervals")]
        public String DownIntervals
        {
            get { return this._downIntervals ?? string.Empty; }
            set { this._downIntervals = value; }
        }
        /// <summary>
        /// 获取或设置彩种数据下载程序下载周期(每天、每周、每小时或分钟)
        /// </summary>
        [Column(Name = "DownPeroid")]
        public String DownPeroid
        {
            get { return this._downPeroid ?? string.Empty; }
            set { this._downPeroid = value; }
        }
        /// <summary>
        /// 获取或设置彩种数据下载URL
        /// </summary>
        [Column(Name = "DownUrl")]
        public String DownUrl
        {
            get { return this._downUrl ?? string.Empty; }
            set { this._downUrl = value; }
        }
        /// <summary>
        /// 获取或设置记录创建时间
        /// </summary>
        [Column(Name = "Created")]
        public DateTime Created
        {
            get { return this._created; }
            set { this._created = value; }
        }
        #endregion
    }
}
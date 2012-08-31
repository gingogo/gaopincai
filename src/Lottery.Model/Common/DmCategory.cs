using System;

namespace Lottery.Model.Common
{
    using Data;

    [Serializable]
    public class DmCategory : BaseModel
    {
        public static string EntityName = "DmCategory";

        #region Const Members

        /// <summary>
        /// 列名Id  
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名ParentId  
        /// </summary>
        public static readonly String C_ParentId = "ParentId";
        /// <summary>
        /// 列名Name  
        /// </summary>
        public static readonly String C_Name = "Name";
        /// <summary>
        /// 列名Code  
        /// </summary>
        public static readonly String C_Code = "Code";
        /// <summary>
        /// 列名Type  
        /// </summary>
        public static readonly String C_Type = "Type";
        /// <summary>
        /// 列名Peroid  
        /// </summary>
        public static readonly String C_Peroid = "Peroid";
        /// <summary>
        /// 列名Seq  
        /// </summary>
        public static readonly String C_Seq = "Seq";
        /// <summary>
        /// 列名Enabled  
        /// </summary>
        public static readonly String C_Enabled = "Enabled";
        /// <summary>
        /// 列名IsGP  
        /// </summary>
        public static readonly String C_IsGP = "IsGP";
        /// <summary>
        /// 列名DownPageIndex  
        /// </summary>
        public static readonly String C_DownPageIndex = "DownPageIndex";
        /// <summary>
        /// 列名DownIntervals  
        /// </summary>
        public static readonly String C_DownIntervals = "DownIntervals";
        /// <summary>
        /// 列名DownPeroid  
        /// </summary>
        public static readonly String C_DownPeroid = "DownPeroid";
        /// <summary>
        /// 列名DownUrl  
        /// </summary>
        public static readonly String C_DownUrl = "DownUrl";
        /// <summary>
        /// 列名Created  
        /// </summary>
        public static readonly String C_Created = "Created";
        /// <summary>
        /// 列名DbName  
        /// </summary>
        public static readonly String C_DbName = "DbName";

        #endregion

        #region Field Members


        private Int32 _id;

        private Int32 _parentId;

        private String _name;

        private String _code;

        private String _type;

        private String _peroid;

        private Int32 _seq;

        private Byte _enabled;

        private Byte _isGP;

        private Int32 _downPageIndex;

        private String _downIntervals;

        private String _downPeroid;

        private String _downUrl;

        private DateTime _created = DateTime.Now;

        private String _dbName;

        #endregion

        #region Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Id", IsIdentity = true)]
        public Int32 Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "ParentId")]
        public Int32 ParentId
        {
            get { return this._parentId; }
            set { this._parentId = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Name")]
        public String Name
        {
            get { return this._name ?? string.Empty; }
            set { this._name = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Code")]
        public String Code
        {
            get { return this._code ?? string.Empty; }
            set { this._code = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Type")]
        public String Type
        {
            get { return this._type ?? string.Empty; }
            set { this._type = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Peroid")]
        public String Peroid
        {
            get { return this._peroid ?? string.Empty; }
            set { this._peroid = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Seq")]
        public Int32 Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Enabled")]
        public Byte Enabled
        {
            get { return this._enabled; }
            set { this._enabled = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "IsGP")]
        public Byte IsGP
        {
            get { return this._isGP; }
            set { this._isGP = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DownPageIndex")]
        public Int32 DownPageIndex
        {
            get { return this._downPageIndex; }
            set { this._downPageIndex = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DownIntervals")]
        public String DownIntervals
        {
            get { return this._downIntervals ?? string.Empty; }
            set { this._downIntervals = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DownPeroid")]
        public String DownPeroid
        {
            get { return this._downPeroid ?? string.Empty; }
            set { this._downPeroid = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DownUrl")]
        public String DownUrl
        {
            get { return this._downUrl ?? string.Empty; }
            set { this._downUrl = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Created")]
        public DateTime Created
        {
            get { return this._created; }
            set { this._created = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DbName")]
        public String DbName
        {
            get { return this._dbName ?? string.Empty; }
            set { this._dbName = value; }
        }

        #endregion
    }
}
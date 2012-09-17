using System;

namespace Lottery.Model.D3
{
    using Data;

    /// <summary>
    /// 所有玩法排列组合维度表。
    /// </summary>
    [Serializable]
    public class DmDPC : BaseModel
    {
        #region Const Members

        /// <summary>
        /// 列名Id  
        /// </summary>
        public static readonly String C_Id = "Id";
        /// <summary>
        /// 列名Number  
        /// </summary>
        public static readonly String C_Number = "Number";
        /// <summary>
        /// 列名DaXiao  
        /// </summary>
        public static readonly String C_DaXiao = "DaXiao";
        /// <summary>
        /// 列名DanShuang  
        /// </summary>
        public static readonly String C_DanShuang = "DanShuang";
        /// <summary>
        /// 列名ZiHe  
        /// </summary>
        public static readonly String C_ZiHe = "ZiHe";
        /// <summary>
        /// 列名Lu012  
        /// </summary>
        public static readonly String C_Lu012 = "Lu012";
        /// <summary>
        /// 列名He  
        /// </summary>
        public static readonly String C_He = "He";
        /// <summary>
        /// 列名HeWei  
        /// </summary>
        public static readonly String C_HeWei = "HeWei";
        /// <summary>
        /// 列名DaCnt  
        /// </summary>
        public static readonly String C_DaCnt = "DaCnt";
        /// <summary>
        /// 列名XiaoCnt  
        /// </summary>
        public static readonly String C_XiaoCnt = "XiaoCnt";
        /// <summary>
        /// 列名DanCnt  
        /// </summary>
        public static readonly String C_DanCnt = "DanCnt";
        /// <summary>
        /// 列名ShuangCnt  
        /// </summary>
        public static readonly String C_ShuangCnt = "ShuangCnt";
        /// <summary>
        /// 列名ZiCnt  
        /// </summary>
        public static readonly String C_ZiCnt = "ZiCnt";
        /// <summary>
        /// 列名HeCnt  
        /// </summary>
        public static readonly String C_HeCnt = "HeCnt";
        /// <summary>
        /// 列名Lu0Cnt  
        /// </summary>
        public static readonly String C_Lu0Cnt = "Lu0Cnt";
        /// <summary>
        /// 列名Lu1Cnt  
        /// </summary>
        public static readonly String C_Lu1Cnt = "Lu1Cnt";
        /// <summary>
        /// 列名Lu2Cnt  
        /// </summary>
        public static readonly String C_Lu2Cnt = "Lu2Cnt";
        /// <summary>
        /// 列名Ji  
        /// </summary>
        public static readonly String C_Ji = "Ji";
        /// <summary>
        /// 列名JiWei  
        /// </summary>
        public static readonly String C_JiWei = "JiWei";
        /// <summary>
        /// 列名KuaDu  
        /// </summary>
        public static readonly String C_KuaDu = "KuaDu";
        /// <summary>
        /// 列名AC  
        /// </summary>
        public static readonly String C_AC = "AC";
        #endregion

        #region Field Members


        private string _id;

        private string _number;

        private string _daXiao;

        private string _danShuang;

        private string _ziHe;

        private string _lu012;

        private int _he;

        private int _heWei;

        private int _daCnt;

        private int _xiaoCnt;

        private int _danCnt;

        private int _shuangCnt;

        private int _ziCnt;

        private int _heCnt;

        private int _lu0Cnt;

        private int _lu1Cnt;

        private int _lu2Cnt;

        private int _ji;

        private int _jiWei;

        private int _kuaDu;

        private int _aC;

        #endregion

        #region Table Property Members

        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Id", IsPrimaryKey = true)]
        public virtual String Id
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Number")]
        public virtual String Number
        {
            get { return this._number; }
            set { this._number = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DaXiao")]
        public virtual String DaXiao
        {
            get { return this._daXiao; }
            set { this._daXiao = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DanShuang")]
        public virtual String DanShuang
        {
            get { return this._danShuang; }
            set { this._danShuang = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "ZiHe")]
        public virtual String ZiHe
        {
            get { return this._ziHe; }
            set { this._ziHe = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Lu012")]
        public virtual String Lu012
        {
            get { return this._lu012; }
            set { this._lu012 = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "He")]
        public virtual Int32 He
        {
            get { return this._he; }
            set { this._he = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "HeWei")]
        public virtual Int32 HeWei
        {
            get { return this._heWei; }
            set { this._heWei = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DaCnt")]
        public virtual Int32 DaCnt
        {
            get { return this._daCnt; }
            set { this._daCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "XiaoCnt")]
        public virtual Int32 XiaoCnt
        {
            get { return this._xiaoCnt; }
            set { this._xiaoCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "DanCnt")]
        public virtual Int32 DanCnt
        {
            get { return this._danCnt; }
            set { this._danCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "ShuangCnt")]
        public virtual Int32 ShuangCnt
        {
            get { return this._shuangCnt; }
            set { this._shuangCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "ZiCnt")]
        public virtual Int32 ZiCnt
        {
            get { return this._ziCnt; }
            set { this._ziCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "HeCnt")]
        public virtual Int32 HeCnt
        {
            get { return this._heCnt; }
            set { this._heCnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Lu0Cnt")]
        public virtual Int32 Lu0Cnt
        {
            get { return this._lu0Cnt; }
            set { this._lu0Cnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Lu1Cnt")]
        public virtual Int32 Lu1Cnt
        {
            get { return this._lu1Cnt; }
            set { this._lu1Cnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Lu2Cnt")]
        public virtual Int32 Lu2Cnt
        {
            get { return this._lu2Cnt; }
            set { this._lu2Cnt = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "Ji")]
        public virtual int Ji
        {
            get { return this._ji; }
            set { this._ji = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "JiWei")]
        public virtual int JiWei
        {
            get { return this._jiWei; }
            set { this._jiWei = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "KuaDu")]
        public virtual int KuaDu
        {
            get { return this._kuaDu; }
            set { this._kuaDu = value; }
        }
        /// <summary>
        /// 获取或设置
        /// </summary>
        [Column(Name = "AC")]
        public virtual int AC
        {
            get { return this._aC; }
            set { this._aC = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}",
                this._id, this._number, this._daXiao, this._danShuang, this._ziHe, this._lu012, this._he, this._heWei, this._daCnt,
                this._xiaoCnt, this._danCnt, this._shuangCnt, this._ziCnt, this._heCnt, this._lu0Cnt, this._lu1Cnt, this._lu2Cnt,
                this._ji, this._jiWei, this._kuaDu, this._aC);
        }
    }
}
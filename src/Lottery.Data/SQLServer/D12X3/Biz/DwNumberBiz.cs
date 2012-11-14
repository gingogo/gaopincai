using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Lottery.Data.SQLServer.D12X3
{
    using Common;
    using Configuration;
    using Logging;
    using Model.D12X3;
    using Utils;

    public class DwNumberBiz : SinglePKDataAccessBiz<DwNumberDAO, DwNumber>
    {
        public DwNumberBiz(string dbName)
            : base(new DwNumberDAO(ConfigHelper.GetConnString(dbName)))
        {
        }

        public DateTime GetLatestDate()
        {
            int num = DataAccessor.SelectLatestDate(string.Empty);
            if (num == 0) return DateTime.Now.AddDays(-3);
            return DateTime.ParseExact(num.ToString(), "yyyyMMdd", null);
        }

        public long GetLatestPeroid()
        {
            return this.DataAccessor.SelectLatestPeroid(string.Empty);
        }

        public HashSet<long> GetPeroidsByDate(DateTime date)
        {
            string dayOfBefore3 = date.AddDays(-1).ToString("yyyyMMdd");
            Operand operand = Restrictions.Clause(SqlClause.Where)
                .Append(Restrictions.GreaterThanOrEqual(DwNumber.C_Date, dayOfBefore3));
            var dtos = this.DataAccessor.SelectWithCondition(operand.ToString(), DwNumber.C_P);
            HashSet<long> hashSet = new HashSet<long>();
            foreach (var dto in dtos) hashSet.Add(dto.P);
            return hashSet;
        }

        public int Count
        {
            get { return this.DataAccessor.Count(); }
        }

        public DwNumber Create(long p, int n, string code, int date, string datetime)
        {
            string[] arr = code.Split(',');
            string[] arrLastD1 = this.GetLast2D1();
            DwNumber number = new DwNumber();
            number.P = p;
            number.N = n;
            number.Seq = this.Count + 1;
            number.Date = date;
            number.Created = ConvertHelper.GetDateTime(datetime);
            number.D1 = ConvertHelper.GetInt32(arr[0]);
            number.D2 = ConvertHelper.GetInt32(arr[1]);
            number.D3 = ConvertHelper.GetInt32(arr[2]);
            number.P3 = code.Replace(",", "");
            number.P2 = number.P3.Substring(0, 4);
            number.C2 = NumberCache.Instance.GetNumberId("C2", string.Format("{0},{1}", arr[0], arr[1]));
            number.C3 = NumberCache.Instance.GetNumberId("C3", string.Format("{0},{1},{2}", arr[0], arr[1], arr[2]));
            number.G2 = string.Format("{0}{1}", arrLastD1[0], arr[0]);
            number.G3 = string.Format("{0}{1}{2}", arrLastD1[1], arrLastD1[0], arr[0]);
            number.Z2 = NumberCache.Instance.GetNumberId("Z2", string.Format("{0},{1}", arrLastD1[0], arr[0]));
            number.Z3 = NumberCache.Instance.GetNumberId("Z3", string.Format("{0},{1},{2}", arrLastD1[1], arrLastD1[0], arr[0]));

            return number;
        }

        public bool Add(long p, int n, string code, int date, string datetime)
        {
            DwNumber number = this.Create(p, n, code, date, datetime);
            return this.SaveToDB(number);
        }

        private void AddSpan(DwNumber number)
        {
            string[] dmNames = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("12X3");
            List<BatchEntity<DwSpan>> batchEntities = new List<BatchEntity<DwSpan>>(dmNames.Length);
            foreach (string dmName in dmNames)
            {
                string[] numberTypes = DimensionNumberTypeBiz.Instance.GetNumberTypes("12X3", dmName);
                Dictionary<string, int> spanDict = this.DataAccessor.SelectSpansByNumberTypes(number, dmName, numberTypes);
                DwSpan dwSpan = new DwSpan() { P = number.P };
                foreach (string key in spanDict.Keys)
                {
                    string propertyName = string.Format("{0}Spans", key);
                    dwSpan[propertyName] = spanDict[key];
                }

                string destTableName = ConfigHelper.GetDwSpanTableName(dmName);
                string[] columnNames = numberTypes.Select(x => x + "Spans").Union(new string[] { "P" }).ToArray();
                BatchEntity<DwSpan> batchEntity = new BatchEntity<DwSpan>(dwSpan, destTableName, columnNames);
                batchEntities.Add(batchEntity);
            }

            DwSpanDAO spanDao = new DwSpanDAO(string.Empty, this.DataAccessor.ConnectionString);
            spanDao.Insert(batchEntities);
        }

        private bool SaveToDB(DwNumber number)
        {
            try
            {
                TransactionOptions option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadUncommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    this.AddSpan(number);
                    this.Add(number);
                    scope.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex.ToString());
                return false;
            }
        }

        private string[] GetLast2D1()
        {
            string[] arrD1 = new string[] { "00", "00" };
            var list = this.DataAccessor.SelectTopN(2, string.Empty, DwNumber.C_Seq, SortTypeEnum.DESC, null, DwNumber.C_D1);
            if (list.Count == 0) return arrD1;
            if (list.Count == 1)
            {
                arrD1[0] = list[0].D1.ToString("D2");
                return arrD1;
            }

            return list.Select(x => x.D1.ToString("D2")).ToArray();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Lottery.Data.SQLServer.D11X5
{
    using Common;
    using Configuration;
    using Logging;
    using Model.D11X5;
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
            DwNumber number = new DwNumber();
            number.P = p;
            number.N = n;
            number.Seq = this.Count + 1;
            number.Date = date;
            number.Created = ConvertHelper.GetDateTime(datetime);
            number.D1 = ConvertHelper.GetInt32(arr[0]);
            number.D2 = ConvertHelper.GetInt32(arr[1]);
            number.D3 = ConvertHelper.GetInt32(arr[2]);
            number.D4 = ConvertHelper.GetInt32(arr[3]);
            number.D5 = ConvertHelper.GetInt32(arr[4]);
            number.P5 = code.Replace(",", "");
            number.P3 = number.P5.Substring(0, 6);
            number.P2 = number.P5.Substring(0, 4);
            number.C2 = NumberCache.Instance.GetNumberId("C2", string.Format("{0},{1}", arr[0], arr[1]));
            number.C3 = NumberCache.Instance.GetNumberId("C3", string.Format("{0},{1},{2}", arr[0], arr[1], arr[2]));
            number.C5 = NumberCache.Instance.GetNumberId("C5", code);
            return number;
        }

        public bool Add(long p, int n, string code, int date, string datetime)
        {
            DwNumber number = this.Create(p, n, code, date, datetime);
            return this.SaveToDB(number);
        }

        private void AddSpan(DwNumber number)
        {
            string[] dmNames = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("11X5");
            List<BatchEntity<DwSpan>> batchEntities = new List<BatchEntity<DwSpan>>(dmNames.Length);
            foreach (string dmName in dmNames)
            {
                //非任选号码类型
                string[] numberTypes = DimensionNumberTypeBiz.Instance.GetNumberTypes("11X5", dmName).Where(x => !x[0].Equals('A')).ToArray();
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

        public void AddC5CXSpan(DwNumber number)
        {
            string[] dmNames = new string[] { "Peroid", "He" };
            string[] numberTypes = new string[] { "A2", "A3", "A4", "A6", "A7", "A8" };
            List<BatchEntity<DwC5CXSpan>> batchEntities = new List<BatchEntity<DwC5CXSpan>>(70);
            DwC5CXSpanDAO spanDao = new DwC5CXSpanDAO(string.Empty, this.DataAccessor.ConnectionString);

            foreach (var numberType in numberTypes)
            {
                string newNumberType = numberType.Replace("A", "C");
                string tableName = ConfigHelper.GetDwSpanTableName(string.Format("{0}{1}", "C5", newNumberType));
                var c5cxNumbers = NumberCache.Instance.GetC5CXNumbers(number.C5, newNumberType);
                var lastSpanDict = spanDao.SelectLastSpans(c5cxNumbers, number.Seq, tableName, dmNames, newNumberType);
                var c5cxSpans = this.GetC5CXSpans(lastSpanDict, c5cxNumbers, number, tableName, dmNames);
                batchEntities.AddRange(c5cxSpans);
            }

            spanDao.Insert(batchEntities);
        }

        private List<BatchEntity<DwC5CXSpan>> GetC5CXSpans(Dictionary<string,Dictionary<string, int>> lastSpanDict,
            List<DmC5CX> c5cxNumbers, DwNumber number, string tableName, string[] dmNames)
        {
            List<BatchEntity<DwC5CXSpan>> c5cxSpans = new List<BatchEntity<DwC5CXSpan>>(c5cxNumbers.Count);
            foreach (var c5cxNumber in c5cxNumbers)
            {
                DwC5CXSpan c5cxSpan = new DwC5CXSpan() { P = number.P, Seq = number.Seq, C5 = number.C5, CX = c5cxNumber.CX };
                foreach (string dmName in dmNames)
                {
                    string propertyName = dmName + "Spans";
                    c5cxSpan[propertyName] = lastSpanDict[dmName][c5cxNumber.CX];
                }
                c5cxSpans.Add(new BatchEntity<DwC5CXSpan>(c5cxSpan, tableName));
            }

            return c5cxSpans;
        }

        private bool SaveToDB(DwNumber number)
        {
            try
            {
                TransactionOptions option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadUncommitted;
                using (TransactionScope scope = 
                    new TransactionScope(TransactionScopeOption.Required, option))
                {
                    this.AddSpan(number);
                    //this.AddC5CXSpan(number);
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
    }
}


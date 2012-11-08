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
            string[] dmNames = DimensionNumberTypeBiz.Instance.GetDimensions("11X5");
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

        private void AddC5CXSpan()
        {
            string[] dmNames = new string[] { "Peroid", "He" };
            string[] numberTypes = new string[] { "A2", "A3", "A4", "A6", "A7", "A8" };
            DwC5CXSpanDAO dao = new DwC5CXSpanDAO(string.Empty, this.DataAccessor.ConnectionString);

            foreach (var numberType in numberTypes)
            {
                string newNumberType = numberType.Replace("A", "C");
                string tableName = string.Format("{0}{1}", "C5", newNumberType);
                dao.TableName = ConfigHelper.GetDwSpanTableName(tableName);

                long latestP = dao.SelectLatestPeroid(string.Empty);
                List<DwNumber> numbers = this.DataAccessor.SelectWithCondition(string.Format("WHERE {0} > {1} ", DwNumber.C_P, latestP));

                Dictionary<string, Dictionary<string, int>> lastSpanDict = new Dictionary<string, Dictionary<string, int>>(16);
                List<DwC5CXSpan> c5cxSpans = new List<DwC5CXSpan>(numbers.Count * 20);

                foreach (DwNumber number in numbers)
                {
                    var cxNumbers = NumberCache.Instance.GetC5CXNumbers(number.C5, newNumberType);
                    c5cxSpans.AddRange(this.GetC5CXSpanList(lastSpanDict, cxNumbers, number, dmNames));
                }

                dao.Insert(c5cxSpans, SqlInsertMethod.SqlBulkCopy);
            }
        }

        private List<DwC5CXSpan> GetC5CXSpanList(Dictionary<string, Dictionary<string, int>> lastSpanDict, List<DmC5CX> cxNumbers, DwNumber number, string[] dmNames)
        {
            List<DwC5CXSpan> c5cxSpans = new List<DwC5CXSpan>(cxNumbers.Count);
            foreach (var cxNumber in cxNumbers)
            {
                DwC5CXSpan c5cxSpan = this.GetC5CXSpan(lastSpanDict, number, dmNames, cxNumber);
                c5cxSpans.Add(c5cxSpan);
            }

            return c5cxSpans;
        }

        private DwC5CXSpan GetC5CXSpan(Dictionary<string, Dictionary<string, int>> lastSpanDict, DwNumber number, string[] dmNames, DmC5CX cxNumber)
        {
            DwC5CXSpan c5cxSpan = new DwC5CXSpan();
            c5cxSpan.P = number.P;
            c5cxSpan.Seq = number.Seq;
            c5cxSpan.C5 = number.C5;
            c5cxSpan.CX = cxNumber.CX;

            foreach (string dmName in dmNames)
            {
                if (!lastSpanDict.ContainsKey(dmName))
                    lastSpanDict.Add(dmName, new Dictionary<string, int>(1000));

                string propertyName = dmName + "Spans";
                int spans = number.Seq - 1;
                string dmValue = cxNumber.CX.GetDmValue(2, dmName, 5);

                if (lastSpanDict[dmName].ContainsKey(dmValue))
                {
                    spans = number.Seq - lastSpanDict[dmName][dmValue] - 1;
                    lastSpanDict[dmName][dmValue] = number.Seq;
                }
                else
                {
                    lastSpanDict[dmName].Add(dmValue, number.Seq);
                }
                c5cxSpan[propertyName] = spans;
            }

            return c5cxSpan;
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
                    this.Add(number);
                    scope.Complete();
                }
                //using (TransactionScope scope1 = 
                //    new TransactionScope(TransactionScopeOption.Required, option))
                //{
                //    this.AddC5CXSpan();
                //    scope1.Complete();
                //}
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


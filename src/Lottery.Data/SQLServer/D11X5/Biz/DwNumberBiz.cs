using System;
using System.Collections.Generic;
using System.Transactions;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    public class DwNumberBiz : SinglePKDataAccessBiz<DwNumberDAO, DwNumber>
    {
        private static object lockObj = new object();

        public DwNumberBiz(string dbName)
            : base(new DwNumberDAO(ConfigHelper.GetConnString(dbName)))
        {
        }

        public DateTime GetLatestDate()
        {
            int num = DataAccessor.SelectLatestDate(string.Empty);
            if (num == 0) 
                return new DateTime(2010, 1, 5);

            return DateTime.ParseExact(num.ToString(), "yyyyMMdd", null);
        }

        public HashSet<long> GetPeroidsOfByDate(DateTime date)
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

        public void RepairPeroidSpan(string name)
        {
            //DwPeroidSpanDAO spanDao = new DwPeroidSpanDAO(ConfigHelper.GetDwSpanTableName(name),
            //    this.DataAccessor.ConnectionString);
            //long maxPeroid = spanDao.SelectMaxPeroid();

            //if (maxPeroid == -1)
            //    throw new ArgumentOutOfRangeException("MaxPeroid");

            //Operand operand = Restrictions.Clause(SqlClause.Where)
            //    .Append(Restrictions.GreaterThan(DwNumber.C_P, maxPeroid));
            //var dtos = this.DataAccessor.SelectWithCondition(operand.ToString(), DwNumber.C_P, SortTypeEnum.ASC, null);
            //foreach (var dto in dtos)
            //{
            //    string numberId = this.GetNumberIdByProperty(dto, name);
            //    string filter = Restrictions.And.Append(Restrictions.LessThan(DwNumber.C_Seq, dto.Seq)).ToString();
            //    this.AddPeroidSpan(numberId, name, dto.Seq, dto.P, filter);
            //}
        }

        public string GetNumberIdByProperty(DwNumber number,string name)
        {
            if(number[name] == null)
                throw new ArgumentOutOfRangeException("name");
            return number[name].ToString().Trim();
        }

        public void Add(long p, int n, string code, int date, string datetime)
        {
            lock (lockObj)
            {
                if (string.IsNullOrEmpty(code) ||
                    code.Trim().Length == 0) return;

                string[] arr = code.Split(',');
                DwNumber number = new DwNumber();
                number.Code = code;
                number.Date = date;
                number.P = p;
                number.N = n;
                number.Seq = this.Count + 1;
                number.D1 = ConvertHelper.GetInt32(arr[0]);
                number.D2 = ConvertHelper.GetInt32(arr[1]);
                number.D3 = ConvertHelper.GetInt32(arr[2]);
                number.D4 = ConvertHelper.GetInt32(arr[3]);
                number.D5 = ConvertHelper.GetInt32(arr[4]);
                number.Created = ConvertHelper.GetDateTime(datetime);
                number.F5 = code.Replace(",", "");
                number.F2 = number.F5.Substring(0, 4);
                number.F3 = number.F5.Substring(0, 6);
                number.C2 = NumberBiz.Instance.GetC2Id(string.Format("{0},{1}", arr[0], arr[1]));
                number.C3 = NumberBiz.Instance.GetC3Id(string.Format("{0},{1},{2}", arr[0], arr[1], arr[2]));
                number.A5 = NumberBiz.Instance.GetA5Id(code);

                this.SaveToDB(number);
            }
        }

        private void AddPeroidSpan(DwNumber number, string filter)
        {
            Dictionary<string, int> spanDict = this.DataAccessor.SelectPeroidSpansByNumberTypes(number, filter);
            DwSpan span = new DwSpan() { P = number.P };
            foreach (string key in spanDict.Keys)
            {
                string propertyName = string.Format("{0}Spans", key);
                span[propertyName] = spanDict[key];
            }

            DwSpanDAO spanDao = new DwSpanDAO(ConfigHelper.GetDwSpanTableName("Peroid"), this.DataAccessor.ConnectionString);
            spanDao.Insert(span);
        }

        private void SaveToDB(DwNumber number)
        {
            TransactionOptions option = new TransactionOptions();
            option.IsolationLevel = IsolationLevel.ReadUncommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                this.AddPeroidSpan(number, string.Empty);
                this.Add(number);
                scope.Complete();
            }
        }
    }
}


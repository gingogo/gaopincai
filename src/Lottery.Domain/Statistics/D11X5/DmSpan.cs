using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.D11X5
{
    using Configuration;
    using Data;
    using Data.SQLServer;
    using Data.SQLServer.Common;
    using Data.SQLServer.D11X5;
    using Model.D11X5;
    using Utils;

    /// <summary>
    /// 统计所有维度的遗漏数。
    /// </summary>
    public class DmSpan : Base11X5Statistics
    {
        protected override void Stat(string dbName)
        {
            string[] dmNames = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("11X5");
            DwNumberBiz biz = new DwNumberBiz(dbName);
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);

            this.Stat(dbName, dmNames, numbers);
            //this.StatC5CX(numbers, dbName);
        }

        private void Stat(string dbName, string[] dmNames, List<DwNumber> numbers)
        {
            foreach (string dmName in dmNames)
            {
                string[] numberTypes = DimensionNumberTypeBiz.Instance.GetNumberTypes("11X5", dmName).Where(x => !x[0].Equals('A')).ToArray();
                this.Stat(numbers, dbName, dmName, numberTypes, null);
            }

            Console.WriteLine("{0} {1} Finished", dbName, "ALL Span");
        }

        public void StatC5CX(List<DwNumber> numbers, string dbName)
        {
            string[] dmNames = new string[] { "Peroid", "He" };
            string[] numberTypes = new string[] { "A2", "A3", "A4", "A6", "A7", "A8" };
            DwC5CXSpanBiz spanBiz = new DwC5CXSpanBiz(dbName);

            foreach (var numberType in numberTypes)
            {
                Dictionary<string, Dictionary<string, int>> lastSpanDict = new Dictionary<string, Dictionary<string, int>>(16);
                List<DwC5CXSpan> c5cxSpans = new List<DwC5CXSpan>(numbers.Count * 20);
                string newNumberType = numberType.Replace("A", "C");
                string tableName = string.Format("{0}{1}", "C5", newNumberType);
                spanBiz.DataAccessor.TableName = ConfigHelper.GetDwSpanTableName(tableName);
                long lastP = spanBiz.DataAccessor.SelectLatestPeroid(string.Empty);

                foreach (DwNumber number in numbers)
                {
                    var cxNumbers = NumberCache.Instance.GetC5CXNumbers(number.C5, newNumberType);
                    var c5cxSpanList = this.GetC5CXSpanList(lastSpanDict, cxNumbers, number, dmNames);
                    if (number.P > lastP)
                        c5cxSpans.AddRange(c5cxSpanList);
                }
                spanBiz.DataAccessor.Insert(c5cxSpans, SqlInsertMethod.SqlBulkCopy);

                Console.WriteLine("{0} {1} Finished", dbName, tableName);
            }

            Console.WriteLine("{0} {1} Finished", dbName, "ALL C5CX Span");
        }

        private void Stat(List<DwNumber> numbers, string dbName, string dmName,string[] numberTypes, StreamWriter writer)
        {
            Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict = new Dictionary<string, Dictionary<string, int>>(100000);
            List<DwSpan> entities = new List<DwSpan>(numbers.Count);

            foreach (DwNumber number in numbers)
            {
                Dictionary<string, int> pSpanDict = GetSpanDict(numberTypeLastSpanDict, dmName, numberTypes, number);
                entities.Add(this.CreateSpan(number, pSpanDict));
            }

            string[] colmnNames = numberTypes.Select(x => x + "Spans").Union(new string[] { "P" }).ToArray();
            this.SaveSpanToDB(dbName, dmName, entities, colmnNames);

            Console.WriteLine("{0} {1} Finished", dbName, dmName);
        }

        private Dictionary<string, int> GetSpanDict(Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict, string dmName, string[] numberTypes, DwNumber number)
        {
            if (dmName.Equals("Peroid"))
                return this.GetPeroidSpanDict(numberTypeLastSpanDict, numberTypes, number);

            Dictionary<string, int> pSpanDict = new Dictionary<string, int>(numberTypes.Length);
            foreach (string numberType in numberTypes)
            {
                if (!numberTypeLastSpanDict.ContainsKey(numberType))
                    numberTypeLastSpanDict.Add(numberType, new Dictionary<string, int>(1000));

                int spans = number.Seq - 1;
                string dmValue = number[numberType].GetDmValue(2, dmName, 5);
                if (numberTypeLastSpanDict[numberType].ContainsKey(dmValue))
                {
                    spans = number.Seq - numberTypeLastSpanDict[numberType][dmValue] - 1;
                    numberTypeLastSpanDict[numberType][dmValue] = number.Seq;
                }
                else
                {
                    numberTypeLastSpanDict[numberType].Add(dmValue, number.Seq);
                }
                pSpanDict.Add(numberType, spans);
            }
            return pSpanDict;
        }

        private Dictionary<string, int> GetPeroidSpanDict(Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict, string[] numberTypes, DwNumber number)
        {
            Dictionary<string, int> pSpanDict = new Dictionary<string, int>(numberTypes.Length);
            foreach (string numberType in numberTypes)
            {
                if (!numberTypeLastSpanDict.ContainsKey(numberType))
                    numberTypeLastSpanDict.Add(numberType, new Dictionary<string, int>(1000));

                int spans = number.Seq - 1;
                string numTypeValue = number[numberType].ToString();
                if (numberTypeLastSpanDict[numberType].ContainsKey(numTypeValue))
                {
                    spans = number.Seq - numberTypeLastSpanDict[numberType][numTypeValue] - 1;
                    numberTypeLastSpanDict[numberType][numTypeValue] = number.Seq;
                }
                else
                {
                    numberTypeLastSpanDict[numberType].Add(numTypeValue, number.Seq);
                }
                pSpanDict.Add(numberType, spans);
            }
            return pSpanDict;
        }

        private List<DwC5CXSpan> GetC5CXSpanList(Dictionary<string,Dictionary<string, int>> lastSpanDict, List<DmC5CX> cxNumbers, DwNumber number,string[] dmNames)
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

        private void SaveSpanToDB(string dbName, string tableName, List<DwSpan> spans, params string[] columnNames)
        {
            DwSpanDAO spanDao = new DwSpanDAO(ConfigHelper.GetDwSpanTableName(tableName), ConfigHelper.GetConnString(dbName));
            spanDao.Truncate();
            spanDao.Insert(spans, SqlInsertMethod.SqlBulkCopy, columnNames);
        }

        private DwSpan CreateSpan(DwNumber number, Dictionary<string, int> pSpanDict)
        {
            DwSpan span = new DwSpan() { P = number.P };
            foreach (string key in pSpanDict.Keys)
            {
                string propertyName = string.Format("{0}Spans", key);
                span[propertyName] = pSpanDict[key];
            }
            return span;
        }
    }
}

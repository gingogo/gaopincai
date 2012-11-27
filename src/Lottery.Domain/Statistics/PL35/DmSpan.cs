using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lottery.Statistics.PL35
{
    using Configuration;
    using Data;
    using Data.SQLServer;
    using Data.SQLServer.Common;
    using Data.SQLServer.PL35;
    using Model.PL35;
    using Utils;

    /// <summary>
    /// 统计所有维度的遗漏数。
    /// </summary>
    public class DmSpan : BasePL35Statistics
    {
        protected override void Stat(string dbName)
        {
            string[] dmNames = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("PL35");
            DwNumberBiz biz = new DwNumberBiz(dbName);
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);

            foreach (string dmName in dmNames)
            {
                string[] numberTypes = DimensionNumberTypeBiz.Instance.GetNumberTypes("PL35", dmName);
                this.Stat(numbers, dbName, dmName, numberTypes, null);
            }

            Console.WriteLine("{0} {1} Finished", dbName, "ALL Span");
        }

        private void Stat(List<DwNumber> numbers, string dbName, string dmName, string[] numberTypes, StreamWriter writer)
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
                string dmValue = number[numberType].GetDmValue(1, dmName, 4);
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

        private void SaveSpanToDB(string dbName, string tableName, DwSpan span)
        {
            DwSpanDAO spanDao = new DwSpanDAO(ConfigHelper.GetDwSpanTableName(tableName), ConfigHelper.GetConnString(dbName));
            spanDao.Insert(span);
        }

        private void SaveSpanToDB(string dbName, string tableName, List<DwSpan> spans, params string[] columnNames)
        {
            DwSpanDAO spanDao = new DwSpanDAO(ConfigHelper.GetDwSpanTableName(tableName), ConfigHelper.GetConnString(dbName));
            spanDao.Truncate();
            spanDao.Insert(spans, SqlInsertMethod.SqlBulkCopy, columnNames);
        }

        private void SaveSpanToText(DwSpan span, StreamWriter writer)
        {
            writer.WriteLine(span.ToString());
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

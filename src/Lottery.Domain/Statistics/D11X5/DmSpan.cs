using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lottery.Statistics.D11X5
{
    using Data;
    using Data.SQLServer.D11X5;
    using Model.D11X5;
    using Utils;

    /// <summary>
    /// 统计期数间隔的分布。
    /// Field:DwPeroidSpan表中的字段
    /// </summary>
    public class DmSpan : BaseSpan
    {
        protected override void Stat(string dbName, OutputType outputType)
        {
            string[] dmNames = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };
            string[] numberTypes = new string[] { "D1", "D2", "D3", "D4", "D5", "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };

            DwNumberBiz biz = new DwNumberBiz(dbName);
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);
            //List<DwNumber> allNumbers = biz.DataAccessor.SelectTopN(10, string.Empty, "P", SortTypeEnum.ASC, null);

            foreach (string dmName in dmNames)
            {
                if (outputType == OutputType.Database)
                    this.Stat(numbers, dbName, dmName, numberTypes, null);
                else
                {
                    string fileName = string.Format("{0}_{1}.txt", dbName, dmName);
                    StreamWriter writer = new StreamWriter(this.GetOutputFileName(fileName), false, Encoding.UTF8);
                    this.Stat(numbers, dbName, dmName, numberTypes, writer);
                    writer.Close();
                }
            }

            Console.WriteLine("{0} {1} Finished", dbName, "DmSpan");
        }

        private void Stat(List<DwNumber> numbers, 
            string dbName, string dmName,string[] numberTypes, StreamWriter writer)
        {
            Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict =
                new Dictionary<string, Dictionary<string, int>>(100000);

            List<DwSpan> entities = new List<DwSpan>(numbers.Count);
            foreach (DwNumber number in numbers)
            {
                Dictionary<string, int> pSpanDict = GetSpanDict(numberTypeLastSpanDict, dmName, numberTypes, number);
                DwSpan span = this.CreateSpan(number, pSpanDict);
                if (writer != null)
                    this.SaveSpanToText(span, writer);
                else
                    entities.Add(span);
                    //this.SaveSpanToDB(dbName, dmName, span);
            }
            this.SaveSpanToDB(dbName, dmName, entities);
        }

        private Dictionary<string, int> GetSpanDict(Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict,
            string dmName, string[] numberTypes, DwNumber number)
        {
            Dictionary<string, int> pSpanDict = new Dictionary<string, int>(numberTypes.Length);
            foreach (string numberType in numberTypes)
            {
                if (!numberTypeLastSpanDict.ContainsKey(numberType))
                    numberTypeLastSpanDict.Add(numberType, new Dictionary<string, int>(1000));

                int spans = -1;
                string dmValue = number[numberType].GetDmValue(2,dmName, 5);
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
    }
}

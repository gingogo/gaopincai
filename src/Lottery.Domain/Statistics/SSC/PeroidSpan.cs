using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lottery.Statistics.SSC
{
    using Data;
    using Data.SQLServer.SSC;
    using Model.SSC;

    /// <summary>
    /// 统计期数间隔的分布。
    /// Field:DwPeroidSpan表中的字段
    /// </summary>
    public class PeroidSpan : BaseSpan
    {
        protected override void Stat(string dbName,OutputType outputType)
        {
            DwNumberBiz biz = new DwNumberBiz(dbName);
            List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);
            //List<DwNumber> allNumbers = biz.DataAccessor.SelectTopN(10, string.Empty, "P", SortTypeEnum.ASC, null);
            string[] numberTypes = new string[] { "D1", "D2", "D3", "D4", "D5", "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };

            if (outputType == OutputType.Database)
                this.Stat(numbers, dbName, numberTypes, null);
            else
            {
                string fileName = string.Format("{0}_{1}.txt", dbName, "PeroidSpan");
                StreamWriter writer = new StreamWriter(this.GetOutputFileName(fileName), false, Encoding.UTF8);
                this.Stat(numbers, dbName, numberTypes, writer);
                writer.Close();
            }

            Console.WriteLine("{0} {1} Finished", dbName, "PeroidSpan");
        }

        private void Stat(List<DwNumber> numbers, string dbName, string[] numberTypes, StreamWriter writer)
        {
            Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict =
                new Dictionary<string, Dictionary<string, int>>(numbers.Count);

            List<DwSpan> entities = new List<DwSpan>(numbers.Count);
            foreach (DwNumber number in numbers)
            {
                Dictionary<string, int> pSpanDict = GetPeroidSpanDict(numberTypes, numberTypeLastSpanDict, number);
                DwSpan span = this.CreateSpan(number, pSpanDict);
                if (writer != null)
                    this.SaveSpanToText(span, writer);
                else
                    entities.Add(span);
                //this.SaveSpanToDB(dbName, "Peroid", span);
            }
            this.SaveSpanToDB(dbName, "Peroid", entities);
        }

        private Dictionary<string, int> GetPeroidSpanDict(string[] numberTypes, 
            Dictionary<string, Dictionary<string, int>> numberTypeLastSpanDict, DwNumber number)
        {
            Dictionary<string, int> pSpanDict = new Dictionary<string, int>(numberTypes.Length);
            foreach (string numberType in numberTypes)
            {
                if (!numberTypeLastSpanDict.ContainsKey(numberType))
                    numberTypeLastSpanDict.Add(numberType, new Dictionary<string, int>(1000));

                int spans = -1;
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
    }
}

using System;
using System.Collections.Generic;

namespace Lottery.Statistics.D11X5
{
	using Configuration;
	using Data;
	
	using Data.Biz.Common;
	using Data.Biz.D11X5;
	using Model.D11X5;
	using Utils;
	
	/// <summary>
	/// 11选5彩种任二，三，四，六，七，八玩法遗漏值统计
	/// </summary>
	public class C5CXSpanStat: Base11X5Stat
	{
		protected override void Stat(string dbName,bool isReset)
		{
			string[] dmNames = DimensionNumberTypeBiz.Instance.GetEnabledDimensions("11X5");
			DwNumberBiz biz = new DwNumberBiz(dbName);
			List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty, "Seq", SortTypeEnum.ASC, null);

			this.StatC5CX(numbers, dbName,isReset);
		}

		private void StatC5CX(List<DwNumber> numbers, string dbName,bool isReset)
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
				if(isReset) spanBiz.DataAccessor.Truncate();
				
				long lastP = spanBiz.DataAccessor.SelectLatestPeroid(string.Empty);
				foreach (DwNumber number in numbers)
				{
					var cxNumbers = NumberCache.Instance.GetC5CXNumbers(number.C5, newNumberType);
					var c5cxSpanList = this.GetC5CXSpanList(lastSpanDict, cxNumbers, number, dmNames);
					if (number.P > lastP) c5cxSpans.AddRange(c5cxSpanList);
				}
				spanBiz.DataAccessor.Insert(c5cxSpans, SqlInsertMethod.SqlBulkCopy);
				
				Console.WriteLine("{0} {1} Finished", dbName, tableName);
			}

			Console.WriteLine("{0} {1} Finished", dbName, "ALL C5CX Span");
		}
		
		private List<DwC5CXSpan> GetC5CXSpanList(Dictionary<string,Dictionary<string, int>> lastSpanDict,
		                                         List<DmC5CX> cxNumbers, DwNumber number,string[] dmNames)
		{
			List<DwC5CXSpan> c5cxSpans = new List<DwC5CXSpan>(cxNumbers.Count);
			foreach (var cxNumber in cxNumbers)
			{
				DwC5CXSpan c5cxSpan = this.GetC5CXSpan(lastSpanDict, number, dmNames, cxNumber);
				c5cxSpans.Add(c5cxSpan);
			}

			return c5cxSpans;
		}

		private DwC5CXSpan GetC5CXSpan(Dictionary<string, Dictionary<string, int>> lastSpanDict,
		                               DwNumber number, string[] dmNames, DmC5CX cxNumber)
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
	}
}

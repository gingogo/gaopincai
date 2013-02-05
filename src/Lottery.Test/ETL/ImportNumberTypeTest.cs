using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Lottery.Test.ETL
{
	using Lottery.ETL;
	using Lottery.ETL.Common;
	using Lottery.Model.Common;
	using Lottery.Data.SQLServer.Common;
	
	/// <summary>
	/// Description of ImportNumberTypeTest.
	/// </summary>
	public class ImportNumberTypeTest
	{
		public ImportNumberTypeTest()
		{
		}
		
		[Test]
		public void Import11X5_C1()
		{
//			ImportNumberType.Import11x5();
//			var list = NumberTypeBiz.Instance.DataAccessor.SelectWithCondition("where ruletype='11X5' and code='A1'");
//			Assert.AreEqual(1,list.Count);
		}
	}
}

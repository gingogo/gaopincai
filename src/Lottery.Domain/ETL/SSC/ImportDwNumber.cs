using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL.SSC
{
    using Model.Common;
    using Model.SSC;
    using Lottery.Data.SQLServer.Common;
    using Lottery.Data.SQLServer.SSC;
    using Utils;

    public class ImportDwNumber
    {
        public static void UpdateC45()
        {
            List<Category> categories = CategoryBiz.Instance.GetEnabledCategories("SSC");
            foreach (Category category in categories)
            {
                DwNumberBiz biz = new DwNumberBiz(category.DbName);
                List<DwNumber> numbers = biz.DataAccessor.SelectWithCondition(string.Empty,
                    "Seq", Data.SortTypeEnum.ASC, null, "P", "P4", "P5");

                foreach (var number in numbers)
                {
                    string c4 = NumberCache.Instance.GetNumberId("C4", number.P4);
                    string c5 = NumberCache.Instance.GetNumberId("C5", number.P5);
                    string sql = string.Format("update {0} set {1} = '{2}',{3} = '{4}' where P = {5}",
                        DwNumber.ENTITYNAME, "C4", c4, "C5", c5, number.P);
                    Data.SqlHelper.ExecuteNonQuery(biz.DataAccessor.ConnectionString, System.Data.CommandType.Text, sql);
                }
            }
        }
    }
}

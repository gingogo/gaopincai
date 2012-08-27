using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lottery.ETL
{
    using Utils;
    using Configuration;
    using Data;

    public class ImportDate
    {
        public static void Start(DateTime start,DateTime end,string name)
        {
            string connstr = ConfigHelper.GetConnString(name);
            for (DateTime c = start; c <= end; c = c.AddDays(1))
            {
                int date = int.Parse(c.ToString("yyyyMMdd"));
                string sql = string.Format("insert into DmDate(date) values('{0}')",date);
                SqlHelper.ExecuteNonQuery(connstr,System.Data.CommandType.Text,sql);
            }
            Console.WriteLine("Finished!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Lite
{
    public class DataAccess
    {
        private string DBConn = null;
        public DataAccess(string Model)
        {
            if (Model != null)
                Model = "LotteryShanD115";
             DBConn = @"server=LOCALHOST\SQLEXPRESS;user id=sa; password=ddd;database="+Model+";Pooling=true";
        }



    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Lottery.Test
{
    using Data;
    using Data.SQLServer;
    using Model.Common;
    using Data.SQLServer.Common;
    using Configuration;
    
    public class TransactionScopeTest
    {
        public static void Test()
        {
            Console.WriteLine(Operation2());
        }

        private static int Operation2()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 10 == 0) return i;
            }
            return 0;
        }

        private static bool Operation1()
        {
            var biz = new CategoryDAO(ConfigHelper.GetConnString("test")); 
            try
            {
                TransactionOptions option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadUncommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {

                    Category cate = new Category();
                    cate.Code = "test3";
                    cate.DbName = "test3";

                    int id = biz.InsertWithId(cate);

                    cate.Code = "test4";//"TCPKData_NingX";
                    cate.DbName = "test4";
                    biz.Insert(cate);
                    scope.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}

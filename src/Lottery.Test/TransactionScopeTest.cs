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
        public static void Commit_Should_Success()
        {
            Console.WriteLine(Operation());
        }

        public static void Commit_Should_Failure()
        {
        }

        public static void Rollback_Should_Success()
        {
        }

        private static bool Operation()
        {
            var biz = new DmCategoryDAO(ConfigHelper.GetConnString("test")); 
            try
            {
                TransactionOptions option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadUncommitted;
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {

                    DmCategory cate = new DmCategory();
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

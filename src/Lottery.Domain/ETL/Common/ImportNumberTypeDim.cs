using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data.SQLServer.Common;
    using Utils;

    public class ImportNumberTypeDim
    {
        public static void Import()
        {
            Import11x5();
            ImportSSC();
        }

        public static void Import11x5()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x=>x.RuleType.Contains("11X5")).ToList();
            string[] d1dims = new string[]{"DaXiao", "DanShuang", "ZiHe", "Lu012"};
            string[] fp2dims = new string[] {"DaXiao", "DanShuang", "ZiHe", "Lu012", 
                "He", "HeWei", "Ji", "JiWei", "KuaDu"
            };
            string[] alldims = new string[] {"DaXiao", "DanShuang", "ZiHe", "Lu012", 
                "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" 
            };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.D11X5.DmFCAnBiz biz = new Data.SQLServer.D11X5.DmFCAnBiz("jiangx11x5",numberType.Code);
                double count = (double)biz.DataAccessor.Count();

                List<NumberTypeDim> ntds = new List<NumberTypeDim>();
                if (numberType.Code.Equals("D1"))
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(d1dims);
                else if("F2,C2".Contains(numberType.Code))
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(fp2dims); 
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(alldims);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = ((double)ntd.Nums) / count;
                }
                NumberTypeDimBiz.Instance.DataAccessor.Insert(ntds, Data.SQLServer.SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void ImportSSC()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("SSC")).ToList();
            string[] d1dims = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] fp2dims = new string[] {"DaXiao", "DanShuang", "ZiHe", "Lu012", 
                "He", "HeWei", "Ji", "JiWei", "KuaDu"
            };
            string[] alldims = new string[] {"DaXiao", "DanShuang", "ZiHe", "Lu012", 
                "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" 
            };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.D11X5.DmFCAnBiz biz = new Data.SQLServer.D11X5.DmFCAnBiz("jiangxssc", numberType.Code);
                double count = 220.0;
                if (!numberType.Code.Equals("C33") && !numberType.Code.Equals("C36"))
                {
                    count = (double)biz.DataAccessor.Count();
                }

                List<NumberTypeDim> ntds = new List<NumberTypeDim>();
                if (numberType.Code.Equals("D1"))
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(d1dims);
                else if ("P2,C2".Contains(numberType.Code))
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(fp2dims);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(alldims);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = ((double)ntd.Nums) / count;
                }
                NumberTypeDimBiz.Instance.DataAccessor.Insert(ntds, Data.SQLServer.SqlInsertMethod.SqlBulkCopy);
            }
        }
    }
}

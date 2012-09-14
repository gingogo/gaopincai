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
                double count = biz.DataAccessor.Count() * 1.0;

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
                    ntd.Probability = (ntd.Nums * 1.0) / count;
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
                double count = biz.DataAccessor.Count() * 1.0;

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
                    ntd.Probability = GetProbability(ntd.Nums, count, ntd.NumberType);
                }
                NumberTypeDimBiz.Instance.DataAccessor.Insert(ntds, Data.SQLServer.SqlInsertMethod.SqlBulkCopy);
            }
        }

        private static double GetProbability(int nums, double count,string numberType)
        {
            if (numberType.Equals("C33"))
                return nums * (3.0 / 1000.0);
            if (numberType.Equals("C36"))
                return nums * (6.0 / 1000.0);
            return (nums * 1.0) / count;
        }
    }
}

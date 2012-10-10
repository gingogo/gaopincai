using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data.SQLServer;
    using Data.SQLServer.Common;
    using Utils;

    public class ImportNumberTypeDim
    {
        public static void Import()
        {
            //DimensionNumberTypeBiz.Instance.DataAccessor.Truncate();

            //Import11x5();
            //ImportSSC();
            //Import3D();
            //ImportPL35();
            //ImportSSL();
            //Import12X3();
        }

        public static void Import11x5()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("11X5")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.D11X5.DmDPCBiz biz = new Data.SQLServer.D11X5.DmDPCBiz("jiangx11x5", numberType.Code.GetDmTableSuffix());
       
                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void ImportSSC()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("SSC")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.SSC.DmDPCBiz biz = new Data.SQLServer.SSC.DmDPCBiz("jiangxssc", numberType.Code.GetDmTableSuffix());

                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void Import3D()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("3D")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.D3.DmDPCBiz biz = new Data.SQLServer.D3.DmDPCBiz("fc3d", numberType.Code.GetDmTableSuffix());
   
                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void ImportPL35()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("PL35")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.PL35.DmDPCBiz biz = new Data.SQLServer.PL35.DmDPCBiz("tcpl35", numberType.Code.GetDmTableSuffix());

                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void ImportSSL()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("SSL")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.SSL.DmDPCBiz biz = new Data.SQLServer.SSL.DmDPCBiz("shanghssl", numberType.Code.GetDmTableSuffix());

                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void Import12X3()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("12X3")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };

            foreach (var numberType in numberTypes)
            {
                Data.SQLServer.D12X3.DmDPCBiz biz = new Data.SQLServer.D12X3.DmDPCBiz("hun12x3", numberType.Code.GetDmTableSuffix());

                List<DimensionNumberType> ntds = new List<DimensionNumberType>();
                if (numberType.Length == 1)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number1, numberType.Code);
                else if (numberType.Length == 2)
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number2, numberType.Code);
                else
                    ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(number3, numberType.Code);

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = ntd.Nums * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) * numberType.Probability;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }
    }
}

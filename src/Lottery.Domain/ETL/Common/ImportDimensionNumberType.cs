using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.ETL.Common
{
    using Model.Common;
    using Data;
    using Data.Biz.Common;
    using Utils;

    public class ImportNumberTypeDim
    {
        public static void Import()
        {
            //DimensionNumberTypeBiz.Instance.DataAccessor.Truncate();
            //ImportSSC();
            //Import3D();
            //ImportPL35();
            //ImportSSL();
            //Import12X3();
            //Import11x5();
            //Import11x5C5CX();
        }

        public static void Import11x5C5CX()
        {
            var numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("11X5")).Where(y => y.Code.StartsWith("A"));
            string[] dmType1 = new string[] { "He" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.D11X5.DmC5CXBiz biz = new Data.Biz.D11X5.DmC5CXBiz("jiangx11x5");
                List<DimensionNumberType> ntds = ntds = biz.DataAccessor.SelectNumberTypeDimGroupBy(dmType1, numberType.Code.Replace("A", "C"));
                int nums = ntds[0].Nums;

                foreach (var ntd in ntds)
                {
                    ntd.NumberType = numberType.Code;
                    ntd.RuleType = numberType.RuleType;
                    ntd.Amount = (ntd.Nums / nums) * numberType.Amount;
                    ntd.Probability = (ntd.Nums * 1.0) / 462.00;
                    ntd.Nums = ntd.Nums / nums;
                }
                DimensionNumberTypeBiz.Instance.DataAccessor.Insert(ntds, SqlInsertMethod.SqlBulkCopy);
            }
        }

        public static void Import11x5()
        {
            List<NumberType> numberTypes = NumberTypeBiz.Instance.GetAll().Where(x => x.RuleType.Contains("11X5")).ToList();
            string[] number1 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012" };
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                if (numberType.Code.StartsWith("A")) continue;

                Data.Biz.D11X5.DmDPCBiz biz = new Data.Biz.D11X5.DmDPCBiz("jiangx11x5", numberType.Code.GetDmTableSuffix());
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
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.SSC.DmDPCBiz biz = new Data.Biz.SSC.DmDPCBiz("jiangxssc", numberType.Code.GetDmTableSuffix());

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
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.D3.DmDPCBiz biz = new Data.Biz.D3.DmDPCBiz("fc3d", numberType.Code.GetDmTableSuffix());
   
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
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.PL35.DmDPCBiz biz = new Data.Biz.PL35.DmDPCBiz("tcpl35", numberType.Code.GetDmTableSuffix());

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
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.SSL.DmDPCBiz biz = new Data.Biz.SSL.DmDPCBiz("shanghssl", numberType.Code.GetDmTableSuffix());

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
            string[] number2 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };
            string[] number3 = new string[] { "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC", "DaXiaoBi", "ZiHeBi", "DanShuangBi", "Lu012Bi" };

            foreach (var numberType in numberTypes)
            {
                Data.Biz.D12X3.DmDPCBiz biz = new Data.Biz.D12X3.DmDPCBiz("hun12x3", numberType.Code.GetDmTableSuffix());

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

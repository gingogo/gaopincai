using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lottery.Data.Biz.D11X5
{
    using Configuration;
    using Data.D11X5;
    using Model.D11X5;
    using Utils;

    public class NumberCache
    {
        public static readonly NumberCache Instance = new NumberCache();

        private Dictionary<string, Dictionary<string, DmDPC>> caching = new Dictionary<string, Dictionary<string, DmDPC>>(1500);
        private Dictionary<string, Dictionary<string, List<DmC5CX>>> c5cxCaching = new Dictionary<string, Dictionary<string, List<DmC5CX>>>(462);
  
        protected NumberCache()
        {
            this.LoadData();
            this.LoadC5CXData();
        }

        public string GetNumberId(string numberType,string number)
        {
            if (!this.caching.ContainsKey(numberType))
                throw new ArgumentException("NumberType Not Found", "numberType");

            string numberId = this.GetId(number, this.caching[numberType]);
            if(string.IsNullOrEmpty(numberId))
                throw new ApplicationException("NumberId Not Found");

            return numberId;
        }

        public List<string> GetNumbers(string numberType)
        {
            string dmTableNameSuffix = numberType.GetDmTableSuffix();
            DmDPCBiz Biz = new DmDPCBiz(ConfigHelper.D11x5DmTableConnStringName, dmTableNameSuffix);
            return Biz.GetAll("Id").Select(x => x.Id).ToList();
        }

        public List<DmDPC> GetNumberList(string numberType)
        {
            string dmTableNameSuffix = numberType.GetDmTableSuffix();
            DmDPCBiz Biz = new DmDPCBiz(ConfigHelper.D11x5DmTableConnStringName, dmTableNameSuffix);
            return Biz.GetAll("Id", "Number");
        }

        public List<DmC5CX> GetC5CXNumbers(string c5, string numberType)
        {
            return this.c5cxCaching[c5][numberType];
        }

        private void LoadData()
        {
            this.caching.Clear();

            string[] numberTypes = new string[] { "C2", "C3", "C4", "C5", "C6", "C7", "C8" };      
            DmDPCBiz Biz = new DmDPCBiz(ConfigHelper.D11x5DmTableConnStringName, string.Empty);
            foreach (var numberType in numberTypes)
            {
                Biz.DataAccessor.TableName = ConfigHelper.GetDmTableName(numberType.GetDmTableSuffix());
                List<DmDPC> list = Biz.GetAll("Id", "Number");
                this.FillToDictionary(numberType, list);
            }
        }

        private void LoadC5CXData()
        {
            this.c5cxCaching.Clear();

            DmC5CXBiz dmC5CXBiz = new DmC5CXBiz(ConfigHelper.D11x5DmTableConnStringName);
            List<DmC5CX> c5cxNumbers = dmC5CXBiz.GetAll(DmC5CX.C_C5, DmC5CX.C_CX, DmC5CX.C_NumberType);
            foreach (var c5cxNumber in c5cxNumbers)
            {
                if (!c5cxCaching.ContainsKey(c5cxNumber.C5))
                {
                    List<DmC5CX> subNumbers = new List<DmC5CX>(20);
                    subNumbers.Add(c5cxNumber);
                    Dictionary<string, List<DmC5CX>> numberTypeNumbers = new Dictionary<string, List<DmC5CX>>(6);
                    numberTypeNumbers.Add(c5cxNumber.NumberType, subNumbers);
                    c5cxCaching.Add(c5cxNumber.C5, numberTypeNumbers);
                    continue;
                }

                if (!c5cxCaching[c5cxNumber.C5].ContainsKey(c5cxNumber.NumberType))
                {
                    List<DmC5CX> subNumbers = new List<DmC5CX>(20);
                    subNumbers.Add(c5cxNumber);
                    c5cxCaching[c5cxNumber.C5].Add(c5cxNumber.NumberType, subNumbers);
                    continue;
                }
                c5cxCaching[c5cxNumber.C5][c5cxNumber.NumberType].Add(c5cxNumber);
            }
        }

        private void FillToDictionary(string numberType, List<DmDPC> list)
        {
            if (!this.caching.ContainsKey(numberType))
            {
                Dictionary<string, DmDPC> dict = new Dictionary<string, DmDPC>(list.Count);
                this.caching.Add(numberType, dict);
            }
            else
            {
                this.caching[numberType].Clear();
            }

            foreach (var e in list)
            {
                this.caching[numberType].Add(e.Id.Trim(), e);
            }
        }

        private string GetId(string number, Dictionary<string, DmDPC> dict)
        {
            string id = string.Empty;
            string[] digits = number.Trim().Split(',').Select(x => x.Trim()).ToArray();

            foreach (var kp in dict)
            {
                var arr = kp.Value.Number.Split(' ').Select(x => x.Trim());
                if (digits.Except(arr).Count() != 0) continue;
                if (arr.Except(digits).Count() != 0) continue;
                id = kp.Key;
                break;
            }

            return id;
        }

        private List<string> GetIds(string number, Dictionary<string, DmDPC> dict)
        {
            List<string> ids = new List<string>(200);
            string[] digits = number.Trim().Split(',').Select(x => x.Trim()).ToArray();

            foreach (var kp in dict)
            {
                var arr = kp.Value.Number.Split(' ').Select(x => x.Trim());
                if (digits.Except(arr).Count() != 0) continue;
                ids.Add(kp.Key);
            }

            return ids;
        }
    }
}

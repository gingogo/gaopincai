using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    public class NumberCache
    {
        public static readonly NumberCache Instance = new NumberCache();

        private Dictionary<string, Dictionary<string, DmDPC>> caching = new Dictionary<string, Dictionary<string, DmDPC>>(1500);
  
        protected NumberCache()
        {
            this.LoadData();
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

        private void LoadData()
        {
            string[] numberTypes = new string[] { "C2", "C3", "C4", "C5" };
            
            DmDPCBiz biz = new DmDPCBiz(ConfigHelper.D11x5DmTableConnStringName, string.Empty);
            foreach (var numberType in numberTypes)
            {
                biz.DataAccessor.TableName = ConfigHelper.GetDmTableName(numberType.GetDmTableSuffix());
                List<DmDPC> list = biz.GetAll("Id", "Number");
                this.FillToDictionary(numberType, list);
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

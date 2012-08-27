using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lottery.Data.SQLServer.D11X5
{
    using Model.D11X5;
    using Utils;
    using Configuration;

    public class NumberBiz
    {
        public static readonly NumberBiz Instance = new NumberBiz();

        private Dictionary<string, DmFCAn> _d1Dict = new Dictionary<string, DmFCAn>(11);
        private Dictionary<string, DmFCAn> _f2Dict = new Dictionary<string, DmFCAn>(110);
        private Dictionary<string, DmFCAn> _f3Dict = new Dictionary<string, DmFCAn>(990);
        private Dictionary<string, DmFCAn> _c2Dict = new Dictionary<string, DmFCAn>(55);
        private Dictionary<string, DmFCAn> _c3Dict = new Dictionary<string, DmFCAn>(165);
        private Dictionary<string, DmFCAn> _a4Dict = new Dictionary<string, DmFCAn>(330);
        private Dictionary<string, DmFCAn> _a5Dict = new Dictionary<string, DmFCAn>(462);
        private Dictionary<string, DmFCAn> _a6Dict = new Dictionary<string, DmFCAn>(462);
        private Dictionary<string, DmFCAn> _a7Dict = new Dictionary<string, DmFCAn>(330);
        private Dictionary<string, DmFCAn> _a8Dict = new Dictionary<string, DmFCAn>(165);
  
        protected NumberBiz()
        {
            this.LoadData();
        }

        public Dictionary<string, DmFCAn> D1
        {
            get { return this._d1Dict; }
        }

        public Dictionary<string, DmFCAn> F2
        {
            get { return this._f2Dict; }
        }

        public Dictionary<string, DmFCAn> F3
        {
            get { return this._f3Dict; }
        }

        public Dictionary<string, DmFCAn> C2
        {
            get { return this._c2Dict; }
        }

        public Dictionary<string, DmFCAn> C3
        {
            get { return this._c3Dict; }
        }

        public Dictionary<string, DmFCAn> A4
        {
            get { return this._a4Dict; }
        }

        public Dictionary<string, DmFCAn> A5
        {
            get { return this._a5Dict; }
        }

        public Dictionary<string, DmFCAn> A6
        {
            get { return this._a6Dict; }
        }

        public Dictionary<string, DmFCAn> A7
        {
            get { return this._a7Dict; }
        }

        public Dictionary<string, DmFCAn> A8
        {
            get { return this._a8Dict; }
        }

        public Dictionary<string, DmFCAn> GetNumberIds(string name)
        {
            if (name.Trim().ToLower().Equals("f2"))
                return this._f2Dict;
            if (name.Trim().ToLower().Equals("c2"))
                return this._c2Dict;
            if (name.Trim().ToLower().Equals("f3"))
                return this._f3Dict;
            if (name.Trim().ToLower().Equals("c3"))
                return this._c3Dict;
            if (name.Trim().ToLower().Equals("a4"))
                return this._a4Dict;
            if (name.Trim().ToLower().Equals("a5"))
                return this._a5Dict;
            if (name.Trim().ToLower().Equals("a6"))
                return this._a6Dict;
            if (name.Trim().ToLower().Equals("a7"))
                return this._a7Dict;
            if (name.Trim().ToLower().Equals("a8"))
                return this._a8Dict;
            if (name.Trim().ToLower().Equals("d1"))
                return this._d1Dict;

            return new Dictionary<string, DmFCAn>();
        }

        public string GetC2Id(string number)
        {
            return this.GetId(number, this._c2Dict);
        }

        public string GetC3Id(string number)
        {
            return this.GetId(number, this._c3Dict);
        }

        public string GetA5Id(string number)
        {
            return this.GetId(number, this._a5Dict);
        }

        private void LoadData()
        {
            DmFCAnBiz biz = new DmFCAnBiz(ConfigHelper.D11x5DmTableConnStringName, "C2");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c2Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("C3");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c3Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("A5");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._a5Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("F2");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._f2Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("F3");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._f3Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("D1");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._d1Dict);

            //biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("A4");
            //this.FillToDictionary(biz.GetAll("Id", "Number"), this._a4Dict);

            //biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("A6");
            //this.FillToDictionary(biz.GetAll("Id", "Number"), this._a6Dict);

            //biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("A7");
            //this.FillToDictionary(biz.GetAll("Id", "Number"), this._a7Dict);

            //biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("A8");
            //this.FillToDictionary(biz.GetAll("Id", "Number"), this._a8Dict);
        }

        private void FillToDictionary(List<DmFCAn> list,Dictionary<string,DmFCAn> dict)
        {
            foreach (var e in list)
            {
                dict.Add(e.Id.Trim(), e);
            }
        }

        private string GetId(string number, Dictionary<string, DmFCAn> dict)
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

        private List<string> GetIds(string number, Dictionary<string, DmFCAn> dict)
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

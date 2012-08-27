using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lottery.Data.SQLServer.SSC
{
    using Model.SSC;
    using Utils;
    using Configuration;

    public class NumberBiz
    {
        public static readonly NumberBiz Instance = new NumberBiz();

        private Dictionary<string, DmFCAn> _d1Dict = new Dictionary<string, DmFCAn>(10);
        private Dictionary<string, DmFCAn> _p2Dict = new Dictionary<string, DmFCAn>(100);
        private Dictionary<string, DmFCAn> _p3Dict = new Dictionary<string, DmFCAn>(1000);
        private Dictionary<string, DmFCAn> _c2Dict = new Dictionary<string, DmFCAn>(55);
        private Dictionary<string, DmFCAn> _c3Dict = new Dictionary<string, DmFCAn>(220);
        private Dictionary<string, DmFCAn> _p4Dict = new Dictionary<string, DmFCAn>(10000);
        private Dictionary<string, DmFCAn> _p5Dict = new Dictionary<string, DmFCAn>(100000);
        private Dictionary<string, DmFCAn> _c33Dict = new Dictionary<string, DmFCAn>(90);
        private Dictionary<string, DmFCAn> _c36Dict = new Dictionary<string, DmFCAn>(120);
  
        protected NumberBiz()
        {
            this.LoadData();
        }

        public Dictionary<string, DmFCAn> D1
        {
            get { return this._d1Dict; }
        }

        public Dictionary<string, DmFCAn> P2
        {
            get { return this._p2Dict; }
        }

        public Dictionary<string, DmFCAn> P3
        {
            get { return this._p3Dict; }
        }

        public Dictionary<string, DmFCAn> C2
        {
            get { return this._c2Dict; }
        }

        public Dictionary<string, DmFCAn> C3
        {
            get { return this._c3Dict; }
        }

        public Dictionary<string, DmFCAn> P4
        {
            get { return this._p4Dict; }
        }

        public Dictionary<string, DmFCAn> P5
        {
            get { return this._p5Dict; }
        }

        public Dictionary<string, DmFCAn> C33
        {
            get { return this._c33Dict; }
        }

        public Dictionary<string, DmFCAn> C36
        {
            get { return this._c36Dict; }
        }

        public Dictionary<string, DmFCAn> GetNumberIds(string name)
        {
            if (name.Trim().ToLower().Equals("p2"))
                return this._p2Dict;
            if (name.Trim().ToLower().Equals("c2"))
                return this._c2Dict;
            if (name.Trim().ToLower().Equals("p3"))
                return this._p3Dict;
            if (name.Trim().ToLower().Equals("c3"))
                return this._c3Dict;
            if (name.Trim().ToLower().Equals("p4"))
            {
                if (this._p4Dict.Count > 0) return this._p4Dict;
                DmFCAnBiz biz = new DmFCAnBiz(ConfigHelper.SSCDmTableConnStringName, name);
                this.FillToDictionary(biz.GetAll("Id", "Number"), this._p4Dict);
                return this._p4Dict;
            }
            if (name.Trim().ToLower().Equals("p5"))
            {
                if (this._p5Dict.Count > 0) return this._p5Dict;
                DmFCAnBiz biz = new DmFCAnBiz(ConfigHelper.SSCDmTableConnStringName, name);
                this.FillToDictionary(biz.GetAll("Id", "Number"), this._p5Dict);
                return this._p5Dict;
            }
            if (name.Trim().ToLower().Equals("c33"))
                return this._c33Dict;
            if (name.Trim().ToLower().Equals("c36"))
                return this._c36Dict;
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

        public string GetC33Id(string number)
        {
            var digits = number.Trim().ToArray();
            if (digits.Distinct().Count() != 2) return string.Empty;

            return this.GetId(number, this._c33Dict);
        }

        public string GetC36Id(string number)
        {
            var digits = number.Trim().ToArray();
            if (digits.Distinct().Count() != 3) return string.Empty;

            return this.GetId(number, this._c36Dict);
        }

        private void LoadData()
        {
            DmFCAnBiz biz = new DmFCAnBiz(ConfigHelper.SSCDmTableConnStringName, "C2");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c2Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("D1");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._d1Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("P2");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._p2Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("P3");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._p3Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("C3");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c3Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("C33");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c33Dict);

            biz.DataAccessor.TableName = ConfigHelper.GetDmTableName("C36");
            this.FillToDictionary(biz.GetAll("Id", "Number"), this._c36Dict);
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
            string numberId = string.Empty;
            var digits = number.Trim().ToArray();
            Permutations<char> perm = new Permutations<char>(digits, number.Trim().Length);
            List<string> arranges = perm.Get("");

            foreach (var arrange in arranges)
            {
                if (!dict.ContainsKey(arrange)) continue;
                numberId = arrange;
                break;
            }

            return numberId;
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

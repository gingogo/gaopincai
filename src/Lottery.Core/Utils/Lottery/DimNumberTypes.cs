using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Utils
{
    public class DimNumberTypes
    {
        private static Dictionary<string, Dictionary<string, string[]>> dict = new Dictionary<string, Dictionary<string, string[]>>(5);

        static DimNumberTypes()
        {
            LoadData();
        }

        /// <summary>
        /// 根据维度类型获与维度名称获取所有玩法数字类型集合。
        /// </summary>
        /// <param name="dimType">维度类型取值为:D3|D5</param>
        /// <param name="name">维度名称(区分大小写,取值为:Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC)</param>
        /// <returns>玩法数字类型集合</returns>
        public static string[] GetNumberTypes(string dimType, string name)
        {
            if (dict.ContainsKey(dimType) &&
                dict[dimType].ContainsKey(name)) return dict[dimType][name];

            throw new ArgumentException("Not found this dimType and name");
        }

        /// <summary>
        /// 根据维度类型获取所有维度名称集合(Peroid,DaXiao,DanShuang,ZiHe,Lu012,He,HeWei,Ji,JiWei,KuaDu,AC);
        /// </summary>
        /// <param name="dimType">维度类型取值为:D3|D5</param>
        /// <returns>维度名称集合</returns>
        public static string[] GetDimensions(string dimType)
        {
            if (dict.ContainsKey(dimType)) 
                return dict[dimType].Keys.ToArray();

            throw new ArgumentException("Not found this dimType");
        }

        private static void LoadData()
        {
            if (dict.Count > 0) dict.Clear();

            string[] d3NumberTypes1 = new string[] { "D1", "D2", "D3", "P2", "C2", "P3", "C3" };
            string[] d3NumberTypes2 = new string[] { "P2", "C2", "P3", "C3" };
            string[] d3NumberTypes3 = new string[] { "P3", "C3" };

            string[] d5NumberTypes1 = new string[] { "D1", "D2", "D3", "D4", "D5", "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };
            string[] d5NumberTypes2 = new string[] { "P2", "C2", "P3", "C3", "P4", "C4", "P5", "C5" };
            string[] d5NumberTypes3 = new string[] { "P3", "C3", "P4", "C4", "P5", "C5" };

            string[] dmNames = new string[] { "Peroid", "DaXiao", "DanShuang", "ZiHe", "Lu012", "He", "HeWei", "Ji", "JiWei", "KuaDu", "AC" };
            Dictionary<string, string[]> d3DimNumberTypes = new Dictionary<string, string[]>(11);
            d3DimNumberTypes.Add("Peroid", d3NumberTypes1);
            d3DimNumberTypes.Add("DaXiao", d3NumberTypes1);
            d3DimNumberTypes.Add("DanShuang", d3NumberTypes1);
            d3DimNumberTypes.Add("ZiHe", d3NumberTypes1);
            d3DimNumberTypes.Add("Lu012", d3NumberTypes1);
            d3DimNumberTypes.Add("He", d3NumberTypes2);
            d3DimNumberTypes.Add("HeWei", d3NumberTypes2);
            d3DimNumberTypes.Add("Ji", d3NumberTypes2);
            d3DimNumberTypes.Add("JiWei", d3NumberTypes2);
            d3DimNumberTypes.Add("KuaDu", d3NumberTypes2);
            d3DimNumberTypes.Add("AC", d3NumberTypes3);

            Dictionary<string, string[]> d5DimNumberTypes = new Dictionary<string, string[]>(11);
            d5DimNumberTypes.Add("Peroid", d5NumberTypes1);
            d5DimNumberTypes.Add("DaXiao", d5NumberTypes1);
            d5DimNumberTypes.Add("DanShuang", d5NumberTypes1);
            d5DimNumberTypes.Add("ZiHe", d5NumberTypes1);
            d5DimNumberTypes.Add("Lu012", d5NumberTypes1);
            d5DimNumberTypes.Add("He", d5NumberTypes2);
            d5DimNumberTypes.Add("HeWei", d5NumberTypes2);
            d5DimNumberTypes.Add("Ji", d5NumberTypes2);
            d5DimNumberTypes.Add("JiWei", d5NumberTypes2);
            d5DimNumberTypes.Add("KuaDu", d5NumberTypes2);
            d5DimNumberTypes.Add("AC", d5NumberTypes3);

            dict.Add("D3", d3DimNumberTypes);
            dict.Add("D5", d5DimNumberTypes);
        }
    }
}

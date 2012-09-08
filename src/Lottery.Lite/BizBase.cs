using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.IO;

namespace Lottery.Lite
{
	public static class BizBase
    {

        public static List<string> getAllNumbers()
        {
            List<string> numbers = new List<string>();
            for(int i=0;i<11;i++){
                for (int j = 0; i < 11; j++)
                {
                    if (i != j)
                    {
                        string number = "";
                        number = (i.ToString().Length == 2 ? i.ToString() : ("0" + i.ToString())) + (j.ToString().Length == 2 ? j.ToString() : ("0" + j.ToString()));
                        numbers.Add(number);
                    }
                }
            }
            return numbers;
        }

        /// <summary>
        /// 通过日期计算对应的期数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int getPeriodByDate(DateTime dt, CaiConfigData CaiData)
        {
            if (dt.Hour < CaiData.TimeBeginHour)
                return 0;
            else if (dt.Hour >= CaiData.TimeEndHour)
                return CaiData.PeriodPerDay;
            else
                return (dt.Hour - CaiData.TimeBeginHour) * 5 + (dt.Minute % CaiData.TimePerPeriod);
        }


        /// <summary>
        /// 获取当前时间的date格式
        /// </summary>
        /// <returns></returns>
        public static string getDateNow()
        {
            return DateTime.Now.ToString("yyyyMMdd");
        }


        /// <summary>
        /// 通过日期计算对应的P
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string getPByDate(DateTime dt, CaiConfigData CaiData)
        {
            string p = dt.ToString("yyyyMMdd");
            if (dt.Hour < CaiData.TimeBeginHour)
                return p+"01";
            else if (dt.Hour >= CaiData.TimeEndHour)
                return p + CaiData.PeriodPerDay.ToString();
            else
                return p+((dt.Hour - CaiData.TimeBeginHour) * (60/CaiData.TimePerPeriod) + (dt.Minute % CaiData.TimePerPeriod)).ToString();
        }

        /// <summary>
        /// 计算与当前时间的间隔
        /// </summary>
        /// <param name="p"></param>
        /// <param name="CaiData"></param>
        /// <returns></returns>
        public static int getSpanTillNow(string p,CaiConfigData CaiData)
        {
        	if(p==null)
        		return 0;
            DateTime now = CaiData.NowCaculate;
            string lastDate = p.Substring(0, 8);
            int term = Convert.ToInt32(p.Substring(8, 2));
            DateTime dt = Convert.ToDateTime(lastDate.Substring(0, 4) + "-" + lastDate.Substring(4, 2) + "-" + lastDate.Substring(6, 2));
            int dtSplit = ((now - dt).Days) * CaiData.PeriodPerDay;
            int nowSpan = dtSplit + BizBase.getPeriodByDate(now,CaiData) - term;
            return nowSpan;
        }


        public static string ListToString(List<int> ints)
        {
            return ListToString(ints, false);
        }

        public static string ListToString(List<int> ints, bool distinct)
        {
            string re = "";
            if (distinct)
                ints = ints.Distinct().ToList();
            foreach (int i in ints)
            {
                re += i.ToString() + ",";
            }
            if (re != "")
            {
                re.Substring(0, re.Length - 1);
            }
            return re;
        }
        
         public static void XMLSerialize(List<NumSpanData> spans,CaiConfigData CaiData,string TaskType)
	    {
        	string path = CaiData.AppPath + @"\Cache\"+CaiData.CaiType+"_"+TaskType+"_"+CaiData.NowCaculate.ToString("yyyyMMdd")+".xml";
        	XMLSerialize(spans,path);
	    }
         
          public static void XMLSerialize(List<NumSpanData> spans,CaiConfigData CaiData)
	    {
        	string path = CaiData.AppPath + @"\Cache\"+CaiData.CaiType+"_"+CaiData.TaskType+"_"+CaiData.NowCaculate.ToString("yyyyMMdd")+".xml";
	        XMLSerialize(spans,path);
	    }
        
        
        public static void XMLSerialize(List<NumSpanData> spans,string path)
	    {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
                fi.Delete();
	        XmlSerializer xs = new XmlSerializer(typeof(List<NumSpanData>));
	        Stream stream = new FileStream(path,FileMode.OpenOrCreate,FileAccess.Write,FileShare.Read);
	        xs.Serialize(stream,spans);
	        stream.Close();
	    }
        
        public static List<NumSpanData> XMLDeserialize(CaiConfigData CaiData,string TaskType){
        	string path = CaiData.AppPath + @"\Cache\"+CaiData.CaiType+"_"+TaskType+"_"+CaiData.NowCaculate.ToString("yyyyMMdd")+".xml";
	    	return XMLDeserialize(path);
        }
        

	    public static List<NumSpanData> XMLDeserialize(CaiConfigData CaiData)
	    {
	    	string path = CaiData.AppPath + @"\Cache\"+CaiData.CaiType+"_"+CaiData.TaskType+"_"+CaiData.NowCaculate.ToString("yyyyMMdd")+".xml";
	    	return XMLDeserialize(path);
	       
	    }
	    
	    public static List<NumSpanData> XMLDeserialize(string path){
	    	FileInfo fi  = new FileInfo(path);
	    	if(fi.Exists){
		        XmlSerializer xs = new XmlSerializer(typeof(List<NumSpanData>));
		        Stream stream = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.Read);
		        List<NumSpanData> spans = (List<NumSpanData>)xs.Deserialize(stream);
		        stream.Close();
		        return spans;
	    	}else{
	    		return null;
	    	}
	    }

    }
}

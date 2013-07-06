using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL
{
	using Model.Common;
	using Data.Biz.Common;
	using Logging;

	public class ExtractData
	{
		private static Dictionary<int, int> pdic = new Dictionary<int, int>(10000);
		private static HashSet<long> pset = new HashSet<long>();

		public static void ExtractAll()
		{
			List<Category> categories = CategoryBiz.Instance.GetCategories();
			foreach (var category in categories)
			{
				if (category.ParentId == 0) continue;
				Extract(category);
			}
		}

		public static void Extract(int categoryId)
		{
			var categories = CategoryBiz.Instance.GetCategories().Where(x => x.Id == categoryId);
			foreach (var category in categories)
			{
				if (category.ParentId == 0) continue;
				Extract(category);
			}
		}

		public static void Extract(Category category)
		{
			pset.Clear();
			pdic.Clear();
			
			string downPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "KaiJiang", category.Name);

			for (int i = category.DownPageCount; i >= 1; i--)
			{
				string htmlFileName = string.Format(@"{0}\{1}.html", downPath, i);
				if (!File.Exists(htmlFileName))
					Logger.Instance.Write(string.Format("{0}-{1}.html-not exist", category.Name, i));
				StreamReader sr = new StreamReader(htmlFileName, Encoding.UTF8);
				string text = sr.ReadToEnd();
				sr.Close();

				var action = CreateAction(category.Type);
				if (action == null) continue;

				Extract(text,category.Name,category.DbName, action);
			}

			Console.WriteLine("{0}:Extract Data Finished!", category.Name);
		}

		private static Action<string, string, string, string, string> CreateAction(string type)
		{
			if (type.Equals("11X5")) return new Action<string, string, string, string,string>(Extract11X5);
			if (type.Equals("SSC")) return new Action<string, string, string, string, string>(ExtractSSC);
			if (type.Equals("3D")) return new Action<string, string, string, string, string>(Extract3D);
			if (type.Equals("PL35")) return new Action<string, string, string, string, string>(ExtractPL35);
			if (type.Equals("SSL")) return new Action<string, string, string, string, string>(ExtractSSL);
			if (type.Equals("12X3")) return new Action<string, string, string, string, string>(Extract12X3);

			return null;
		}

		private static void Extract(string text,string name, string dbName,
		                            Action<string, string, string, string, string> action)
		{
			//text.replace(/&amp;/g, '&').replace(/&quot;/g, '\"').replace(/&lt;/g, '<').replace(/&gt;/g, '>');
			text = text.Replace("&amp;", "&").Replace("&quot;", "\"").Replace("&lt;", "<").Replace("&gt;", ">");
			string pattern = "<tr style='background-color: White; border-color: #B6CBE8;'>.*?</tr>";
			MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
			for (int i = matches.Count - 1; i >= 0; i--)
			{
				Match m = matches[i];
				string sdate = Regex.Match(m.Value, "<td align='center' style='width: 20%;'>(.*?)</td>",
				                           RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
				string speroid = Regex.Match(m.Value, "<td style='width: 20%;'>(.*?)</td>",
				                             RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
				string code = Regex.Match(m.Value, "'MyGridView_ctl02_lblHao'>(.*?)</(spans|span)>",
				                          RegexOptions.IgnoreCase | RegexOptions.Singleline).Groups[1].Value.Trim();
				if (code.Trim().Length == 0) continue;

				action(name, sdate, speroid, code, dbName);
			}
		}

		private static void ExtractSSC(string name, string sdate, string speroid, string code, string dbName)
		{
			char[] numbers = code.ToArray();
			string no = string.Join(",", numbers);
			string p2 = code.Substring(3);
			string p3 = code.Substring(2);
			string p4 = code.Substring(1);
			string p5 = code;

			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			long p = 20000000000 + int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 3));

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.SSC.DwNumberBiz biz = new Data.Biz.SSC.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));
		}

		private static void Extract11X5(string name, string sdate, string speroid, string code, string dbName)
		{
			string no = code.Replace(" ", ",");
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			int p = 2000000000 + int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 2));

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.D11X5.DwNumberBiz biz = new Data.Biz.D11X5.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));

			//if (name.Equals("山东十一运夺金") &&
			//    dateint < 20090909)
			//{
			//    if (pdic.ContainsKey(dateint))
			//        pdic[dateint]++;
			//    else
			//        pdic.Add(dateint, 1);
			//    n = pdic[dateint];
			//    p = dateint * 100 + n;
			//}
		}

		private static void Extract3D(string name, string sdate, string speroid, string code,string dbName)
		{
			char[] numbers = code.ToArray();
			string no = string.Join(",", numbers);
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			long p = int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 3));

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.D3.DwNumberBiz biz = new Data.Biz.D3.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));
		}

		private static void ExtractPL35(string name, string sdate, string speroid, string code, string dbName)
		{
			char[] numbers = code.ToArray();
			string no = string.Join(",", numbers);
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			long p = int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 3));

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.PL35.DwNumberBiz biz = new Data.Biz.PL35.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));
		}

		private static void ExtractSSL(string name, string sdate, string speroid, string code, string dbName)
		{
			char[] numbers = code.ToArray();
			string no = string.Join(",", numbers);
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			long p = int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 2));

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.SSL.DwNumberBiz biz = new Data.Biz.SSL.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));
		}

		private static void Extract12X3(string name, string sdate, string speroid, string code, string dbName)
		{
			string no = code.Replace(" ", ",");
			DateTime datetime = DateTime.Parse(sdate);
			int dateint = int.Parse(datetime.ToString("yyyyMMdd"));
			long p = int.Parse(speroid);
			int n = int.Parse(speroid.Substring(speroid.Length - 2));

			if (dateint < 20120217)
			{
				if (pdic.ContainsKey(dateint))
					pdic[dateint]++;
				else
					pdic.Add(dateint, 1);
				n = pdic[dateint];
			}
			p = dateint * 100 + n;

			if (pset.Contains(p)) return;
			pset.Add(p);

			Data.Biz.D12X3.DwNumberBiz biz = new Data.Biz.D12X3.DwNumberBiz(dbName);
			biz.Add(biz.Create(p, n, no, dateint, sdate));
		}
	}
}

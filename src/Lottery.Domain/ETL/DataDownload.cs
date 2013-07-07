using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Lottery.ETL
{
	using Logging;
	using Data.Biz.Common;
	using Model.Common;

	public class DataDownload
	{
		public static void DownKaiJiangData()
		{
			List<Category> categories = CategoryBiz.Instance.GetEnabledCategories();
			foreach (var category in categories)
			{
				if (category.ParentId == 0) continue;
				if(category.DownUrl.Contains("www.pinble.com"))
					DownPinbleKaiJiangData(category);
				else if(category.DownUrl.Contains("www.lecai.com"))
					DownLeCaiKaiJiangData(category);
			}
		}

		public static void DownKaiJiangData(int categoryId)
		{
			var categories = CategoryBiz.Instance.GetEnabledCategories().Where(x => x.Id == categoryId);
			foreach (var category in categories)
			{
				if (category.ParentId == 0) continue;
				if(category.DownUrl.Contains("www.pinble.com"))
					DownPinbleKaiJiangData(category);
				else if(category.DownUrl.Contains("www.lecai.com"))
					DownLeCaiKaiJiangData(category);
			}
		}

		private static void DownLeCaiKaiJiangData(Category category)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "KaiJiang", category.Name);
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;

			DateTime startDate = new DateTime(2008,1,1);
			Queue<string> fileQueue= new Queue<string>(100);
			for (DateTime currDate = startDate; currDate <= DateTime.Now; currDate = currDate.AddDays(1))
			{
				string url = string.Format(category.DownUrl, currDate.ToString("yyyy-MM-dd"));
				string fileName = string.Format("{0}\\{1}.html", path, currDate.ToString("yyyy-MM-dd"));
				fileQueue.Enqueue(fileName);
				
				try
				{
					while(fileQueue.Count > 0){
						string tmpFileName = fileQueue.Dequeue();
						if (!File.Exists(tmpFileName))
							wc.DownloadFile(url, tmpFileName);
					}
				}
				catch
				{
					fileQueue.Enqueue(fileName);
					Logger.Instance.Write(url);
				}
			}

			Console.WriteLine("{0}:DownPage Finished!", category.Name);
		}
		
		private static void DownPinbleKaiJiangData(Category category)
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "KaiJiang", category.Name);
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;

			for (int i = 1; i <= category.DownPageCount; i++)
			{
				string url = string.Format(category.DownUrl, i, category.Code, "", category.Name, category.IsGP);
				string fileName = string.Format("{0}\\{1}.html", path, i);
				try
				{
					string htmlText = wc.DownloadString(url);
					wc.DownloadFile(url, fileName);
				}
				catch
				{
					Logger.Instance.Write(url);
				}
			}

			Console.WriteLine("{0}:DownPage Finished!", category.Name);
		}

		public static void DownPinbleCategory()
		{
			string categoryUrl = "http://www.pinble.com/Lottery.htm";
			string url1 = "http://www.pinble.com/Template/WebService1.asmx/lotteryNameData?lotteryName={0}";
			string url2 = "http://www.pinble.com/Template/WebService1.asmx/Present3DList?pageindex={0}&lottory={1}&pl3={2}&type={3}&isgp={4}";

			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			string fileName = string.Format("{0}\\{1}", path, "Lottery.html");
			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;
			wc.DownloadFile(categoryUrl, fileName);

			StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
			string text = sr.ReadToEnd();
			sr.Close();

			fileName = string.Format("{0}\\{1}", path, "categories.txt");
			StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8);
			MatchCollection matches = Regex.Matches(text, "ListClick\\('(.*?)','(.*?)'\\)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			foreach (Match m in matches)
			{
				int pageIndex = 1;
				string name = m.Groups[1].Value;
				string isgp = m.Groups[2].Value;
				string pl3 = name.ToLower().Equals("pl3") ? "pl3" : "";

				try
				{
					string lotteryNameText = wc.DownloadString(string.Format(url1, name));
					string lotteryName = Regex.Replace(lotteryNameText, "<.*?>|[\\r\\n]", "", RegexOptions.IgnoreCase | RegexOptions.Singleline).Trim();
					string page1Text = wc.DownloadString(string.Format(url2, pageIndex, lotteryName, pl3, name, isgp));
					string count = Regex.Match(page1Text, "共\\：(\\d+)条", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;
					string pageCount = Regex.Match(page1Text, "分页\\:1/(\\d+)页", RegexOptions.Singleline | RegexOptions.IgnoreCase).Groups[1].Value;

					sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", name, isgp, lotteryName, pageCount, count, pl3));
				}
				catch (Exception ex)
				{
					Logger.Instance.Write(string.Format("{0}:{1}", name, ex.ToString()));
				}
			}
			sw.Close();
			Console.WriteLine("Finished!");
		}
	}
}

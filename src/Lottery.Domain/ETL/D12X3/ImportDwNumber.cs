using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Lottery.ETL.D12X3
{
    using Model.Common;
    using Model.D12X3;
    using Lottery.Data.SQLServer.Common;
    using Lottery.Data.SQLServer.D12X3;
    using Utils;

    public class ImportDwNumber
    {
        public static void Start()
        {
            List<Category> categories = CategoryBiz.Instance.GetCategories().Where(x => x.Type.Equals("12X3")).ToList();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Extract");

            foreach (Category category in categories)
            {
                string dataFileName = string.Format(@"{0}\{1}.txt", path, category.Name);
                if (!File.Exists(dataFileName)) continue;
                StreamReader reader = new StreamReader(dataFileName, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line) ||
                        line.Trim().Length == 0) continue;
                    ImportD12X3(line, category.Name);
                }
                reader.Close();
            }
            Console.WriteLine("Finished!");
        }

        private static void ImportD12X3(string line, string name)
        {
        }
    }
}

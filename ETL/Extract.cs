using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing;
using System.IO;
using System.Xml.Linq;

namespace ETL
{
    public class Extract
    {
        public List<MonthlyAmount> Purchases { get; private set; }
        public List<MonthlyAmount> IndustryIndex { get; private set; }
        public List<MonthlyAmount> WebClicks { get; private set; }

        public Extract()
        {
            Purchases = ExtractPurchases();
            IndustryIndex = ExtractIndex();
            WebClicks = ExtractClicks();
        }

        public List<MonthlyAmount> ExtractPurchases()
        {
            var purchases = new List<MonthlyAmount>();
            using (var db = new PurchasingEntities())
            {
                var monthlyPurchases = db.TotalPurchases.OrderBy(tp => tp.RowNumber);
                foreach (var month in monthlyPurchases)
                {
                    purchases.Add(new MonthlyAmount()
                    {   
                        Year = month.Year ?? 0,
                        Month = month.Month ?? 0,
                        Amount = month.TotalPurchases ?? 0
                    });
                }
            }
            return purchases.ToList();
        }
        public List<MonthlyAmount> ExtractIndex()
        {
            string path = @"Data\IndustryIndex.txt";

            if (File.Exists(path))
            {
                var indexes = File.ReadAllLines(path).Select(record => new MonthlyAmount(record)).ToList();

                return indexes;
            }
            else
            {
                return null;
            }   
        }
        public List<MonthlyAmount> ExtractClicks()
        {
            string path = @"Data\WebSiteActivity.xml";
            if (File.Exists(path))
            {
                XElement xmlDoc = XElement.Load(path);
                var clicks = (from clks in xmlDoc.Descendants("Clicks")
                              select new MonthlyAmount()
                              {
                                  Year = Convert.ToInt32(clks.Attribute("YearMonth").Value) / 100,
                                  Month = Convert.ToInt32(clks.Attribute("YearMonth").Value) % 100,
                                  Amount = Convert.ToDecimal(clks.Value),
                              }
                            ).ToList();

                return clicks;
            }
            else
            {
                return null;
            }
        }
    }

    public class MonthlyAmount
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public int Key => (Year * 100) + Month;
        
        public MonthlyAmount() // For xml
        {

        }

        public MonthlyAmount(string record) // For csv
        {
            string[] field = record.Split(',');

            Year = Convert.ToInt32(field[0]);
            Month = Convert.ToInt32(field[1]);
            Amount = Convert.ToDecimal(field[2]);
        }
    }
}

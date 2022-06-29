using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

// This ETL process extracts:
// // Purchase History
// // Industry Index
// // Web Click Report
// Destination Type: SQL Server Database
// // Server: DOTNET.REYNOLDS.EDU    Database: ITP236-03    Table: PurchasingDW

namespace ETL
{
    internal class PurchIndClk
    {
        public static void PurchIndClkMain()
        {
            Console.WriteLine("---PurchIndClk---");
        // EXTRACT
            Console.WriteLine("extracting Purchase Summaries...");
            List<PurchaseSummary> monthlyPurchaseSummaries  = PurchaseSummary.Extract();
            Console.WriteLine("extracting Industry Indexes...");
            List<IndustryIndex> monthlyIndustryIndexes = IndustryIndex.Extract();
            Console.WriteLine("extracting Web Click Reports...");
            List<WebClickReport> monthlyWebClickReports = WebClickReport.Extract();
        // TRANSFORM
            Console.WriteLine("transforming data...");
            List<TransformedPurchIndClk> transformedData = TransformedPurchIndClk.Transform(monthlyPurchaseSummaries, monthlyIndustryIndexes, monthlyWebClickReports);
        // LOAD
            Console.WriteLine("loading to database table 'PurchasingDw'...");
            bool success = false;
            try
            {
                LoadPurchIndClk(transformedData);
                success = true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}  --  Please contact system administrator.");
                Console.ResetColor();
            }
            finally
            {
                if (success == true)
                {
                    Console.WriteLine("process completed\n");
                }
            }
        }
        internal static void LoadPurchIndClk(List<TransformedPurchIndClk> transformedData)
        {
            using (var db = new Purchasing.PurchasingEntities())
            {
                foreach (var record in transformedData)
                {
                    var purchDwRecord = db.PurchasingDws.FirstOrDefault(pdw => pdw.Year == record.Year && pdw.Month == record.Month);
                    if (purchDwRecord != null) // If the 'Year' and 'Month' combination already exists in table 'PurchasingDw', the table record's other fields are updated
                    {
                        purchDwRecord.TotalPurchases = record.TotalPurchases;
                        purchDwRecord.IndustryIndex = record.IndustryIndex;
                        purchDwRecord.WebsiteClicks = record.WebSiteClicks;
                        db.Entry(purchDwRecord).State = EntityState.Modified;
                    }
                    else if (purchDwRecord == null) // If the 'Year' and 'Month' combination doesn't already exist in table 'PurchasingDw', a new record is created
                    {
                        db.PurchasingDws.Add(new Purchasing.PurchasingDw
                        {
                            //PurchasingDwId = record.PurchasingDwId, // Not currently necessary because primary key 'PurchasingDwId' in table 'PurchasingDw' is an auto-incrementing field
                            Year = record.Year,
                            Month = record.Month,
                            TotalPurchases = record.TotalPurchases,
                            IndustryIndex = record.IndustryIndex,
                            WebsiteClicks = record.WebSiteClicks
                        });
                    }
                }
                db.SaveChanges();
            }
        }
    }
}

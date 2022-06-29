// DATA SOURCE CLASSES
#define PurchaseSummary
//#undef PurchaseSummary
#define IndustryIndex
//#undef IndustryIndex
#define WebClickReport
//#undef WebClickReport
#define SomeOtherDataSource
#undef SomeOtherDataSource

using System;
using System.Collections.Generic;
using System.Linq;

namespace ETL
{
// BASE CLASS
    internal class DataSource // This class is meant to be customized for each application version
    {
        protected internal int Year { get; set; }
        protected internal int Month { get; set; }
        protected internal decimal Amount { get; set; }
        protected internal virtual int YearMonth => (Year * 100) + Month; // Primary Key
    }

// DATA CLASSES
#if PurchaseSummary
    internal class PurchaseSummary : DataSource
    {
        internal PurchaseSummary(Purchasing.TotalPurchas record)
        {
            Year = record.Year ?? 0;
            Month = record.Month ?? 0;
            Amount = record.TotalPurchases ?? 0;
        }

        internal static List<PurchaseSummary> Extract()
        {
            List<PurchaseSummary> monthlyPurchaseSummaries = new List<PurchaseSummary>();
            using (var db = new Purchasing.PurchasingEntities())
            {
                var purchaseSummariesFromSource = db.TotalPurchases.OrderBy(tp => tp.RowNumber);
                foreach (var record in purchaseSummariesFromSource)
                {
                    PurchaseSummary purchaseSummaryRecord = new PurchaseSummary(record);
                    monthlyPurchaseSummaries.Add(purchaseSummaryRecord);
                }
            }
            return monthlyPurchaseSummaries;
        }
    }
#endif
#if IndustryIndex
    internal class IndustryIndex : DataSource
    {
        internal IndustryIndex(string record)
        {
            string[] fields = record.Split(',');

            Year = Convert.ToInt32(fields[0]);
            Month = Convert.ToInt32(fields[1]);
            Amount = Convert.ToDecimal(fields[2]);
        }

        internal static List<IndustryIndex> Extract()
        {
            string path = @"Data\IndustryIndex.txt";
            var industryIndexesFromSource = System.IO.File.ReadAllLines(path).ToList();
            List<IndustryIndex> monthlyIndustryIndexes = new List<IndustryIndex>();
            foreach (var record in industryIndexesFromSource)
            {
                IndustryIndex industryIndexRecord = new IndustryIndex(record);
                monthlyIndustryIndexes.Add(industryIndexRecord);
            }
            return monthlyIndustryIndexes;
        }
    }
#endif
#if WebClickReport
    internal class WebClickReport : DataSource
    {
        internal WebClickReport(System.Xml.Linq.XElement record)
        {
            Year = Convert.ToInt32(record.Attribute("YearMonth").Value) / 100;
            Month = Convert.ToInt32(record.Attribute("YearMonth").Value) % 100;
            Amount = Convert.ToDecimal(record.Value);
        }

        internal static List<WebClickReport> Extract()
        {
            string path = @"Data\WebSiteActivity.xml";
            var webClickReportsFromSource = System.Xml.Linq.XElement.Load(path);
            List<WebClickReport> monthlyWebClickReports = new List<WebClickReport>();
            foreach (var record in webClickReportsFromSource.Descendants("Clicks"))
            {
                WebClickReport webClickReportRecord = new WebClickReport(record);
                monthlyWebClickReports.Add(webClickReportRecord);
            }
            return monthlyWebClickReports;
        }
    }
#endif
#if SomeOtherDataSource
    internal class SomeOtherDataSource : DataSource
    {
        internal SomeOtherDataSource()
        {
            // Code goes here
        }
        internal static List<SomeOtherDataSource> Extract()
        {
            // Code goes here
        }
    }
#endif
}

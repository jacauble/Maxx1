// ETL PROCESSES
#define PurchIndClk
//#undef PurchIndClk
#define SomeOtherProcess
#undef SomeOtherProcess

using System;
using System.Collections.Generic;
using System.Linq;

namespace ETL
{
// TRANSFORM CLASSES
#if PurchIndClk
    public class TransformedPurchIndClk
    {
        internal int Year { get; set; }
        internal int Month { get; set; }
        internal int PurchasingDwId => (Year * 100) + Month; // Primary Key
        internal decimal TotalPurchases { get; set; }
        internal decimal IndustryIndex { get; set; }
        internal int WebSiteClicks { get; set; }

        internal static List<TransformedPurchIndClk> Transform(List<PurchaseSummary> monthlyPurchaseSummaries, List<IndustryIndex> monthlyIndustryIndexes, List<WebClickReport> monthlyWebClickReports)
        {
            List<TransformedPurchIndClk> transformedData =
                (from clk in monthlyWebClickReports
                 join pur in monthlyPurchaseSummaries on clk.YearMonth equals pur.YearMonth
                 into joinedClkPur from pur in joinedClkPur.DefaultIfEmpty()
                 join ind in monthlyIndustryIndexes on clk.YearMonth equals ind.YearMonth
                 into joinedClkInd from ind in joinedClkInd.DefaultIfEmpty()
                 select new TransformedPurchIndClk()
                 {
                     Year = ind?.Year ?? 0,
                     Month = ind?.Month ?? 0,
                     TotalPurchases = pur?.Amount ?? 0,
                     IndustryIndex = ind?.Amount ?? 0,
                     WebSiteClicks = Convert.ToInt32(clk?.Amount ?? 0)
                 }).ToList();
            return transformedData;
        }
    }
#endif
#if SomeOtherProcess
    public class TransformedSomeOtherProcess
    {
        // Properties go here

        internal static List<TransformedSomeOtherProcess> Transform()
        {
            // Code goes here
        }
    }
#endif
}

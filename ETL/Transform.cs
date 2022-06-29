using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Purchasing;

namespace ETL
{
    public class Transform
    {
        public List<TransData> TransDw { get; private set; }
        public Transform(Extract extract)
        {
            TransDw = (from click in extract.WebClicks
                       join pur in extract.Purchases on click.Key equals pur.Key
                       into joined1 from pur in joined1.DefaultIfEmpty()
                       join ind in extract.IndustryIndex on click.Key equals ind.Key
                       into joined2 from ind in joined2.DefaultIfEmpty()

                       select new TransData()
                       {
                           Year = ind.Year,
                           Month = ind.Month,
                           TotalPurchases = pur?.Amount ?? 0,
                           IndustryIndex = ind.Amount,
                           WebSiteClicks = Convert.ToInt64(click.Amount)
                       }
                       ).ToList();
        }
    }

    public class TransData
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int PurchasingDwId => (Year * 100) + Month;
        public decimal TotalPurchases { get; set; }
        public decimal IndustryIndex { get; set; }
        public long WebSiteClicks { get; set; }
    }
}

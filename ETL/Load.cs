using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Purchasing;

namespace ETL
{
    public class Load
    {
        public List<LoadData> LoadDw { get; private set; }

        public Load(Transform transform)
        {
            LoadDw = new List<LoadData>();
            foreach (var trans in transform.TransDw)
            {
                LoadDw.Add(new LoadData()
                {
                    PurchasingDwId = trans.PurchasingDwId,
                    Year = trans.Year,
                    Month = trans.Month,
                    TotalPurchases = trans.TotalPurchases,
                    IndustryIndex = trans.IndustryIndex,
                    WebSiteClicks = trans.WebSiteClicks
                });
            }
                      
        }
        public static void TestIt(Load load)
        {
            using (var db = new PurchasingEntities())
            {
                foreach (var foo in load.LoadDw)
                {
                    var purchasingDw = db.PurchasingDws.FirstOrDefault(
                        k => (k.Year == foo.Year && k.Month == foo.Month));
                    if (purchasingDw == null)
                    {
                        db.PurchasingDws.Add(new PurchasingDw
                        {
                            PurchasingDwId = foo.PurchasingDwId,
                            Year = foo.Year,
                            Month = foo.Month,
                            TotalPurchases = foo.TotalPurchases,
                            IndustryIndex = foo.IndustryIndex,
                            WebsiteClicks = Convert.ToInt32(foo.WebSiteClicks)
                        });
                    }
                    else
                    {
                        // UPDATE THE MONTHLY VALUES
                        // SET THE OBJECT TO MODIFIED
                        db.Entry(purchasingDw).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                db.SaveChanges();
            }
        }
    }
    public class LoadData
    {
        public int PurchasingDwId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal TotalPurchases { get; set; }
        public decimal IndustryIndex { get; set; }
        public long WebSiteClicks { get; set; }
    }
}

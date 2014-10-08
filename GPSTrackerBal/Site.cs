using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSTrackerBal
{
    public class Site
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string Location { get; set; }


        public static List<Site> GetSites(int userId, int cityId)
        {
            //This Method will return the Site Id and the Site Name accordingly.
            var lstSites = new List<Site>();

            var site = new Site
            {
                SiteId = 1,
                SiteName = "Indirapuram"
            };

            lstSites.Add(site);
            return lstSites;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSTrackerBal
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public static List<City> GetCities(int userId, string sessionId)
        {
            //This Method will return the City Id and City Name Accordingly.
            var lstCity = new List<City>();

            var city = new City
            {
                CityId = 1,
                CityName = "Ghaziabad"
            };

            lstCity.Add(city);
            return lstCity;
        }
    }
}

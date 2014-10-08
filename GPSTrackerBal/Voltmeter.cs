using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSTrackerBal
{
    public class Voltmeter
    {
        public int VoltmeterId { get; set; }
        public float VoltageP1 { get; set; }
        public float VoltageP2 { get; set; }
        public float VoltageP3 { get; set; }
        public string Timestamp { get; set; }


        public static Voltmeter GetVoltmeterReadings(int userId, int siteId)
        {
            //This Method will return the following according to User ID and Site ID.
            /*{
 "voltmeterId": 170,
 "volatageP1":242,
 "volatageP2":242,
 "volatageP3":242,
 "timestamp":212121321
}*/

            var voltmeter = new Voltmeter
            {
                VoltmeterId = 170,
                VoltageP1 = 242,
                VoltageP2 = 242,
                VoltageP3 = 242,
                Timestamp = "212121321"
            };
            return voltmeter;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSTrackerBal
{
    public class ScheduleLogs
    {
        public static string GetSchedules(int userId, int pumpId, string startTimestamp, string endTimestamp)
        {
            //This Method will return the Following:
            /*
             * {
 "userId": 123,
 "siteId": 123,
 "pumpId": 123,
 "schedules": [
 {
 "recordId": 1,
 "status": 0,
 "startTime": 21212122,
 "endTime": 212121221
 }
 ]
}
             */
            return "";
        }

        public static bool CreateSchedule(int userId, int pumpId, string startTime, string endTime)
        {
            bool isSuccess = true;
            return isSuccess;
        }
    }
}

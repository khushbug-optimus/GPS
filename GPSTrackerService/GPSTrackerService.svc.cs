using System.Collections.Generic;
using System.ServiceModel.Web;
using GPSTrackerBal;
using GPSTrackerService.BAL;
using GPSTrackerService.Entities;

namespace GPSTrackerService
{
    // NOTE: You can use the "Rename" command on the "Re-factor" menu to change the class name "Service1" in code, svc and config file together.
    public class GPSTrackerService : IGPSTrackerService
    {
        #region IGPSTrackerService Members

        public Result AuthenticateUser(UserInfo userNamePassword)
        {
            var userInfo = userNamePassword;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.Authantication(userInfo.UserName, userInfo.Password);
        }

        public List<Cities> GetCities(CityInfo cityIdSessionId)
        {
            var cityInfo = cityIdSessionId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetCities(cityInfo.UserId, cityInfo.SessionId);
        }

        public List<Sites> GetSites(SiteInfo userIdCityId)
        {
            var siteInfo = userIdCityId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetSites(siteInfo.UserId, siteInfo.CityId);
        }

        public SiteDetails GetSiteDetails(SiteDetailsInfo userIdSiteId)
        {
            var siteDetailsInfo = userIdSiteId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetSiteDetails(siteDetailsInfo.UserId, siteDetailsInfo.SiteId);
        }

        public VoltmeterReadings GetVoltmeterReadings(VoltmeterInfo userIdSiteId)
        {
            var voltmeterInfo = userIdSiteId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetVoltmeterReadings(voltmeterInfo.UserId, voltmeterInfo.SiteId);
        }

        public UserActivityLogsResult GetUserActivityLogs(UserActivityInfo userIdStartTimestampEndTimestamp)
        {
            var userActivityInfo = userIdStartTimestampEndTimestamp;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetUserActivityLogs(userActivityInfo.UserId, userActivityInfo.StartTimestamp, userActivityInfo.EndTimestamp);
        }

        public ScheduleLogsResult GetSchedules(ScheduleInfo userIdPumpIdStartTimestampEndTimestamp)
        {
            var scheduleInfo = userIdPumpIdStartTimestampEndTimestamp;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetSchedules(scheduleInfo.UserId, scheduleInfo.PumpId, scheduleInfo.StartTimestamp, scheduleInfo.EndTimestamp);
        }

        public PumpStatus GetPumpStatus(PumpInfo userIdPumpId)
        {
            var pumpInfo = userIdPumpId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetPumpStatus(pumpInfo.UserId, pumpInfo.PumpId);
        }

        public GensetMotorStatus GetGensetMotorStatus(PumpInfo userIdPumpId)
        {
            var pumpInfo = userIdPumpId;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.GetGensetMotorStatus(pumpInfo.UserId, pumpInfo.PumpId);
        }

        public bool UpdateGenset(GensetMotorInfo userIdPumpIdAction)
        {
            var gensetInfo = userIdPumpIdAction;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.UpdateGenset(gensetInfo.UserId, gensetInfo.PumpId, gensetInfo.Action);
        }

        public bool UpdateMotor(GensetMotorInfo userIdPumpIdAction)
        {
            var motorInfo = userIdPumpIdAction;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.UpdateMotor(motorInfo.UserId, motorInfo.PumpId, motorInfo.Action);
        }

        public bool CreateSchedule(ScheduleInfo userIdPumpIdStartTimestampEndTimestamp)
        {
            var sceduleInfo = userIdPumpIdStartTimestampEndTimestamp;
            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.Headers.Add("Cache-Control", "no-cache");
            var businnessLayer = new APIBusinessLayer();

            return businnessLayer.CreateSchedule(sceduleInfo.UserId, sceduleInfo.PumpId, sceduleInfo.StartTimestamp, sceduleInfo.EndTimestamp);
        }
        #endregion
    }
}

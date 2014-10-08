using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GPSTrackerService.Entities;

namespace GPSTrackerService
{
    [ServiceContract]
    public interface IGPSTrackerService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,                   
                    UriTemplate = "/AuthenticateUser")]
        Result AuthenticateUser(UserInfo userNamePassword);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetCities")]
        List<Cities> GetCities(CityInfo userIdSessionId);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetSites")]
        List<Sites> GetSites(SiteInfo userIdCityId);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetSiteDetails")]
        SiteDetails GetSiteDetails(SiteDetailsInfo userIdSiteId);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetVoltmeterReadings")]
        VoltmeterReadings GetVoltmeterReadings(VoltmeterInfo userIdSiteId);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetUserActivityLogs")]
        UserActivityLogsResult GetUserActivityLogs(UserActivityInfo userIdStartTimestampEndTimestamp);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetSchedules")]
        ScheduleLogsResult GetSchedules(ScheduleInfo userIdPumpIdStartTimestampEndTimestamp);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/GetGensetMotorStatus")]
        GensetMotorStatus GetGensetMotorStatus(PumpInfo userIdPumpId);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/UpdateGenset")]
        bool UpdateGenset(GensetMotorInfo userIdPumpIdAction);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/UpdateMotor")]
        bool UpdateMotor(GensetMotorInfo userIdPumpIdAction);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "/CreateSchedule")]
        bool CreateSchedule(ScheduleInfo userIdPumpIdStartTimestampEndTimestamp);
    }
}

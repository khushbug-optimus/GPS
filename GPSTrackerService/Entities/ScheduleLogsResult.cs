using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ScheduleLogsResult
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int SiteId { get; set; }
        [DataMember]
        public int PumpId { get; set; }
        [DataMember]
        public Schedules Schedule { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Schedules
    {
        [DataMember]
        public int RecordId { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string StartTimestamp { get; set; }
        [DataMember]
        public string EndTimestamp { get; set; }
    }
}
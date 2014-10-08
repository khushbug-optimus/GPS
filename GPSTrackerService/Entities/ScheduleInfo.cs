using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ScheduleInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "PumpId")]
        public int PumpId { get; set; }
        [DataMember(Name = "StartTimestamp")]
        public string StartTimestamp { get; set; }
        [DataMember(Name = "EndTimestamp")]
        public string EndTimestamp { get; set; }
    }
}
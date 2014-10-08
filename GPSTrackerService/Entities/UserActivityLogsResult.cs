using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class UserActivityLogsResult
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public Activities activities { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Activities
    {
        [DataMember]
        public int ActivityId { get; set; }
        [DataMember]
        public string ActivityDescription { get; set; }
        [DataMember]
        public string Timestamp { get; set; }
    }
}
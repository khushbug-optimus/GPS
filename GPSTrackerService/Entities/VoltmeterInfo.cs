using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class VoltmeterInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "SiteId")]
        public int SiteId { get; set; }
    }
}
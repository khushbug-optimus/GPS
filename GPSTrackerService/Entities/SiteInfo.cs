using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SiteInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "CityId")]
        public int CityId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SiteDetailsInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "SiteId")]
        public int SiteId { get; set; }
    } 
}
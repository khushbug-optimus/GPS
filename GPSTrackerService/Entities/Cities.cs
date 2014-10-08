using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Cities
    {
        [DataMember]
        public int CityId { get; set; }

        [DataMember]
        public string CityName { get; set; }
    }
}
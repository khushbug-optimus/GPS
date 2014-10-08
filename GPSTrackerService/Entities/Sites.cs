using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Sites
    {
        [DataMember]
        public int SiteId { get; set; }

        [DataMember]
        public string SiteName { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class SiteDetails
    {
        [DataMember]
        public int SiteId { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public Pumps Pump { get; set; }

        [DataMember]
        public Motor Motor { get; set; }

        [DataMember]
        public Genset Genset { get; set; }

        [DataMember]
        public Tank Tank { get; set; }

        [DataMember]
        public string CityName { get; set; }

        [DataMember]
        public string LastUpdatedTimestamp { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Location
    {
        [DataMember]
        public float Latitude { get; set; }
        [DataMember]
        public float Longitude { get; set; }
    }
}
using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class VoltmeterReadings
    {
        [DataMember]
        public int VoltmeterId { get; set; }
        [DataMember]
        public float VoltageP1 { get; set; }
        [DataMember]
        public float VoltageP2 { get; set; }
        [DataMember]
        public float VoltageP3 { get; set; }
        [DataMember]
        public string Timestamp { get; set; }
    }
}
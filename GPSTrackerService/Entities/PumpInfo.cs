using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PumpInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "PumpId")]
        public int PumpId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GensetMotorInfo
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }
        [DataMember(Name = "PumpId")]
        public int PumpId { get; set; }
        [DataMember(Name = "Action")]
        public int Action { get; set; }
    }
}
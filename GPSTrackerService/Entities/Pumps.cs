using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Pumps
    {
        [DataMember]
        public int PumpId { get; set; }
        [DataMember]
        public int PumpStatus { get; set; }
        [DataMember]
        public float RAmp { get; set; }
        [DataMember]
        public float BAmp { get; set; }
        [DataMember]
        public float YVoltage { get; set; }
        [DataMember]
        public float RVoltage { get; set; }
        [DataMember]
        public float BVoltage { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Motor
    {
        [DataMember]
        public int MotorId { get; set; }
        [DataMember]
        public int MotorStatus { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Genset
    {
        [DataMember]
        public int GensetId { get; set; }
        [DataMember]
        public int GensetStatus { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Tank
    {
        [DataMember]
        public int TankId { get; set; }
        [DataMember]
        public int TankLevelCurrent { get; set; }
        [DataMember]
        public int TankLevelMax { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PumpStatus
    {
        [DataMember]
        public int PumpId { get; set; }
        [DataMember]
        public int PmpStatus { get; set; }
        [DataMember]
        public float RAmp { get; set; }
        [DataMember]
        public float BAmp { get; set; }
        [DataMember]
        public float YVoltage { get; set; }
        [DataMember]
        public float RVoltage { get; set; }
        [DataMember]
        public float BVoltage { get; set; }
        [DataMember]
        public string LastUpdatedTimestamp { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class GensetMotorStatus
    {
        [DataMember]
        public int PumpId { get; set; }

        [DataMember]
        public Motor Motor { get; set; }

        [DataMember]
        public Genset Genset { get; set; }
    }
}
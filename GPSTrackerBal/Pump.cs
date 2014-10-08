using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPSTrackerBal
{
    public class Pump
    {
        public int PumpId { get; set; }
        public int PumpStatus { get; set; }
        public float RAmp { get; set; }
        public float BAmp { get; set; }
        public float YVoltage { get; set; }
        public float RVoltage { get; set; }
        public float BVoltage { get; set; }
        public string LastUpdateTimestamp { get; set; }
        public int MotorId { get; set; }
        public bool MotorStatus { get; set; }
        public int GensetId { get; set; }
        public bool GensetStatus { get; set; }

        public static Pump GetPumpStatus(int userId, int pumpId)
        {
            var pump = new Pump
            {
                PumpId = 1,
                PumpStatus = -1,
                RAmp = 12,
                BAmp = 123,
                YVoltage = 242,
                RVoltage = 222,
                BVoltage = 235,
                LastUpdateTimestamp = "1112312312"
            };
            return pump;
        }

        public static Pump GetGensetMotorStatus(int userId, int pumpId)
        {
            var pump = new Pump
            {
                PumpId = 1,
                MotorId = 2,
                MotorStatus = false,
                GensetId = 12213,
                GensetStatus = true
            };

            return pump;
        }

        public static bool UpdateGenset(int userId, int pumpId, int action)
        {
            bool isSuccess = true;

            return isSuccess;
        }

        public static bool UpdateMotor(int userId, int pumpId, int action)
        {
            bool isSuccess = true;

            return isSuccess;
        }        
    }
}

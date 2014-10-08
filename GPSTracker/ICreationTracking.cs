using System;

namespace GPSTrackerDal
{
    public interface ICreationTracking
    {
        int CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
    }
}

using System;

namespace GPSTrackerDal
{
    public interface IChangeTracking : ICreationTracking
    {
        int LastModifiedBy { get; set; }
        DateTime LastModifiedOn { get; set; }
    }
}

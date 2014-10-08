using System.Diagnostics;
namespace GPSTrackerDal
{
    public static class DataContextFactory
    {
        static IDataContextProvider<GPSTrackerDataContext> gPSTrackerProvider;

        public static IDataContextProvider<GPSTrackerDataContext> GPSTrackerProvider
        {
            get { return gPSTrackerProvider; }
            set { gPSTrackerProvider = value; }
        }

        public static GPSTrackerDataContext GetFreshGPSTrackerDataContext()
        {
            return new GPSTrackerDataContext();
        }

        public static GPSTrackerDataContext GetGPSTrackerDataContext()
        {
            //NOTE: 2009/06/11 - The line below doesn't work when using the GPSTrackerDal outside of the web app framework
            //Debug.Assert(gPSTrackerProvider != null, "gPSTrackerProvider must be set before calling DataContextFactory methods!");

            //We'll get around this by simply returning a new data context where the data context isn't already set.
            //Instead of doing this, we could create a new datacontext provider for client applications...
            if (gPSTrackerProvider != null)
            {
                return gPSTrackerProvider.GetDataContext();
            }
            else
            {
                return GetFreshGPSTrackerDataContext();
            }
        }

        public static void ForceReplacementOfDataContext()
        {
            Debug.Assert(gPSTrackerProvider != null, "GPSTrackerProvider must be set before calling DataContextFactory methods!");

            gPSTrackerProvider.DiscardDataContext();
        }
    }
}

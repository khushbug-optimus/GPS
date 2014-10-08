using System.Data.Linq;

namespace GPSTrackerDal
{
    public interface IDataContextProvider<T> where T : DataContext
    {
        T GetDataContext();
        void DiscardDataContext();
    }
}

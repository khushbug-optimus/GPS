using GPSTrackerDal;
using System.Linq;
namespace GPSTrackerBal
{
   public class GPSUser
    {
       public static void InsertUser(string username)
       {
          GPSTrackerDataContext db = DataContextFactory.GetGPSTrackerDataContext();
           Usermap um = new Usermap();
           um.Name = username;
           db.Usermaps.InsertOnSubmit(um);
           db.SubmitChanges();
       }
       public static Usermap Get(int id)
       {
           GPSTrackerDataContext db = DataContextFactory.GetGPSTrackerDataContext();

           return (from um in db.Usermaps
                   where um.ID == id
                   select um).Single();
       }
    
    }
}
using System;
using System.Collections.Generic;
using System.Data.Linq;

namespace GPSTrackerDal
{
  public  class ChangeTracker
    {
        private const int DEFAULT_USER_ID = -1; //this user id is used when the provider is not set

        static IByIDProvider _provider;

        public static void SetByIDProvider(IByIDProvider provider)
        {
            _provider = provider;
        }

        private static int GetUserID()
        {
            if (_provider != null)
            {
                if (_provider.ByID == 0)
                {
                    return -1;
                }
                else
                {
                    return _provider.ByID;
                }
            }
            else
            {
                return -1;
            }
        }

        static void TrackInsert(ICreationTracking track)
        {
            if (track == null)
                return;

            track.CreatedOn = DateTime.Now;
            track.CreatedBy = GetUserID();

            TrackUpdate(track as IChangeTracking);
        }

        static void TrackUpdate(IChangeTracking track)
        {
            if (track == null)
                return;

            track.LastModifiedOn = DateTime.Now;
            track.LastModifiedBy = GetUserID();
        }

        public static void MaintainAuditLog(GPSTrackerDataContext db)
        {
            ChangeSet changes = db.GetChangeSet();

            ProcessInserts(changes.Inserts, db);
            ProcessUpdates(changes.Updates, db);
            ProcessDeletes(changes.Deletes, db);
        }

        static void ProcessDeletes(IList<object> deletes, GPSTrackerDataContext db)
        {

        }

        static void ProcessUpdates(IList<object> updates, GPSTrackerDataContext db)
        {
            foreach (object o in updates)
            {
                TrackUpdate(o as IChangeTracking);
            }
        }

        static void ProcessInserts(IList<object> inserts, GPSTrackerDataContext db)
        {
            foreach (object o in inserts)
            {
                TrackInsert(o as ICreationTracking);
            }
        }

        enum DbOperation
        {
            Insert, Update, Delete
        }
    }
}

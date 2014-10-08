using System;
using System.Collections.Generic;
using System.Data.Linq;

namespace GPSTrackerDal
{
    partial class GPSTrackerDataContext
    {
        List<Action> _postSubmitChangesMethodsToCall;
        public override void SubmitChanges(ConflictMode failureMode)
        {
            ProcessChanges();

            try
            {
                base.SubmitChanges(failureMode);
            }
            //catch(System.Data.SqlClient.SqlException sqlEx) {
            //    string s = sqlEx.Message;
            //}


            catch (ChangeConflictException e)
            {
                string s = e.Message;
                switch (failureMode)
                {
                    case ConflictMode.ContinueOnConflict:
                        foreach (ObjectChangeConflict cc in this.ChangeConflicts)
                        {
                            cc.Resolve(RefreshMode.KeepChanges);
                        }
                        break;
                    case ConflictMode.FailOnFirstConflict:
                        foreach (ObjectChangeConflict cc in this.ChangeConflicts)
                        {
                            //cc.Resolve(RefreshMode.KeepCurrentValues);
                            cc.Resolve(RefreshMode.KeepChanges);
                        }
                        break;
                    default:
                        foreach (ObjectChangeConflict cc in this.ChangeConflicts)
                        {
                            cc.Resolve(RefreshMode.OverwriteCurrentValues);
                        }
                        break;
                }
            }

            CallPostSubmitChangesMethods();
        }
        void CallPostSubmitChangesMethods()
        {
            if (_postSubmitChangesMethodsToCall != null)
            {
                foreach (Action action in _postSubmitChangesMethodsToCall)
                {
                    action();
                }

                _postSubmitChangesMethodsToCall = null;
            }
        }
        void ProcessChanges()
        {
            ProcessDeletes();
            ProcessInserts();
            ChangeTracker.MaintainAuditLog(this);
        }
        void ProcessInserts()
        {

        }

        void ProcessDeletes()
        {
            const int MAX_TO_DELETE = 2000;

            int deletionCount;
            IList<object> toDelete;
            do
            {
                toDelete = GetChangeSet().Deletes;
                deletionCount = toDelete.Count;

                foreach (object o in toDelete)
                {
                    var d = o as IDeleteable;
                    if (d != null)
                    {
                        d.PrepareForDeletion();
                    }
                    else
                    {
                        throw new Exception(String.Format("Deletion of {0} is not supported!", o.GetType().Name));
                    }
                }

                toDelete = GetChangeSet().Deletes;

                //deletionCount < MAX_TO_DELETE is to break out of accidental infinite loops
            } while (deletionCount != toDelete.Count && deletionCount < MAX_TO_DELETE);

            if (deletionCount > MAX_TO_DELETE)
            {
                throw new Exception(
                  String.Format("Attempted to delete more than {0} objects at one time.  This likely an infinite loop bug.",
                                MAX_TO_DELETE));
            }
        }

    }
}

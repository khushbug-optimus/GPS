namespace GPSTrackerDal
{
    public interface IDeleteable
    {
        /// <summary>
        /// Called by GPSTrackerDataContext before actually deleting, allows object to delete any items that need to be cascade deleted
        /// 
        /// This method may get called multiple times before deletion actually occurs, all the work should be completed on the first call
        /// additional calls can simply return immediately
        /// 
        /// If the deletion should not occur for some reason throw an exception with a user friendly message
        /// </summary>
        void PrepareForDeletion();
    }
}

namespace GPSTrackerBal
{
    public class UserInformation
    {
        public bool IsAuthorized(Authorization auth)
        {
            switch (auth)
            {
                case Authorization.User:

                case Authorization.Admin:

                    return true;

                default:
                    return false;
            }
        }
    }
}

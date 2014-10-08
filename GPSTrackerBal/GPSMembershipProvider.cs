using System.Web.Security;

namespace GPSTrackerBal
{
    public class GPSMembershipProvider : SqlMembershipProvider
    {
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion,
                                                  string passwordAnswer, bool isApproved, object providerUserKey,
                                                  out MembershipCreateStatus status)
        {

            MembershipUser user = Membership.GetUser(username);


            if (user != null)
            {
                user.ResetPassword(password);
                status = MembershipCreateStatus.Success;

            }
            else
            {
                user =
                    base.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved,
                                    providerUserKey,
                                    out status);


                if (status == MembershipCreateStatus.Success)
                {
                    //  Usermap.InsertUser(username);
                }
            }

            return user;




            MembershipUser user1 =
                base.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey,
                                out status);

            if (status == MembershipCreateStatus.Success)
            {
                //  Usermap.InsertUser(username);
            }

            return user1;

        }


        public override bool ValidateUser(string username, string password)
        {
            return base.ValidateUser(username, password);

        }
    }
}

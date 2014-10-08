using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using GPSTrackerDal;

namespace GPSTrackerBal
{
    public class User
    {
        public enum UserRoles
        {
            Admin = 0,
            DepotUser = 1,
            PumpUser = 2
        }

        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_DEPOT = "DepotUser";
        public const string ROLE_PUMP = "PumpUser";


        public static ProfileBase GetUserProfile(string userName)
        {
            ProfileBase profile = new ProfileBase();
            profile.Initialize(userName, true);
            return profile;
        }


        /// <summary>
        /// Determine whether the current user is a member of a specific role
        /// </summary>
        /// <param name="RoleID">The numeric id of the role</param>
        /// <returns>A Boolean flag indicating whether the user is a member of the role</returns>
        public bool IsInRole(UserRoles RoleID)
        {
            bool result = false;

            try
            {
                result = System.Web.Security.Roles.IsUserInRole(GetRoleName(RoleID));
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determine whether a user is a member of a specific role
        /// </summary>
        /// <param name="UserID">The numeric id of the user</param>
        /// <param name="RoleID">The numeric id of the role</param>
        /// <returns>A Boolean indicating whether the user is a member of the role</returns>
        public static bool UserIsInRole(int UserID, UserRoles RoleID)
        {
            bool result = false;

            try
            {
                Usermap u = GPSUser.Get(UserID);

                result = System.Web.Security.Roles.IsUserInRole(u.Name, GetRoleName(RoleID));
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Determine whether a user is a member of a specific role
        /// </summary>
        /// <param name="UserName">The username the user</param>
        /// <param name="RoleID">The numeric id of the role</param>
        /// <returns>A Boolean indicating whether the user is a member of the role</returns>
        public static bool UserIsInRole(string UserName, UserRoles RoleID)
        {
            bool result = false;

            try
            {
                result = System.Web.Security.Roles.IsUserInRole(UserName, GetRoleName(RoleID));
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Returns the string representation of the role name given the role id.
        /// </summary>
        /// <param name="role">the numeric identifier for the role</param>
        /// <returns>the string representation of the role as stored in the database</returns>
        private static string GetRoleName(UserRoles role)
        {
            string result = "No user";
            switch (role)
            {
                case UserRoles.Admin:
                    result = ROLE_ADMIN;
                    break;
                case UserRoles.DepotUser:
                    result = ROLE_DEPOT;
                    break;
                case UserRoles.PumpUser:
                    result = ROLE_PUMP;
                    break;

                //default:
                //    result = "No user";
                //    break;
            }

            return result;
        }

    }
}

using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    [DataContract]
    public class UserInfo
    {
        [DataMember(Name = "UserName")]
        public string UserName { get; set; }
        [DataMember(Name = "Password")]
        public string Password { get; set; }
    }

    public class AuthenticationTokenBuilderName
    {
        public string Token { get; set; }
        public string UserName { get; set; }

    }
}
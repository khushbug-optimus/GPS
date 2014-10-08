using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Runtime.Serialization;

namespace GPSTrackerService.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [KnownType(typeof(string))]
    [DataContract]
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ResultData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public ResultMessage ResultMessage { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ResultMessage
    {
        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ResultKeys
    {
        public static readonly string Status = "status";
        public static readonly string Message = "message";
        public static readonly string AuthToken = "authToken";
        public static readonly string Projects = "Projects";

        public static readonly string UserId = "UserId";
    }
}
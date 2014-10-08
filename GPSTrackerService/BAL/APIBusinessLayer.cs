using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;
using GPSTrackerBal;
using GPSTrackerService.Entities;
using SysSecurity = System.Web.Security;

namespace GPSTrackerService.BAL
{
    public class APIBusinessLayer
    {
        int _authTokenDefaultLifeTimeInSec = 0;
        public Result Authantication(string userName, string password)
        {
            Result result;
            // Authenticate User using UserName, password
            try
            {
                if (SysSecurity.Membership.ValidateUser(userName, password))
                {

                    //Authorization



                    var roles = new List<string>(Roles.GetRolesForUser(userName));

                    bool isAdminUser = roles.Contains(User.ROLE_ADMIN);

                    if (isAdminUser)
                    {
                        result = new Result
                            {
                                ResultMessage = new ResultMessage
                                {
                                    Message = "Authantication passed",
                                    Status = "1"
                                },
                                ResultData = GetAuthanticationTockenForUserName(userName, userName, password),
                            };
                    }
                    else
                    {
                        result = new Result
                        {
                            ResultMessage = new ResultMessage
                            {
                                Message = "User is not a valid Builder",
                                Status = "0"
                            },
                            ResultData = "",
                            UserId = 0
                        };
                    }



                }
                else
                {
                    result = new Result
                    {
                        ResultMessage = new ResultMessage
                        {
                            Message = "Authantication failed",
                            Status = "0"
                        },
                        ResultData = ""
                    };
                }

            }
            catch (Exception exception)
            {
                ErrorLogger.LogException(exception);
                result = new Result
                {
                    ResultMessage = new ResultMessage
                    {
                        Message =
                            "Error in authanticate user operation. Details :" +
                            exception.Message,
                        Status = "0"
                    },
                    ResultData = ""
                };
            }

            return result;



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAuthToken"></param>
        /// <param name="expectedUsername"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool AuthanticationUsingAuthToken(string userAuthToken, string expectedUsername, out Result result)
        {
            result = new Result();
            //Decrypt auth token
            var deCryptedTicket = DecrypteToken(userAuthToken);

            // Authanticate User using AuthToken
            // split the user data back apart
            string[] userData = deCryptedTicket.UserData.Split(new string[] { "/" }, StringSplitOptions.None);

            // verify that the username in the ticket matches the username that was sent with the request
            if (deCryptedTicket.Name.Trim().ToLower().Equals(expectedUsername.ToLower()))
            {
                if (SysSecurity.Membership.ValidateUser(deCryptedTicket.Name, userData[2]))
                {

                    var roles = new List<string>(Roles.GetRolesForUser(deCryptedTicket.Name));

                    bool isAdminUser = roles.Contains(User.ROLE_ADMIN);

                    if (isAdminUser)
                    {
                        return true;
                    }
                    result = new Result
                    {
                        ResultMessage = new ResultMessage
                        {
                            Message = "User is not a valid Builder",
                            Status = "0"
                        },
                        ResultData = ""
                    };

                }
                else
                {
                    result = new Result
                    {
                        ResultMessage = new ResultMessage
                        {
                            Message = "User authantication failed",
                            Status = "0"
                        },
                        ResultData = ""
                    };
                }

            }
            return false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GetAuthanticationTockenForUserName(string userId, string userName, string password)
        {
            try
            {
                if (AssertAuthTokenLifeTime(ConfigurationManager.AppSettings["DefaultAuthtokenTimeOut"]))
                {
                    int.TryParse(ConfigurationManager.AppSettings["DefaultAuthtokenTimeOut"],
                                 out _authTokenDefaultLifeTimeInSec);
                }


                // fill the userData array with the information we need for subsequent requests
                var userData = GenerateUserData(userId, userName, password);

                // create a Forms Auth ticket with the username and the user data. 
                var formsTicket = GenerateFormAuthTicket(1, userName, userData);

                // Encrypt it
                var userAuthToken = EncrypteToken(formsTicket);

                // return the AuthToken
                return userAuthToken;
            }
            catch (Exception exception)
            {
                throw;
            }


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAuthToeknExpire"></param>
        /// <returns></returns>
        private bool AssertIsAuthExpire(string isAuthToeknExpire)
        {
            bool isAuthTokenExpires = false;
            if (!string.IsNullOrEmpty(isAuthToeknExpire) && !string.IsNullOrWhiteSpace(isAuthToeknExpire))
            {
                bool.TryParse(isAuthToeknExpire, out isAuthTokenExpires);
            }
            else
            {
                throw new ArgumentException("App setting for isAuthToeknExpire is not set");
            }

            return isAuthTokenExpires;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authTokenLifeTime"></param>
        /// <returns></returns>
        private bool AssertAuthTokenLifeTime(string authTokenLifeTime)
        {
            bool isAuthTokenLifeTimeValid = false;
            if (!string.IsNullOrEmpty(authTokenLifeTime) && !string.IsNullOrWhiteSpace(authTokenLifeTime))
            {
                bool.TryParse(authTokenLifeTime, out isAuthTokenLifeTimeValid);
            }
            else
            {
                throw new ArgumentException("App setting for isAuthToeknExpire is not set");
            }

            return isAuthTokenLifeTimeValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string[] GenerateUserData(string userId, string userName, string password)
        {
            string[] userData = {
                               userId 
                               , userName
                               , password
                           };
            return userData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionNumber"></param>
        /// <param name="userName"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        private FormsAuthenticationTicket GenerateFormAuthTicket(int versionNumber, string userName, string[] userData)
        {
            var formsTicket = new FormsAuthenticationTicket(
                // Version
    versionNumber,
                // Token Name
    userName,
                //Creation time
    DateTime.Now,
                //Expiration
    DateTime.Now.AddMinutes(_authTokenDefaultLifeTimeInSec),
                // Persistant
    true,
                //User Data
    string.Join("/", userData)
    );
            return formsTicket;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        private string EncrypteToken(FormsAuthenticationTicket authToken)
        {
            string encryptedTicket;
            // encrypt the ticket
            try
            {
                if (authToken != null)
                {
                    encryptedTicket = FormsAuthentication.Encrypt(authToken);
                }
                else
                {
                    throw new ArgumentException("AuthToken can not be null or empty");
                }
            }
            catch (Exception)
            {
                throw;
            }

            return encryptedTicket;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enCryptedAuthToken"></param>
        /// <returns></returns>
        private FormsAuthenticationTicket DecrypteToken(string enCryptedAuthToken)
        {
            // decrypt the ticket
            FormsAuthenticationTicket deCryptedTicket;
            if (!string.IsNullOrEmpty(enCryptedAuthToken) && !string.IsNullOrWhiteSpace(enCryptedAuthToken))
            {
                deCryptedTicket = FormsAuthentication.Decrypt(enCryptedAuthToken);
            }
            else
            {
                throw new ArgumentException("AuthToken can not be null or empty");
            }

            return deCryptedTicket;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public List<Cities> GetCities(int userId, string sessionId)
        {
            var lstCities = GPSTrackerBal.City.GetCities(userId, sessionId);
            List<Cities> cities = new List<Cities>();
            foreach (var c in lstCities)
            {
                var city = new Cities
                {
                    CityId = c.CityId,
                    CityName = c.CityName
                };
                cities.Add(city);
            }
            return cities;
        }

        public List<Sites> GetSites(int userId, int cityId)
        {
            var lstSites = GPSTrackerBal.Site.GetSites(userId, cityId);
            List<Sites> sites = new List<Sites>();
            foreach (var s in lstSites)
            {
                var site = new Sites
                {
                    SiteId = s.SiteId,
                    SiteName = s.SiteName
                };
                sites.Add(site);
            }
            return sites;
        }

        public SiteDetails GetSiteDetails(int userId, int siteId)
        {
            var siteDetails = new SiteDetails
            {
                SiteId = 1,
                SiteName = "Indirapuram",
                Location = new Location { Latitude = 22.4343f, Longitude = 27.33432f },
                Pump = new Pumps
                {
                    PumpId = 1,
                    PumpStatus = -1,
                    RAmp = 12,
                    BAmp = 123,
                    YVoltage = 242,
                    RVoltage = 222,
                    BVoltage = 235
                },
                Motor = new Motor
                {
                    MotorId = 2,
                    MotorStatus = 0
                },
                Genset = new Genset
                {
                    GensetId = 12213,
                    GensetStatus = 1
                },
                Tank = new Tank
                {
                    TankId = 123,
                    TankLevelCurrent = 230,
                    TankLevelMax = 500
                },
                CityName = "Ghaziabad",
                LastUpdatedTimestamp = "1112312312"
            };

            return siteDetails;
        }

        public VoltmeterReadings GetVoltmeterReadings(int userId, int siteId)
        {
            var voltmeter = new VoltmeterReadings
            {
                VoltmeterId = 170,
                VoltageP1 = 242,
                VoltageP2 = 242,
                VoltageP3 = 242,
                Timestamp = "212121321"
            };
            return voltmeter;
        }

        public UserActivityLogsResult GetUserActivityLogs(int userId, string startTimestamp, string endTimestamp)
        {
            var userActivity = new UserActivityLogsResult
            {
                UserId = userId,
                activities = new Activities
                {
                    ActivityId = 1,
                    ActivityDescription = "Some Heroes",
                    Timestamp = "21212122"
                }
            };
            return userActivity;
        }

        public ScheduleLogsResult GetSchedules(int userId, int pumpId, string startTimestamp, string endTimestamp)
        {
            var schedule = new ScheduleLogsResult
            {
                UserId = 123,
                SiteId = 123,
                PumpId = 123,
                Schedule = new Schedules
                {
                    RecordId = 1,
                    Status = 0,
                    StartTimestamp = "21212122",
                    EndTimestamp = "21212121"
                }
            };

            return schedule;
        }

        public PumpStatus GetPumpStatus(int userId, int pumpId)
        {
            var pumpStatus = new PumpStatus
            {
                PumpId = 1,
                PmpStatus = -1,
                RAmp = 12,
                BAmp = 123,
                YVoltage = 242,
                RVoltage = 222,
                BVoltage = 235,
                LastUpdatedTimestamp = "11123123112"
            };
            return pumpStatus;
        }

        public GensetMotorStatus GetGensetMotorStatus(int userId, int pumpId)
        {
            var gensetMotorStatus = new GensetMotorStatus
            {
                PumpId = 1,
                Motor = new Motor
                {
                    MotorId = 2,
                    MotorStatus = 0
                },
                Genset = new Genset
                {
                    GensetId = 12213,
                    GensetStatus = 1
                }
            };
            return gensetMotorStatus;
        }

        public bool UpdateGenset(int userId, int pumpId, int action)
        {
            bool isSuccess = true;

            return isSuccess;
        }

        public bool UpdateMotor(int userId, int pumpId, int action)
        {
            bool isSuccess = true;

            return isSuccess;
        }

        public bool CreateSchedule(int userId, int pumpId, string startTime, string endTime)
        {
            bool isSuccess = true;

            return isSuccess;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LoggedIn
    {
        private static string username;
        private static string loginStatus;
        public static string Username { get { return username; } }
        public static string LoginStatus
        {
            get
            {
                if(loginStatus==null)
                {
                    SetStatus();
                }
                return loginStatus;
            }
        }
        private static void SetStatus()
        {
            loginStatus = "Not Logged in";
        }
        public LoggedIn()
        {
            if(LoginStatus != null)
            {
                if (LoginStatus.Contains("Not Logged in")) SetStatus();

            }
        }
        internal LoggedIn(string LoginName)
        {
            username = LoginName;
            loginStatus = "Logged in as:" + username;
        }
        public static void LogOutSource()
        {
            username = null;
            SetStatus();
        }
        internal static bool IsLoggedIn_()
        {
            if (LoginStatus == null) new LoggedIn();
            return !LoginStatus.Contains("Not Logged in"); }
    }
}

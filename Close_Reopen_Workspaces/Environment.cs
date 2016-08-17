using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using System.Data;

namespace Close_Reopen_Workspaces
{
    static class Environment
    {
        static private string dbAutoProcessorConnectionString = string.Empty;

        static private int maxRetryTimes = 3;

        static private string executionName = "Close_Reopen_Workspaces";

        static private string eventLogName = "CloseReopenWorkspaces";

        static private string userName = "ardatta";

        static private string domainName = "Northamerica";

        static public string DBAutoProcessorConnectionString
        {
            get { return dbAutoProcessorConnectionString; }
        }

        static public int MaxRetryTimes
        {
            get { return maxRetryTimes; }
        }

        static public string ExecutionName
        {
            get { return executionName; }
        }

        static public string EventLogName
        {
            get { return eventLogName; }
        }

        static public string UserName
        {
            get { return userName; }
        }

        static public string DomainName
        {
            get { return domainName; }
        }

        static Environment()
        {
            // get auto processor connection string from app.config.
            dbAutoProcessorConnectionString = ConfigurationManager.ConnectionStrings["AutoProcessor"].ConnectionString;

            // get max retry times from app.config.
            string maxRetryTimesStr = ConfigurationManager.AppSettings["MaxRetryTimes"];
            if (!string.IsNullOrEmpty(maxRetryTimesStr))
            {
                int.TryParse(maxRetryTimesStr, out maxRetryTimes);
            }

            // get execution name from app.config.
            executionName = ConfigurationManager.AppSettings["ExecutionName"];

            // get event log name from app.config.
            eventLogName = ConfigurationManager.AppSettings["EventLogName"];

            // get user name from app.config
            userName = ConfigurationManager.AppSettings["UserName"];

            // get domain name from app.config
            domainName = ConfigurationManager.AppSettings["DomainName"];
        }
    }
}

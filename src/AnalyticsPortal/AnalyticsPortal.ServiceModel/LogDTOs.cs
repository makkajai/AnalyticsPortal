using System;
using System.Collections.Generic;
using ServiceStack.ServiceHost;

namespace AnalyticsPortal.ServiceModel
{
    public class LogResource
    {
        public DateTime Date { get; set; }

        public String FormattedDate
        {
            get { return Date.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        public int Duration { get; set; }

        public string Login { get; set; }

        public string BoardName { get; set; }

        public int Level { get; set; }

        public int SubLevel { get; set; }

        public int Status { get; set; }
    }

    public class LogResources : List<LogResource>
    {
    }

    /// <summary>
    /// Represents a message for getting Log resources
    /// </summary>
    [Route("/internal/dashboard/logs/", "GET")]
    public class LogRequest
    {
    }
}

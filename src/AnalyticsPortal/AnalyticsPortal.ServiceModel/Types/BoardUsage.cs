using System;

namespace AnalyticsPortal.ServiceModel.Types
{
    public class BoardUsage 
    {
        public DateTime LastPlayedDate { get; set; }

        public int DurationPlayed { get; set; }

        public string BoardName { get; set; }

        public string Description { get; set; }
    }
}
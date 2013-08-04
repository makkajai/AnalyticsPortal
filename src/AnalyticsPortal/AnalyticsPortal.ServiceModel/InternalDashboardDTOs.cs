using System;
using System.Collections.Generic;
using System.Linq;
using AnalyticsPortal.ServiceModel.Types;
using ServiceStack.ServiceHost;

namespace AnalyticsPortal.ServiceModel
{
    [Route("/internal/dashboard/", "GET")]
    public class InternalDashboardRequest 
    {
    }

    public class InternalDashboardResponse
    {
        public double Stickiness
        {
            get { return ActiveRegistrations*100.00/ConvertedRegistrations; }
        }

        public double AverageTimePerLogIn { get; set; }

        public double ConversionPercentage { get { return ConvertedRegistrations*100.00/TotalRegistrations; } }

        public int ActiveRegistrations
        {
            get
            {
                return
                    StudentUsageData.Count(p => p.LastPlayedDate != null && p.FirstPlayedDate != null &&
                        p.LastPlayedDate > DateTime.Now.AddDays(-5) &&
                        p.LastPlayedDate.Value.Subtract(p.FirstPlayedDate.Value).TotalHours > 24); //just to ensure new conversions are not considered in stickiness
            }
        }

        public int ConvertedRegistrations
        {
            get { return StudentUsageData.Count(p => p.LastPlayedDate != null); }
        }

        public int TotalRegistrations { get { return StudentUsageData.Count(); }}

        public IEnumerable<StudentUsage> StudentUsageData { get; set; }

        public IEnumerable<ActiveStudentsTrend> ActiveStudentsTrendData { get; set; }

        public IEnumerable<BoardUsage> BoardUsageData { get; set; } 
    }
}

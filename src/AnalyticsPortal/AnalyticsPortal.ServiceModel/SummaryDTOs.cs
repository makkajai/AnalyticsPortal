using ServiceStack.ServiceHost;

namespace AnalyticsPortal.ServiceModel
{
    [Route("/summary/{StudentLogin}", "GET")]
    public class SummaryRequest
    {
        public string StudentLogin { get; set; }
    }
}

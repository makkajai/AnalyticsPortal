using ServiceStack.ServiceHost;

namespace AnalyticsPortal.ServiceModel
{
    [Route("/summary", "GET")]
    public class SummaryRequest
    {
        public string StudentLogin { get; set; }
    }
}

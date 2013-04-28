using AnalyticsPortal.ServiceModel;
using AnalyticsPortal.Web.Helpers;
using ServiceStack.ServiceInterface;

namespace AnalyticsPortal.Web
{
    public class SummaryService : Service
    {
        public object Get(SummaryRequest request)
        {
            return SummaryData.GetSummary(request.StudentLogin, 5);
        }
    }
}
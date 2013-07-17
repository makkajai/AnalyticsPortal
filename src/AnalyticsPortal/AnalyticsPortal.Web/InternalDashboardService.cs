using AnalyticsPortal.ServiceModel;
using AnalyticsPortal.Web.Helpers;
using ServiceStack.ServiceInterface;

namespace AnalyticsPortal.Web
{
    [DefaultView("InternalDashboard")]
    public class InternalDashboardService : Service
    {
        public object Get(StudentsUsageRequest request)
        {
            return InternalDashboardData.GetStudentUsageData();
        }
    }
}
using AnalyticsPortal.ServiceModel;
using AnalyticsPortal.Web.Helpers;
using ServiceStack.ServiceInterface;

namespace AnalyticsPortal.Web
{
    [DefaultView("Dashboard")]
    [Authenticate]
    public class DashboardService : Service
    {
        public object Get(StudentsRequest request)
        {
            //depends on the logged in data for identifying user
            var session = this.GetSession();
            return DashboardData.GetStudents(session.UserName);
        }
    }
}
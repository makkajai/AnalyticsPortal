using AnalyticsPortal.ServiceModel;
using AnalyticsPortal.Web.Helpers;
using ServiceStack.ServiceInterface;

namespace AnalyticsPortal.Web
{
    [DefaultView("InternalDashboard")]
    public class InternalDashboardService : Service
    {
        public object Get(InternalDashboardRequest request)
        {
            return new InternalDashboardResponse
                {
                    AverageTimePerLogIn = InternalDashboardData.GetAverageTimePerLogin(),
                    StudentUsageData = InternalDashboardData.GetStudentUsageData(),
                    ActiveStudentsTrendData = InternalDashboardData.GetActiveStudentsData(),
                    BoardUsageData = InternalDashboardData.GetBoardUsageData()
                };
        }

        public object Get(LogRequest request)
        {
            var response = LogData.Get();
            return response;
        }
    }
}
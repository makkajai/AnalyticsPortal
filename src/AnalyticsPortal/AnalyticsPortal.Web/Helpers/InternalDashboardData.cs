using System.Collections.Generic;
using AnalyticsPortal.ServiceModel.Types;
using Dapper;

namespace AnalyticsPortal.Web.Helpers
{
    public class InternalDashboardData
    {
        /// <summary>
        /// Query to get the student usage for all active students
        /// </summary>
        public const string StudentsUsageQuery =
        @"select max(date) as LastPlayedDate, case when count(1) > 1 then count(1) else 0 end as LogCount, s.login as Login, FirstName, LastName
        from students s left outer join logs l on l.student_id = s.student_id
        where s.student_id > 5
        group by s.login, firstname, lastname
        order by lastplayeddate desc";

        public static IEnumerable<StudentUsage> GetStudentUsageData()
        {
            using(var conn = DbHelper.GetConnection())
            {
                return conn.Query<StudentUsage>(StudentsUsageQuery);
            }
        }
    }
}
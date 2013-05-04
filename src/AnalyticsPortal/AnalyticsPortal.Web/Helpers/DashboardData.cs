using System.Collections.Generic;
using AnalyticsPortal.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace AnalyticsPortal.Web.Helpers
{
    public class DashboardData
    {
        /// <summary>
        /// Query to get the students for a particular user
        /// </summary>
        public const string StudentsForUserQuery =
        @"select s.* 
          from students s inner join
               usertostudents uts on uts.studentlogin = s.login
         where uts.username = @username";

        public static IEnumerable<Student> GetStudents(string username)
        {
            using(var conn = DbHelper.GetConnection())
            {
                return conn.Query<Student>(
                        StudentsForUserQuery, new {username});
            }
        }
    }
}
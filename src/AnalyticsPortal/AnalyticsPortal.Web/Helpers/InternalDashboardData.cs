using System.Collections.Generic;
using System.Linq;
using AnalyticsPortal.ServiceModel.Types;
using ServiceStack.OrmLite;


namespace AnalyticsPortal.Web.Helpers
{
    public class InternalDashboardData
    {
        private static IEnumerable<T> QueryToList<T>(string query)
        {
            using (var conn = DbHelper.GetConnection())
            {
                return conn.Query<T>(query);
            }
        }
        /// <summary>
        /// Query to get the student usage for all active students
        /// </summary>
        public const string StudentsUsageQuery =
        @"select max(date) as LastPlayedDate, min(date) as FirstPlayedDate, sum(duration) as TotalTimeSpent, case when count(1) > 1 then count(1) else 0 end as LogCount, s.login as Login, FirstName, LastName
        from students s left outer join logs l on l.student_id = s.student_id
        where s.student_id > 5
        group by s.login, firstname, lastname
        order by case when max(date) is null then '0001-01-01' else max(date) end desc";

        public static IEnumerable<StudentUsage> GetStudentUsageData()
        {
            return QueryToList<StudentUsage>(StudentsUsageQuery);
        }

        public const string ActiveStudentsTrendQuery =
            @"select count(1) as ActiveStudents, Date
    from
    (select distinct student_id, date_trunc('day', date) as date
    from logs
    where student_id > 5) as t
    group by date
    order by date desc";

        public static IEnumerable<ActiveStudentsTrend> GetActiveStudentsData()
        {
            return QueryToList<ActiveStudentsTrend>(ActiveStudentsTrendQuery);
        }


        public const string BoardUsageDataQuery =
            @" select b.name as boardname, b.description, sum(l.duration) DurationPlayed, max(date) lastplayedDate
 from logs l 
 inner join boards b on b.board_id = l.board_id
 where student_id > 5
 group by b.board_id, b.name, b.description
 order by DurationPlayed desc
 ";

        public static IEnumerable<BoardUsage> GetBoardUsageData()
        {
            return QueryToList<BoardUsage>(BoardUsageDataQuery);
        }

        public const string AverageTimePerLoginQuery =
            @"select avg(duration) from 
            (select date_trunc('day', date), s.student_id, sum(duration) as duration
            from logs l inner join
                 students s on s.student_id = l.student_id
            where s.student_id > 5
            group by s.student_id, date_trunc('day', date)) as t";


        public static double GetAverageTimePerLogin()
        {
            using(var db = DbHelper.GetConnection())
            {
                return db.SqlScalar<double>(AverageTimePerLoginQuery);
            }
        }
    }
}
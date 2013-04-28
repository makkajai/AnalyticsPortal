using System.Collections.Generic;
using AnalyticsPortal.ServiceModel.Types;
using Dapper;

namespace AnalyticsPortal.Web.Helpers
{
    public class SummaryData
    {
        /// <summary>
        /// Query to get the top n log entries
        /// </summary>
        public const string ActivityResultsQuery =
            @"WITH topnlogs as  
              (select date, duration, l.student_id, board_id, level, sublevel, status, comment,
                     ROW_NUMBER() OVER (PARTITION BY board_id ORDER BY DATE DESC) as RowNum
                     from analytics.logs l inner join
                          students s on s.student_id = l.student_id
                     where login = @login
              )
             select sum(duration) as duration, max(level) as maxlevel, sum(status) as correct, sum(1-status) as incorrect, @top as LastX,
             a.activity_id as Id, a.name, a.difficulty, a.logo, a.title, a.description, a.prerequisite, a.goal, 
             s.student_id as Id, s.login, s.lastname, s.firstname
             from topnlogs l
             inner join analytics.activities a on board_id = activity_id
             inner join analytics.students s on s.student_id = l.student_id
             where RowNum <= @top
             group by board_id, name, title, logo, 
             a.activity_id, a.name, a.difficulty, a.logo, a.title, a.description, a.prerequisite, a.goal,
             s.student_id, s.login, s.lastname, s.firstname
        ";

        public static IEnumerable<ActivitySummaryResult> GetSummary(string login, int lastXNum)
        {
            using(var conn = DbHelper.GetConnection())
            {
                //use Dapper's multi-mapping feature to get referenced objects also populated at once. 
                return
                    conn.Query<ActivitySummaryResult, Activity, Student, ActivitySummaryResult>(
                        ActivityResultsQuery,
                        (result, activity, student) =>
                            {
                                result.Activity = activity;
                                result.Student = student;
                                return result;
                            }, new {login, top = lastXNum});
            }
        }
    }
}
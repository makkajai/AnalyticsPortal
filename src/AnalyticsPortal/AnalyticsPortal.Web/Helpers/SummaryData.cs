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
                     from logs l inner join
                          students s on s.student_id = l.student_id
                     where login = @login
              )
             select sum(duration) as duration, max(level) as maxlevel, sum(status) as correct, sum(1-status) as incorrect, @top as LastX,
             b.board_id as Id, b.name, b.difficulty, b.logo, b.title, b.description, b.prerequisite, b.goal, 
             s.student_id as Id, s.login, s.lastname, s.firstname
             from topnlogs l
             inner join boards b on l.board_id = b.board_id
             inner join students s on s.student_id = l.student_id
             where RowNum <= @top
             group by b.board_id, b.name, b.difficulty, b.logo, b.title, b.description, b.prerequisite, b.goal,
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
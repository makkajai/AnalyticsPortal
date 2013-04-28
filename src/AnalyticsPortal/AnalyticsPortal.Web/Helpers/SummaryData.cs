using System;
using System.Collections.Generic;
using AnalyticsPortal.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace AnalyticsPortal.Web.Helpers
{
    public class SummaryData
    {
        /// <summary>
        /// Query to get the top n log entries
        /// </summary>
        public const string ActivityResultsQuery =
            @"select * from 
             (WITH topnlogs as  
              (select date, duration, l.student_id, board_id, level, sublevel, status, comment,
                     ROW_NUMBER() OVER (PARTITION BY board_id ORDER BY DATE DESC) as RowNum
                     from analytics.logs l inner join
                          students s on s.student_id = l.student_id
                     where login = '{0}'
              )
             select sum(duration) as duration, max(level) as maxlevel, sum(status) as correct, sum(1-status) as incorrect,
             a.*, 
             s.*,
             {1} as LastX
             from topnlogs l
             inner join analytics.activities a on board_id = activity_id
             inner join analytics.students s on s.student_id = l.student_id
             where RowNum <= {1}
             group by board_id, name, title, logo, 
             a.activity_id, a.name, a.difficulty, a.logo, a.title, a.description, a.prerequisite, a.goal,
             s.student_id, s.login, s.lastname, s.firstname) as t
        ";

        public static List<ActivitySummaryResult> GetSummary(string login, int lastXNum)
        {
            using(var conn = DbHelper.GetConnection())
            {
                Console.WriteLine(ActivityResultsQuery, login, lastXNum);
                return conn.Query<ActivitySummaryResult>(string.Format(ActivityResultsQuery, login, lastXNum));
            }
        }
    }
}
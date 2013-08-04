using System.Collections.Generic;
using AnalyticsPortal.ServiceModel;
using ServiceStack.OrmLite;

namespace AnalyticsPortal.Web.Helpers
{
    public class LogData
    {
        private const string LogsQuery =
            "select Date, Duration, Level, Status, SubLevel, s.Login, b.Name as BoardName " +
            "from logs l " +
            "inner join students s on l.student_id = s.student_id " +
            "inner join boards b on l.board_id = b.board_id " +
            "where s.student_id > 5 " +
            "order by l.date desc";

        public static List<LogResource> Get()
        {
            using (var db = DbHelper.GetConnection())
            {
                return db.Select<LogResource>(LogsQuery);
            }
        }

    }
}
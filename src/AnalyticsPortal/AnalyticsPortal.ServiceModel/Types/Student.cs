using ServiceStack.DataAnnotations;

namespace AnalyticsPortal.ServiceModel.Types
{
    [Alias("students")]
    public class Student
    {
        [Alias("student_id"), PrimaryKey]
        public int Id { get; set; }

        public string Login { get; set; }

        [Alias("last_name")]
        public string LastName { get; set; }

        [Alias("first_name")]
        public string FirstName { get; set; }
    }
}

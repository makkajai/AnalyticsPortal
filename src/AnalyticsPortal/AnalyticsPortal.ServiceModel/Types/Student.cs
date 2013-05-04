using ServiceStack.DataAnnotations;

namespace AnalyticsPortal.ServiceModel.Types
{
    [Alias("students")]
    public class Student
    {
        [Alias("student_id"), PrimaryKey]
        public int Id { get; set; }

        public string Login { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Ignore]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
}

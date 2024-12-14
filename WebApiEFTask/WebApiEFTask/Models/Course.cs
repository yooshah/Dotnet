namespace WebApiEFTask.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
    
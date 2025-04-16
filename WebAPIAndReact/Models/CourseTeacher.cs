namespace WebAPIAndReact.Models
{
    public class CourseTeacher
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
    }
}

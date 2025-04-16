namespace WebAPIAndReact.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Degree { get; set; }
        public byte[]? Photo { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; }

    }
}

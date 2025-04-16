namespace WebAPIAndReact.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DatePublish { get; set; }
        public byte[]? CoverPhoto { get; set; }
        
        public Price PricePromotion { get; set; }  
        public ICollection<Comment> Comments { get; set; }

        public ICollection<CourseTeacher> CourseTeachers { get; set; }

    }
}

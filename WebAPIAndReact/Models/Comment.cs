namespace WebAPIAndReact.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Student { get; set; }
        public int Point { get; set; }
        public string ComentText { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

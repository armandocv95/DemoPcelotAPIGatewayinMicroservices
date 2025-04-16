using Microsoft.EntityFrameworkCore;
using WebAPIAndReact.Models;

namespace WebAPIAndReact.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseTeacher>()
                .HasKey(ct => new { ct.TeacherId, ct.CourseId }); 
        }

    }
}

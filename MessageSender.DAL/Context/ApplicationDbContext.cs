using MessageSender.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageSender.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<SemestrDate> SemestrDates { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}

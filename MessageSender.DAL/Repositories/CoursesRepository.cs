using MessageSender.DAL.Context;
using MessageSender.DAL.Entities;
using MessageSender.DAL.Repositories.Base;

namespace MessageSender.DAL.Repositories
{
    public class CoursesRepository : Repository<Course>
    {
        public CoursesRepository(ApplicationDbContext db) : base(db) { }
    }
}

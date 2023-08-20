using MessageSender.DAL.Context;
using MessageSender.DAL.Entities;
using MessageSender.DAL.Repositories.Base;

namespace MessageSender.DAL.Repositories
{
    public class SemestrDatesRepository : Repository<SemestrDate>
    {
        public SemestrDatesRepository(ApplicationDbContext db) : base(db) { }
    }
}

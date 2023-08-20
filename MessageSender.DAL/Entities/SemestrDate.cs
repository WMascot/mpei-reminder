using MessageSender.DAL.Entities.Base;

namespace MessageSender.DAL.Entities
{
    public class SemestrDate: Entity
    {
        public DateOnly StartDate { get; set; }
    }
}

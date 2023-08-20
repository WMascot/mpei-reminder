using MessageSender.DAL.Interfaces;

namespace MessageSender.DAL.Entities.Base
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
    }
}

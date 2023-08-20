using MessageSender.DAL.Entities.Base;

namespace MessageSender.DAL.Entities
{
    public class Course : Entity
    {
        public int Number { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

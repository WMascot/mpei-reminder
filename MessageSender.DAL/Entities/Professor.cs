using MessageSender.DAL.Entities.Base;

namespace MessageSender.DAL.Entities
{
    public class Professor: Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? SecondName { get; set; }
        public string FirstEmail { get; set; }
        public string? SecondEmail { get; set; }
    }
}

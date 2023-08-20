using MessageSender.DAL.Entities.Base;

namespace MessageSender.DAL.Entities
{
    public class Student: Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? SecondName { get; set; }
        public string FirstEmail { get; set; }
        public string? SecondEmail { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}

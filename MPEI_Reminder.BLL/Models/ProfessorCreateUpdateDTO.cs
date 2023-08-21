namespace MPEI_Reminder.BLL.Models
{
    public class ProfessorCreateUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? SecondName { get; set; }
        public string FirstEmail { get; set; }
        public string? SecondEmail { get; set; }
    }
}

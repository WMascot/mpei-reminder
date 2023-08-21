using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;
using MPEI_Reminder.BLL.Models;

namespace MPEI_Reminder.BLL.Services
{
    public class StudentsService
    {
        private readonly IRepository<Student> _studentsRepository;
        public StudentsService(IRepository<Student> strudentsRepository)
        {
            _studentsRepository = strudentsRepository;
        }
        public async Task<StudentDTO?> GetStudentAsync(int id)
        {
            var student = await _studentsRepository.GetAsync(id);
            if (student is null) return null;
            var studentDTO = StudentToDTO(student);
            return studentDTO;
        }
        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            var students = _studentsRepository.Items.Select(x => StudentToDTO(x)).ToList();
            return students;
        }
        public async Task<List<StudentDTO>> GetCourseStudentsAsync(int courseId)
        {
            var students = _studentsRepository.Items.Where(x => x.CourseId == courseId).Select(x => StudentToDTO(x)).ToList();
            return students;
        }
        public async Task<StudentDTO> CreateStudentAsync(StudentCreateUpdateDTO createUpdateStudentDTO)
        {
            var student = CreateUpdateStudentDTOToStudent(createUpdateStudentDTO);
            var createdStudent = await _studentsRepository.AddAsync(student);
            var createdStudentDTO = StudentToDTO(createdStudent);
            return createdStudentDTO;
        }
        public async Task<StudentDTO> UpdateStudentAsync(StudentCreateUpdateDTO createUpdateStudentDTO, int id)
        {
            var student = CreateUpdateStudentDTOToStudent(createUpdateStudentDTO, id);
            var updatedStudent = await _studentsRepository.UpdateAsync(student);
            var updatedStudentDTO = StudentToDTO(updatedStudent);
            return updatedStudentDTO;
        }
        public async Task RemoveStudentAsync(int id) =>
            await _studentsRepository.DeleteAsync(id);
        private static Student CreateUpdateStudentDTOToStudent(StudentCreateUpdateDTO createUpdateStudentDTO, int? id = null) =>
            new Student
            {
                Id = id ?? new Random().Next(),
                Name = createUpdateStudentDTO.Name,
                Surname = createUpdateStudentDTO.Surname,
                SecondName = createUpdateStudentDTO.SecondName,
                FirstEmail = createUpdateStudentDTO.FirstEmail,
                SecondEmail = createUpdateStudentDTO.SecondEmail,
                CourseId = createUpdateStudentDTO.CourseId
            };
        private static StudentDTO StudentToDTO(Student student) =>
            new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                SecondName = student.SecondName,
                FirstEmail = student.FirstEmail,
                SecondEmail = student.SecondEmail,
                CourseId = student.CourseId,
            };
    }
}

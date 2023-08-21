using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;
using MPEI_Reminder.BLL.Models;

namespace MPEI_Reminder.BLL.Services
{
    public class CoursesService
    {
        private readonly IRepository<Course> _coursesRepository;

        public CoursesService(IRepository<Course> coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public async Task<List<CourseDTO>> GetCoursesAsync()
        {
            var courses = _coursesRepository.Items.Select(x => CourseToDTO(x)).ToList();
            return courses;
        }
        public async Task<CourseDTO?> GetCourseAsync(int id)
        {
            var course = await _coursesRepository.GetAsync(id);
            if (course is null) return null;
            var courseDTO = CourseToDTO(course);
            return courseDTO;
        }
        private static CourseDTO CourseToDTO(Course course) =>
            new CourseDTO
            {
                Id = course.Id,
                Number = course.Number
            };
    }
}

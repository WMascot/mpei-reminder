using Microsoft.AspNetCore.Mvc;
using MPEI_Reminder.BLL.Services;

namespace MPEI_Reminder.WEB.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly CoursesService _coursesService;

        public CourseController(ILogger<CourseController> logger, CoursesService coursesService)
        {
            _logger = logger;
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoursesAsync()
        {
            var courses = await _coursesService.GetCoursesAsync();
            return Ok(courses);
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetCourseAsync(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            var course = await _coursesService.GetCourseAsync(id.Value);
            if (course is null) return NotFound();
            return Ok(course);
        }
    }
}

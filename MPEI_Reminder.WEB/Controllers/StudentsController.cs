using Microsoft.AspNetCore.Mvc;
using MPEI_Reminder.BLL.Models;
using MPEI_Reminder.BLL.Services;
using System.Text.RegularExpressions;

namespace MPEI_Reminder.WEB.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentsService _studentsService;

        public StudentsController(ILogger<StudentsController> logger, StudentsService studentsService)
        {
            _logger = logger;
            _studentsService = studentsService;
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> GetStudentAsync(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            var student = await _studentsService.GetStudentAsync(id.Value);
            if (student is null) return NotFound();
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _studentsService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet]
        [Route("course/{courseId}")]
        public async Task<IActionResult> GetCourseStudentsAsync(int? courseId)
        {
            var students = await _studentsService.GetCourseStudentsAsync(courseId.Value);
            return Ok(students);
        }

        private Regex emailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(StudentCreateUpdateDTO studentCreateUpdateDTO)
        {
            var firstEmail = studentCreateUpdateDTO.FirstEmail;
            var secondEmail = studentCreateUpdateDTO.SecondEmail;

            if (!emailRegex.IsMatch(firstEmail)) return BadRequest();
            if (secondEmail is not null && !emailRegex.IsMatch(secondEmail)) return BadRequest();

            var student = await _studentsService.CreateStudentAsync(studentCreateUpdateDTO);
            return CreatedAtAction(nameof(CreateStudentAsync), student);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateStudentAsync(int? id, StudentCreateUpdateDTO studentCreateUpdateDTO)
        {
            if (id is null || id <= 0) return BadRequest();

            var student = await _studentsService.GetStudentAsync(id.Value);
            if (student is null) return NotFound();

            var firstEmail = studentCreateUpdateDTO.FirstEmail;
            var secondEmail = studentCreateUpdateDTO.SecondEmail;

            if (!emailRegex.IsMatch(firstEmail)) return BadRequest();
            if (secondEmail is not null && !emailRegex.IsMatch(secondEmail)) return BadRequest();

            var updatedStudent = await _studentsService.UpdateStudentAsync(studentCreateUpdateDTO, id.Value);
            return Ok(updatedStudent);
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> RemoveStudentAsync(int? id)
        {
            if (id is null || id <= 0) return BadRequest();
            await _studentsService.RemoveStudentAsync(id.Value);
            return Ok();
        }
    }
}

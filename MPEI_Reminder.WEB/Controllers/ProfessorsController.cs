using Microsoft.AspNetCore.Mvc;
using MPEI_Reminder.BLL.Models;
using MPEI_Reminder.BLL.Services;
using System.Text.RegularExpressions;

namespace MPEI_Reminder.WEB.Controllers
{
    [Route("professor")]
    [ApiController]
    public class ProfessorsController : Controller
    {
        private readonly ILogger<ProfessorsController> _logger;
        private readonly ProfessorsService _professorsService;

        public ProfessorsController(ILogger<ProfessorsController> logger, ProfessorsService professorsService)
        {
            _logger = logger;
            _professorsService = professorsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessorAsync()
        {
            var professor = await _professorsService.GetProfessorAsync();
            if (professor is null) return NotFound();
            return Ok(professor);
        }

        private Regex emailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        [HttpPost]
        public async Task<IActionResult> CreateProfessorAsync(ProfessorCreateUpdateDTO professorCreateUpdateDTO)
        {
            var firstEmail = professorCreateUpdateDTO.FirstEmail;
            var secondEmail = professorCreateUpdateDTO.SecondEmail;

            if (!emailRegex.IsMatch(firstEmail)) return BadRequest();
            if (secondEmail is not null && !emailRegex.IsMatch(secondEmail)) return BadRequest();

            var professor = await _professorsService.CreateProfessorAsync(professorCreateUpdateDTO);
            return CreatedAtAction(nameof(CreateProfessorAsync), professor);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> UpdateProfessorAsync(int? id, ProfessorCreateUpdateDTO professorCreateUpdateDTO)
        {
            if (id is null || id <= 0) return BadRequest();

            var firstEmail = professorCreateUpdateDTO.FirstEmail;
            var secondEmail = professorCreateUpdateDTO.SecondEmail;

            if (!emailRegex.IsMatch(firstEmail)) return BadRequest();
            if (secondEmail is not null && !emailRegex.IsMatch(secondEmail)) return BadRequest();

            var professor = await _professorsService.UpdateProfessorAsync(professorCreateUpdateDTO, id.Value);
            return Ok(professor);
        }
    }
}

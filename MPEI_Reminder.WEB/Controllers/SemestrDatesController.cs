using Microsoft.AspNetCore.Mvc;
using MPEI_Reminder.BLL.Models;
using MPEI_Reminder.BLL.Services;

namespace MPEI_Reminder.WEB.Controllers
{
    public class SemestrDatesController : Controller
    {
        private readonly ILogger<SemestrDatesController> _logger;
        private readonly SemestrDatesService _semestrDatesService;

        public SemestrDatesController(ILogger<SemestrDatesController> logger, SemestrDatesService semestrDatesService)
        {
            _logger = logger;
            _semestrDatesService = semestrDatesService;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentSemestrDateAsync()
        {
            var currentSemestrDate = await _semestrDatesService.GetCurrentSemestrDateAsync();
            if (currentSemestrDate is null) return NotFound();
            return Ok(currentSemestrDate);
        }

        [HttpPost]
        public async Task<IActionResult> SetCurrentSemestrDate(SemestrDateCreateUpdateDTO semestrDateCreateUpdateDTO)
        {
            var currentSemestrDate = await _semestrDatesService.GetCurrentSemestrDateAsync();
            if (currentSemestrDate is not null) await _semestrDatesService.RemoveSemestrDateAsync(currentSemestrDate.Id);
            var newCurrentSemestrDate = await _semestrDatesService.SetCurrentSemestrDateAsync(semestrDateCreateUpdateDTO.StartDate);
            return CreatedAtAction(nameof(SetCurrentSemestrDate), newCurrentSemestrDate);
        }
    }
}

using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;
using MPEI_Reminder.BLL.Models;

namespace MPEI_Reminder.BLL.Services
{
    public class SemestrDatesService
    {
        private readonly IRepository<SemestrDate> _semestrDatesRepository;
        public SemestrDatesService(IRepository<SemestrDate> semestrDatesRepository)
        {
            _semestrDatesRepository = semestrDatesRepository;
        }
        public async Task<SemestrDateDTO?> GetCurrentSemestrDateAsync()
        {
            var currentSemestrDate = _semestrDatesRepository.Items.OrderBy(x => x.Id).LastOrDefault();
            if (currentSemestrDate is null) return null;
            var currentSemestrDateDTO = SemestrDateToDTO(currentSemestrDate);
            return currentSemestrDateDTO;
        }
        public async Task<SemestrDateDTO> SetCurrentSemestrDateAsync(DateTime startDateTime)
        {
            var semestrDate = SemestrDateFromDateTime(startDateTime);
            var createdSemestrDate = await _semestrDatesRepository.AddAsync(semestrDate);
            var createdSemestrDateDTO = SemestrDateToDTO(createdSemestrDate);
            return createdSemestrDateDTO;
        }
        public async Task RemoveSemestrDateAsync(int id) =>
            await _semestrDatesRepository.DeleteAsync(id);
        private static SemestrDate SemestrDateFromDateTime(DateTime startDateTime) =>
            new SemestrDate
            {
                Id = new Random().Next(),
                StartDate = DateOnly.FromDateTime(startDateTime)
            };
        private static SemestrDateDTO SemestrDateToDTO(SemestrDate semestrDate) =>
            new SemestrDateDTO
            {
                Id = semestrDate.Id,
                StartDate = semestrDate.StartDate.ToDateTime(TimeOnly.MinValue)
            };
    }
}

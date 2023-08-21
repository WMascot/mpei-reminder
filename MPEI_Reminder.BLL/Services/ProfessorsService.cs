using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;
using MPEI_Reminder.BLL.Models;

namespace MPEI_Reminder.BLL.Services
{
    public class ProfessorsService
    {
        private readonly IRepository<Professor> _professorsRepository;
        public ProfessorsService(IRepository<Professor> professorsRepository)
        {
            _professorsRepository = professorsRepository;
        }
        public async Task<ProfessorDTO?> GetProfessorAsync()
        {
            var professor = _professorsRepository.Items.FirstOrDefault();
            if (professor is null) return null;
            var professorDTO = ProfessorToDTO(professor);
            return professorDTO;
        }
        public async Task<ProfessorDTO> CreateProfessorAsync(ProfessorCreateUpdateDTO createUpdateProfessorDTO)
        {
            var professor = ProfessorCreateUpdateDTOToProfessor(createUpdateProfessorDTO);
            var createdProfessor = await _professorsRepository.AddAsync(professor);
            var createdProfessorDTO = ProfessorToDTO(createdProfessor);
            return createdProfessorDTO;
        }
        public async Task<ProfessorDTO> UpdateProfessorAsync(ProfessorCreateUpdateDTO createUpdateProfessorDTO, int id)
        {
            var professor = ProfessorCreateUpdateDTOToProfessor(createUpdateProfessorDTO, id);
            var updatedProfessor = await _professorsRepository.UpdateAsync(professor);
            var updatedProfessorDTO = ProfessorToDTO(updatedProfessor);
            return updatedProfessorDTO;
        }
        private Professor ProfessorCreateUpdateDTOToProfessor(ProfessorCreateUpdateDTO createUpdateProfessorDTO, int? id = null) =>
            new Professor
            {
                Id = id ?? 0,
                Name = createUpdateProfessorDTO.Name,
                Surname = createUpdateProfessorDTO.Surname,
                SecondName = createUpdateProfessorDTO.SecondName,
                FirstEmail = createUpdateProfessorDTO.FirstEmail,
                SecondEmail = createUpdateProfessorDTO.SecondEmail
            };
        private ProfessorDTO ProfessorToDTO(Professor professor) =>
            new ProfessorDTO
            {
                Id = professor.Id,
                Name = professor.Name,
                Surname = professor.Surname,
                SecondName = professor.SecondName,
                FirstEmail = professor.FirstEmail,
                SecondEmail = professor.SecondEmail
            };
    }
}

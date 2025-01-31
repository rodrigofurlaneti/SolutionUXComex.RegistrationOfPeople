using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto?> GetByIdAsync(int id);
        Task<int> AddAsync(PersonDto personDto);
        Task<bool> UpdateAsync(int id, PersonDto personDto);
        Task<bool> DeleteAsync(int id);
    }
}

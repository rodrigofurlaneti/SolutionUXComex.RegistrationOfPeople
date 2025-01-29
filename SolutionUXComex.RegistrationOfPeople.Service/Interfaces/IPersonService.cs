using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto?> GetByIdAsync(int id);
        Task AddAsync(PersonDto categoryDto);
        Task UpdateAsync(int id, PersonDto categoryDto);
        Task DeleteAsync(int id);
    }

}

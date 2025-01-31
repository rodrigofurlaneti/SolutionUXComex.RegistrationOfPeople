using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAsync();
        Task<AddressDto?> GetByIdAsync(int id);
        Task<List<AddressDto>> GetByPersonIdAsync(int personId);
        Task<int> AddAsync(AddressDto addressDto);
        Task<bool> UpdateAsync(int id, AddressDto addressDto);
        Task<bool> DeleteAsync(int id);
    }
}

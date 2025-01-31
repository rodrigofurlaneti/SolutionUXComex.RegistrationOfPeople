using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAsync();
        Task<AddressDto?> GetByIdAsync(int id);
        Task<int> AddAsync(AddressDto addressDto);
        Task<bool> UpdateAsync(int id, AddressDto addressDto);
        Task<bool> DeleteAsync(int id);
    }
}

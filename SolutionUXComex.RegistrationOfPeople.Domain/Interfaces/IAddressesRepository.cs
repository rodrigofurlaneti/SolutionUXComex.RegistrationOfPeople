using SolutionUXComex.RegistrationOfPeople.Domain.Entities;

namespace SolutionUXComex.RegistrationOfPeople.Domain.Interfaces
{
    public interface IAddressRepository : IRepositoryBase<AddressEntity>
    {
        Task<List<AddressEntity>> GetByPersonIdAsync(int personId); // Alterado para receber apenas o ID da pessoa

    }
}

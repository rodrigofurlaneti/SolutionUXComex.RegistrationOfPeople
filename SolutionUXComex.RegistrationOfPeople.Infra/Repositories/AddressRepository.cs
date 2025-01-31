using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class AddressRepository : RepositoryBase<AddressEntity>, IAddressRepository
    {
        public AddressRepository(IDbConnection dbConnection, ILogger<RepositoryBase<AddressEntity>> logger)
            : base(dbConnection, logger) { }
    }
}

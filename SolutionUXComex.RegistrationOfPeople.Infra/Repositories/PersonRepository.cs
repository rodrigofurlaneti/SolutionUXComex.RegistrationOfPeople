using System.Data;
using Dapper;
using Microsoft.Extensions.Logging;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class PersonRepository : RepositoryBase<PersonEntity>, IPersonRepository
    {
        public PersonRepository(IDbConnection dbConnection, ILogger<RepositoryBase<PersonEntity>> logger)
            : base(dbConnection, logger) { }
    }
}

using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Infra.Data;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;

namespace SolutionUXComex.RegistrationOfPeople.Infra.Repositories
{
    public class PersonRepository : RepositoryBase<PersonEntity>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}

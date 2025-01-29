using SolutionUXComex.RegistrationOfPeople.Service.Dtos;
using SolutionUXComex.RegistrationOfPeople.Service.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;

namespace SolutionUXComex.RegistrationOfPeople.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var persons = await _repository.GetAllAsync();
            return persons.Select(person => new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Cpf = person.Cpf,
                Phone = person.Phone,
                CreatedAt = person.CreatedAt,
                UpdatedAt = person.UpdatedAt,
                Active = person.Active
            });
        }

        public async Task<PersonDto?> GetByIdAsync(int id)
        {
            var personEntity = await _repository.GetByIdAsync(id);
            if (personEntity == null)
                return null;

            return SetPersonDto(personEntity);
        }

        public async Task<int> AddReturnIdAsync(PersonDto personDto)
        {
            var personEntity = SetPersonEntity_Insert(personDto);
            var entityId = await _repository.AddReturnIdAsync(personEntity);
            return entityId;
        }

        public async Task AddAsync(PersonDto PersonDto)
        {
            var PersonEntity = SetPersonEntity_Insert(PersonDto);
            await _repository.AddAsync(PersonEntity);
        }


        public async Task UpdateAsync(int id, PersonDto personDto)
        {
            var personEntity = await _repository.GetByIdAsync(id);
            if (personEntity == null)
                throw new ArgumentException($"Person with ID {id} not found");

            var updatedEntity = SetPersonEntity_Update(personEntity, personDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de PersonEntity para PersonDto
        private PersonDto SetPersonDto(PersonEntity person)
        {
            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Cpf = person.Cpf,
                Phone = person.Phone,
                CreatedAt = person.CreatedAt,
                UpdatedAt = person.UpdatedAt,
                Active = person.Active
            };
        }

        // Cria uma nova entidade para inserção
        private PersonEntity SetPersonEntity_Insert(PersonDto person)
        {
            return new PersonEntity
            {
                Id = person.Id,
                Name = person.Name,
                Cpf = person.Cpf,
                Phone = person.Phone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Active = person.Active
            };
        }

        // Atualiza uma entidade existente com novos dados
        private PersonEntity SetPersonEntity_Update(PersonEntity existingEntity, PersonDto personDto)
        {
            existingEntity.Id = personDto.Id;
            existingEntity.Name = personDto.Name;
            existingEntity.Cpf = personDto.Cpf;
            existingEntity.Phone = personDto.Phone;
            existingEntity.UpdatedAt = DateTime.Now;
            existingEntity.Active = personDto.Active;
            return existingEntity;
        }
    }
}

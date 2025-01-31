using SolutionUXComex.RegistrationOfPeople.Service.Dtos;
using SolutionUXComex.RegistrationOfPeople.Service.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Domain.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return persons.Select(PersonMapper.ToDto);
        }

        public async Task<PersonDto?> GetByIdAsync(int id)
        {
            var personEntity = await _repository.GetByIdAsync(id);
            return personEntity == null ? null : PersonMapper.ToDto(personEntity);
        }

        public async Task<int> AddAsync(PersonDto personDto)
        {
            personDto.CreatedAt = DateTime.Now;
            personDto.UpdatedAt = DateTime.Now;
            personDto.Active = true;
            var personEntity = PersonMapper.ToEntity(personDto);
            return await _repository.AddReturnIdAsync(personEntity);
        }

        public async Task<bool> UpdateAsync(int id, PersonDto personDto)
        {
            var personEntity = await _repository.GetByIdAsync(id);
            if (personEntity == null)
                return false;

            var updatedEntity = PersonMapper.ToEntity(personDto);
            updatedEntity.UpdatedAt = DateTime.Now;
            await _repository.UpdateAsync(updatedEntity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var personEntity = await _repository.GetByIdAsync(id);
            if (personEntity == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}

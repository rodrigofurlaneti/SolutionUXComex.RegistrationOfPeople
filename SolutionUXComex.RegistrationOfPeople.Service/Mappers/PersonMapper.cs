using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Mappers
{
    public static class PersonMapper
    {
        public static PersonEntity ToEntity(PersonDto dto)
        {
            return new PersonEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Cpf = dto.Cpf
            };
        }

        public static PersonDto ToDto(PersonEntity entity)
        {
            return new PersonDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                
                Cpf = entity.Cpf
            };
        }
    }
}

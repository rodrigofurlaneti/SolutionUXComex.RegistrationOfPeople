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
                Cpf = dto.Cpf,
                ZipCode = dto.ZipCode,
                Address = dto.Address,
                Number = dto.Number,
                Complement = dto.Complement,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                State = dto.State
            };
        }

        public static PersonDto ToDto(PersonEntity entity)
        {
            return new PersonDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Cpf = entity.Cpf,
                ZipCode = entity.ZipCode,
                Address = entity.Address,
                Number = entity.Number,
                Complement = entity.Complement,
                Neighborhood = entity.Neighborhood,
                City = entity.City,
                State = entity.State
            };
        }
    }
}

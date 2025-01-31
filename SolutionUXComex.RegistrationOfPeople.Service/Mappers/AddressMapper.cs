using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Service.Mappers
{
    public static class AddressMapper
    {

        public static AddressEntity ToEntity(AddressDto dto)
        {
            return new AddressEntity
            {
                Id = dto.Id,
                PersonId = dto.PersonId,
                ZipCode = dto.ZipCode,
                Address = dto.Address,
                Number = dto.Number,
                Complement = dto.Complement,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                State = dto.State
            };
        }

        public static AddressDto ToDto(AddressEntity entity)
        {
            return new AddressDto
            {
                Id = entity.Id,
                PersonId = entity.PersonId,
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

using SolutionUXComex.RegistrationOfPeople.Domain.Entities;
using SolutionUXComex.RegistrationOfPeople.Service.Dtos;
using System.Collections.Generic;
using System.Linq;

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
                State = dto.State,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                Active = dto.Active
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
                State = entity.State,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Active = entity.Active
            };
        }

        public static List<AddressDto> ToListDto(List<AddressEntity> entity)
        {
            List<AddressDto> listAddressDto = new List<AddressDto>();

            foreach (var item in entity)
            {
                var itemList = new AddressDto
                {
                    Id = item.Id,
                    PersonId = item.PersonId,
                    ZipCode = item.ZipCode,
                    Address = item.Address,
                    Number = item.Number,
                    Complement = item.Complement,
                    Neighborhood = item.Neighborhood,
                    City = item.City,
                    State = item.State,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    Active = item.Active
                };

                listAddressDto.Add(itemList);
            }

            return listAddressDto;
        }

        public static List<AddressEntity> ToListEntity(List<AddressDto> entity)
        {
            List<AddressEntity> listAddressEntity = new List<AddressEntity>();

            foreach (var item in entity)
            {
                var itemList = new AddressEntity
                {
                    Id = item.Id,
                    PersonId = item.PersonId,
                    ZipCode = item.ZipCode,
                    Address = item.Address,
                    Number = item.Number,
                    Complement = item.Complement,
                    Neighborhood = item.Neighborhood,
                    City = item.City,
                    State = item.State,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    Active = item.Active
                };

                listAddressEntity.Add(itemList);
            }

            return listAddressEntity;
        }
    }
}

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
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                Active = dto.Active
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
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                Active = entity.Active
            };
        }

        public static List<PersonDto> ToListDto(List<PersonEntity> entity)
        {
            List<PersonDto> listPersonDto = new List<PersonDto>();

            foreach (var item in entity)
            {
                var itemList = new PersonDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Cpf = item.Cpf,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    Active = item.Active
                };

                listPersonDto.Add(itemList);
            }

            return listPersonDto;
        }

        public static List<PersonEntity> ToListEntity(List<PersonDto> entity)
        {
            List<PersonEntity> listPersonEntity = new List<PersonEntity>();

            foreach (var item in entity)
            {
                var itemList = new PersonEntity
                {
                    Id = item.Id,
                    Name = item.Name,
                    Phone = item.Phone,
                    Cpf = item.Cpf,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    Active = item.Active
                };

                listPersonEntity.Add(itemList);
            }

            return listPersonEntity;
        }
    }
}

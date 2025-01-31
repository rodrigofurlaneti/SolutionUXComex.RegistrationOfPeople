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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresss = await _repository.GetAllAsync();
            return addresss.Select(AddressMapper.ToDto);
        }

        public async Task<AddressDto?> GetByIdAsync(int id)
        {
            var addressEntity = await _repository.GetByIdAsync(id);
            return addressEntity == null ? null : AddressMapper.ToDto(addressEntity);
        }

        public async Task<int> AddAsync(AddressDto addressDto)
        {
            var addressEntity = AddressMapper.ToEntity(addressDto);
            return await _repository.AddReturnIdAsync(addressEntity);
        }

        public async Task<bool> UpdateAsync(int id, AddressDto addressDto)
        {
            var addressEntity = await _repository.GetByIdAsync(id);
            if (addressEntity == null)
                return false;

            var updatedEntity = AddressMapper.ToEntity(addressDto);
            await _repository.UpdateAsync(updatedEntity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var addressEntity = await _repository.GetByIdAsync(id);
            if (addressEntity == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}

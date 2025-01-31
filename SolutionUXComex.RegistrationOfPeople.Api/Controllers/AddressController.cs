using Microsoft.AspNetCore.Mvc;
using SolutionUXComex.RegistrationOfPeople.Service.Dtos;
using SolutionUXComex.RegistrationOfPeople.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SolutionUXComex.RegistrationOfPeople.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todos os endereços")]
        [SwaggerResponse(200, "Lista de endereços retornada com sucesso")]
        [SwaggerResponse(404, "Nenhum endereço encontrada")]
        public async Task<IActionResult> GetAll()
        {
            var people = await _service.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna um endereço pelo ID informado")]
        [SwaggerResponse(200, "Pessoa encontrada com sucesso")]
        [SwaggerResponse(404, "Pessoa não encontrada com o ID informado")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetByIdAsync(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpGet("ByPersonId/{personId}")] // GET com parâmetro na URL
        [SwaggerOperation(Summary = "Retorna um lista com todos endereços pelo PersonId informado")]
        [SwaggerResponse(200, "Endereços pelo PersonId encontrada com sucesso")]
        [SwaggerResponse(404, "Endereços pelo PersonId encontrada não encontrada com o ID informado")]
        public async Task<IActionResult> GetByPersonId(int personId)
        {
            var listAnddresses = await _service.GetByPersonIdAsync(personId);
            if (listAnddresses == null)
                return NotFound();
            return Ok(listAnddresses);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um endereço ")]
        [SwaggerResponse(201, "Pessoa adicionada com sucesso")]
        public async Task<IActionResult> Add(AddressDto personDto)
        {
            var id = await _service.AddAsync(personDto);
            return CreatedAtAction(nameof(GetById), new { id }, personDto);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um endereço pelo ID informado")]
        [SwaggerResponse(204, "Pessoa atualizada com sucesso")]
        [SwaggerResponse(404, "Pessoa não encontrada com o ID informado")]
        public async Task<IActionResult> Update(int id, AddressDto personDto)
        {
            var updated = await _service.UpdateAsync(id, personDto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui um endereço pelo ID informado")]
        [SwaggerResponse(204, "Pessoa excluída com sucesso")]
        [SwaggerResponse(404, "Pessoa não encontrada com o ID informado")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SolutionUXComex.RegistrationOfPeople.Service.Interfaces;
using SolutionUXComex.RegistrationOfPeople.Service.Dtos;

namespace SolutionUXComex.RegistrationOfPeople.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todas as pessoas")]
        [SwaggerResponse(200, "Lista de pessoas retornada com sucesso")]
        [SwaggerResponse(404, "Nenhuma pessoa encontrada")]
        public async Task<IActionResult> GetAll()
        {
            var people = await _service.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna uma pessoa pelo ID informado")]
        [SwaggerResponse(200, "Pessoa encontrada com sucesso")]
        [SwaggerResponse(404, "Pessoa não encontrada com o ID informado")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _service.GetByIdAsync(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona uma nova pessoa")]
        [SwaggerResponse(201, "Pessoa adicionada com sucesso")]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            var id = await _service.AddAsync(personDto);
            return CreatedAtAction(nameof(GetById), new { id }, personDto);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma pessoa pelo ID informado")]
        [SwaggerResponse(204, "Pessoa atualizada com sucesso")]
        [SwaggerResponse(404, "Pessoa não encontrada com o ID informado")]
        public async Task<IActionResult> Update(int id, PersonDto personDto)
        {
            var updated = await _service.UpdateAsync(id, personDto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma pessoa pelo ID informado")]
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

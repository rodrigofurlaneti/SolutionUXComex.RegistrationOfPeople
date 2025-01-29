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
        [SwaggerOperation(Summary = "Retorna todos pessoas de acesso")]
        [SwaggerResponse(200, "Retorna todos pessoas de acesso")]
        [SwaggerResponse(404, "Não retorna todos pessoas de acesso")]
        public async Task<IActionResult> GetAll()
        {
            var accessLogs = await _service.GetAllAsync();
            return Ok(accessLogs);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna o pessoa de acesso do id informado")]
        [SwaggerResponse(200, "Retorna o pessoa de acesso do id informado")]
        [SwaggerResponse(404, "Não retorna o pessoa de acesso com o id informado")]
        public async Task<IActionResult> GetById(int id)
        {
            var accessLogDto = await _service.GetByIdAsync(id);
            return Ok(accessLogDto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo pessoa de acesso")]
        [SwaggerResponse(200, "Adiciona um novo pessoa de acesso")]
        [SwaggerResponse(404, "Não adiciona um novo pessoa de acesso")]
        public async Task<IActionResult> Add(PersonDto accessLogDto)
        {
            await _service.AddAsync(accessLogDto);
            return CreatedAtAction(nameof(GetById), new { id = accessLogDto.Id }, accessLogDto);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza o pessoa de acesso do id informado")]
        [SwaggerResponse(200, "Atualiza o pessoa de acesso do id informado")]
        [SwaggerResponse(404, "Não atualiza o pessoa de acesso do id informado")]
        public async Task<IActionResult> Update(int id, PersonDto accessLogDto)
        {
            await _service.UpdateAsync(id, accessLogDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui o pessoa de acesso do id informado")]
        [SwaggerResponse(200, "Exclui o pessoa de acesso do id informado")]
        [SwaggerResponse(404, "Não exclui o pessoa de acesso do id informado")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Gym.Application.Interfaces.Services;
using Gym.Application.DTOs.Proprietarios;

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController(IProprietarioService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll([FromHeader] int offset = 0, [FromHeader] int limit = 100) {

            var values = await service.FindAllAsync(offset, limit);

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var proprietario = await service.FindOneById(id);

            return Ok(proprietario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProprietarioCommand.CreateProprietario dto)
        {
            var newProprietario = await service.AddAsync(dto);

            return CreatedAtAction(nameof(FindById), new { id = newProprietario.Dados.Id }, newProprietario);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}

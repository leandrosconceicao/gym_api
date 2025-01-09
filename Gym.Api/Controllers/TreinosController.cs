using Gym.Application.DTOs.Usuario;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Services;
using Gym.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gym.Application.Interfaces.Services;

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinosController(ITreinoService service) : ControllerBase
    {
       [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromQuery] Guid? id, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {

            var values = await service.FindAllAsync(estabelecimentoId, id, offset, limit);
            
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id) {

            var treino = await service.FindOneByIdAsync(id);
                
            return Ok(treino);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TreinoCommand.CreateCommand command) {

            var newInserted = await service.AddAsync(command);

            return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Dados.Id}, newInserted);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {

            await service.DeleteAsync(id);

            return NoContent();

        } 
    }
}

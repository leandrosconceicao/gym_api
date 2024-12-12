using Gym.Domain.Commands.Usuario;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinosController(ITreinoRepository repository, ITreinoHandler handler) : ControllerBase
    {
       [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromQuery] Guid? id, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {
            try {
                var values = await repository.FindAsync(estabelecimentoId, id, offset, limit);
                
                return Ok(handler.Read(values));

            } catch (Exception) {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id) {
            try {
                var treino = await repository.FindAsync(id) ?? throw new NotFoundError("Treino não localizado");
                return Ok(handler.Read(treino));

            } catch (Exception) {
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TreinoCommand.CreateCommand command) {
            try {
                var newInserted = await repository.AddAsync(handler.Create(command));

                return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Id}, newInserted);
            } catch (Exception) {
                throw;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            try {

                var treino = await repository.FindAsync(id) ?? throw new NotFoundError("Treino não treino");

                await repository.DeleteAsync(treino);

                return NoContent();
            } catch (Exception) {
                throw;
            }

        } 
    }
}

using Gym.Domain.Commands.Exercicios;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExercicioController(IExercicioRepository repository, IExercicioHandler handler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid grupoMuscularId, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {
            try {
                var values = await repository.FindAllAsync(grupoMuscularId, offset, limit);
                
                return Ok(handler.Read(values));

            } catch (Exception) {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id) {
            try {
                var exercicio = await repository.FindOneAsync(id) ?? throw new NotFoundError("Exercicio não localizado");
                return Ok(handler.Read(exercicio));

            } catch (Exception) {
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ExercicioCommand.CreateExercicio command) {
            try {
                var newInserted = await repository.AddAsync(handler.Create(command));

                return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Id}, newInserted);
            } catch (Exception) {
                throw;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            try {

                var exercicio = await repository.FindOneAsync(id) ?? throw new NotFoundError("Exercicio não localizado");

                await repository.DeleteOneAsync(exercicio);

                return NoContent();
            } catch (Exception) {
                throw;
            }

        }
    }
}

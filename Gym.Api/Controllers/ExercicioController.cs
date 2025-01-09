using Gym.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Gym.Application.DTOs.Exercicios;

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController(IExercicioService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid grupoMuscularId, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {
            
            var values = await service.FindAllAsync(grupoMuscularId, offset, limit);
                
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(int id) {

            var exercicio = await service.FindOneById(id);

            return Ok(exercicio);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ExercicioCommand.CreateExercicio command) {

            var newInserted = await service.AddAsync(command);

            return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Dados.Id}, newInserted);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {

            await service.DeleteAsync(id);

            return NoContent();

        }
    }
}

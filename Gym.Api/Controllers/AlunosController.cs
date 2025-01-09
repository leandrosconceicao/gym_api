using Gym.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Gym.Application.Interfaces.Services;
using Gym.Application.DTOs.Usuario;

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController(IUsuarioService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {
            
            var values = await service.FindAllAalunos(estabelecimentoId, offset, limit);
            
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id) {
            
            var aluno = await service.FindAlunoById(id) ?? throw new NotFoundError("Aluno não localizado");

            return Ok(aluno);            

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UsuarioCommand.CreateAluno command) {
            
            var newInserted = await service.AddUsuarioAsync(command);

            return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Dados.Id}, newInserted);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {

            await service.DeleteAlunoAsync(id);

            return NoContent();

        }
    }
}

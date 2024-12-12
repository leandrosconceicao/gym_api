using Gym.Domain.Commands.Usuario;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController(IUsuarioRepository repository, IUsuarioHandler handler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limit = 100) {
            try {
                var values = await repository.FindAllAalunos(estabelecimentoId, offset, limit);
                
                return Ok(handler.ReadUsuario(values));

            } catch (Exception) {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id) {
            try {
                var aluno = await repository.FindAlunoById(id) ?? throw new NotFoundError("Aluno não localizado");
                return Ok(handler.ReadUsuario(aluno));

            } catch (Exception) {
                throw;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UsuarioCommand.CreateAluno command) {
            try {
                var newInserted = await repository.AddUsuario(handler.CreateUsuario(command));

                return CreatedAtAction(nameof(FindOneById), new {id = newInserted.Id}, newInserted);
            } catch (Exception) {
                throw;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            try {

                var aluno = await repository.FindAlunoById(id) ?? throw new NotFoundError("Aluno não localizado");

                await repository.DeleteAluno(aluno);

                return NoContent();
            } catch (Exception) {
                throw;
            }

        }
    }
}

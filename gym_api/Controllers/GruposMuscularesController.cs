using Gym.Domain.Commands.GrupoMuscular;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GruposMuscularesController(IGrupoMuscularRepository repository, IGrupoMuscularHandler handler) : ControllerBase
    {
        // GET: <GruposMuscularesController>
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limt = 100)
        {
            try
            {
               var values = await repository.FindAllAsync(estabelecimentoId, offset, limt);

                return Ok(handler.Read(values));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET <GruposMuscularesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id)
        {
            try
            {
                var grupo = await repository.FindOneById(id);

                if (grupo == null)
                    throw new NotFoundError("Grupo muscular não localizado");

                return Ok(handler.Read(grupo));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST <GruposMuscularesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GrupoMuscularCommand.CreateGrupoMuscular command)
        {
            try
            {
                var newGrupo = await repository.AddAsync(handler.Create(command));

                return CreatedAtAction(nameof(Post), new { id = newGrupo.Id }, handler.Read(newGrupo));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // PUT <GruposMuscularesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE <GruposMuscularesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var grupo = await repository.FindOneById(id);

                if (grupo == null)
                    throw new NotFoundError("Grupo não localizado");

                await repository.DeleteAsync(grupo);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

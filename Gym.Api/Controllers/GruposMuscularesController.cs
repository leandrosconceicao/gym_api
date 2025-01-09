using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Services;
using Gym.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Gym.Application.Interfaces.Services;
using Gym.Application.DTOs.GrupoMuscular;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposMuscularesController(IGrupoMuscularService service) : ControllerBase
    {
        // GET: <GruposMuscularesController>
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limt = 100)
        {
            var values = await service.FindAllAsync(estabelecimentoId, offset, limt);

            return Ok(values);
        }

        // GET <GruposMuscularesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id)
        {
            var grupo = await service.FindOneById(id);

            return Ok(grupo);
        }

        // POST <GruposMuscularesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GrupoMuscularCommand.CreateGrupoMuscular command)
        {
            var newGrupo = await service.AddAsync(command);

            return CreatedAtAction(nameof(Post), new { id = newGrupo.Dados.Id }, newGrupo);
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
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}

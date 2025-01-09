using Microsoft.AspNetCore.Mvc;
using Gym.Application.Interfaces.Services;
using Gym.Application.DTOs;

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentoController(IEstabelecimentoService service) : ControllerBase
    {
        // GET: api/<EstabelecimentoController>
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid? id)
        {
            var data = await service.FindAllAsync(id);

            return Ok(data);
        }

        // GET api/<EstabelecimentoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            var data = await service.FindOneById(id);

            return Ok(data);
        }

        // POST api/<EstabelecimentoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstabelecimentoCommand.CreateEstabelecimento data)
        {

            var inserted = await service.CreateAsync(data);

            return CreatedAtAction(nameof(FindById), new { id = inserted.Dados.Id }, inserted);          
                
        }

        // PUT api/<EstabelecimentoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<EstabelecimentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);

            return NoContent();
            
        }
    }
}

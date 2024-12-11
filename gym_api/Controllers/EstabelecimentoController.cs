using Gym.Domain.Commands;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstabelecimentoController(IEstabelecimentoRepository repository, IEstabelecimentoHandler handler) : ControllerBase
    {
        // GET: api/<EstabelecimentoController>
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] Guid? id)
        {
            try
            {
                var data = await repository.FindAllAsync(id);

                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<EstabelecimentoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                var data = await repository.FindOneById(id);

                if (data == null)
                    throw new NotFoundError("Estabelecimento não localizado");

                return Ok(data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<EstabelecimentoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EstabelecimentoCommand.CreateEstabelecimento data)
        {

            try
            {
                var inserted = await repository.Add(handler.Create(data));

                return CreatedAtAction(nameof(FindById), new { id = inserted.Id }, inserted);

            }
            catch (Exception) {
                throw;
            }

            
                
        }

        // PUT api/<EstabelecimentoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<EstabelecimentoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var estabelecimento = await repository.FindOneById(Guid.Parse(id));

                if (estabelecimento == null) 
                    throw new NotFoundError("Estabelcimento não localizado");

                await repository.Delete(estabelecimento);

                return NoContent();
            }
            catch (Exception) {
                throw;
            }
            
        }
    }
}

using Gym.Domain.Commands.Usuario;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrutorController(IUsuarioRepository repository, IUsuarioHandler handler) : ControllerBase
    {
        // GET: api/<InstrutorController>
        [HttpGet]
        public async Task<ActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limit = 100)
        {
            try
            {
                var values = await repository.FindAllInstrutores(estabelecimentoId, offset, limit);    

                return Ok(handler.ReadUsuario(values));

            } catch (Exception)
            {
                throw;
            }
        }

        // GET api/<InstrutorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id)
        {
            try
            {
                var instrutor = await repository.FindInstrutorById(id);

                if (instrutor == null)
                    throw new NotFoundError("Instrutor não localizado");

                return Ok(handler.ReadUsuario(instrutor));
            }
            catch (Exception) {
                throw;
            }
        }

        // POST api/<InstrutorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCommand.CreateInstrutor command)
        {
            try
            {
                var newInstrutor = await repository.AddUsuario(handler.CreateUsuario(command));

                return CreatedAtAction(nameof(FindOneById), new { id = newInstrutor.Id }, handler.ReadUsuario(newInstrutor));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //// PUT api/<InstrutorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        // DELETE api/<InstrutorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var instrutor = await repository.FindInstrutorById(id);

                if (instrutor == null)
                    throw new NotFoundError("Instrutor não localizado");

                await repository.DeleteInstrutor(instrutor);

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

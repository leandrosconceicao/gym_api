using Gym.Application.DTOs.Usuario;
using Gym.Domain.Entities;
using Gym.Domain.Exceptions;
using Gym.Domain.Interfaces.Services;
using Gym.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Gym.Application.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gym.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrutorController(IUsuarioService service) : ControllerBase
    {
        // GET: api/<InstrutorController>
        [HttpGet]
        public async Task<ActionResult> FindAll([FromQuery] Guid estabelecimentoId, [FromHeader] int offset = 0, [FromHeader] int limit = 100)
        {
            var values = await service.FindAllInstrutores(estabelecimentoId, offset, limit);    

            return Ok(values);
        }

        // GET api/<InstrutorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOneById(Guid id)
        {
            var instrutor = await service.FindInstrutorById(id);

            return Ok(instrutor);
        }

        // POST api/<InstrutorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCommand.CreateInstrutor command)
        {
            var newInstrutor = await service.AddUsuarioAsync(command);

            return CreatedAtAction(nameof(FindOneById), new { id = newInstrutor.Dados.Id }, newInstrutor);
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
            await service.DeleteInstrutorAsync(id);

            return NoContent();
        }
    }
}

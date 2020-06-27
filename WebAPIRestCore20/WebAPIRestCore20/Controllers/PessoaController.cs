using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Services;

namespace WebAPIRestCore20.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {

        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaService.FindByID(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaService.Create(pessoa));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaService.Update(pessoa));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaService.Delete(id);
            return NoContent();
        }
    }
}

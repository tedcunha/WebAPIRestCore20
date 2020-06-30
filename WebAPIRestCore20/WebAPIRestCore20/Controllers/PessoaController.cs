using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Business;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace WebAPIRestCore20.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PessoaController : Controller
    {

        private readonly IPessoaBusiness _pessoaBusiness;

        public PessoaController(IPessoaBusiness pessoaBusiness)
        {
            _pessoaBusiness = pessoaBusiness;
        }

        [HttpGet]
        //[SwaggerResponse((200), Type = typeof(List<Pessoa>))]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        [HttpGet("{id}")]
        //[SwaggerResponse((200), Type = typeof(Pessoa))]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.FindByID(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        //[SwaggerResponse((201), Type = typeof(Pessoa))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
        }

        [HttpPut]
        //[SwaggerResponse((202), Type = typeof(Pessoa))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaBusiness.Update(pessoa));
        }

        [HttpDelete("{id}")]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}

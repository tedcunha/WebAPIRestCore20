using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Business;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using WebAPIRestCore20.Data.VO;
using Tapioca.HATEOAS;
using Microsoft.AspNetCore.Authorization;

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
        //[Authorize("Bearer")]
        //[SwaggerResponse((200), Type = typeof(List<Pessoa>))]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        //[SwaggerResponse((200), Type = typeof(Pessoa))]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var pessoa = _pessoaBusiness.FindByID(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPost]
        [Authorize("Bearer")]
        //[SwaggerResponse((201), Type = typeof(Pessoa))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
        }

        [HttpPut]
        [Authorize("Bearer")]
        //[SwaggerResponse((202), Type = typeof(Pessoa))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PessoaVO pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaBusiness.Update(pessoa));
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        //[SwaggerResponse((204))]
        //[SwaggerResponse((400))]
        //[SwaggerResponse((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Business;

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

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pessoa = _pessoaBusiness.FindByID(id);
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
            return new ObjectResult(_pessoaBusiness.Create(pessoa));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_pessoaBusiness.Update(pessoa));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pessoaBusiness.Delete(id);
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Business;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivrosController : Controller
    {

        private readonly ILivrosBusiness _livrosBusiness;

        public LivrosController(ILivrosBusiness livrosBusiness)
        {
            _livrosBusiness = livrosBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_livrosBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var livro = _livrosBusiness.FindByID(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivroVO livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_livrosBusiness.Create(livro));
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivroVO livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_livrosBusiness.Update(livro));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _livrosBusiness.Delete(id);
            return NoContent();
        }
    }
}

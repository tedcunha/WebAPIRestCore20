using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIRestCore20.Business;
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
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            if (livro == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_livrosBusiness.Create(livro));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Livro livro)
        {
            return new ObjectResult(livro);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}

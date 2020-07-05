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
    public class UsuariosController : Controller
    {

        private readonly IUsuariosBusiness _usuariosBusiness;

        public UsuariosController(IUsuariosBusiness usuariosBusiness)
        {
            _usuariosBusiness = usuariosBusiness;
        }

        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_usuariosBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var usuarios = _usuariosBusiness.FindByID(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] UsuariosVO usuarios)
        {
            if (usuarios == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_usuariosBusiness.Create(usuarios));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] UsuariosVO usuarios)
        {
            if (usuarios == null)
            {
                return BadRequest();
            }
            return new ObjectResult(_usuariosBusiness.Update(usuarios));
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(long id)
        {
            _usuariosBusiness.Delete(id);
            return NoContent();
        }
    }
}

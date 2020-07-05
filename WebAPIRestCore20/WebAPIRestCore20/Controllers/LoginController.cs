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
    public class LoginController : Controller
    {
        private readonly ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [AllowAnonymous]
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public object Post([FromBody] Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            return _loginBusiness.FindByLogin(usuario);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIRestCore20.Controllers
{
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        // GET api/values/5/5
        [HttpGet("{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) + ConverteParaDecimal(segundoNumeroNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        private decimal ConverteParaDecimal(string numero)
        {
            decimal valor;
            if (decimal.TryParse(numero, out valor))
            {
                return valor;
            }
            return 0;
        }

        private bool IsNumeric(string numero)
        {
            double numeroSaida;
            bool isNumero = double.TryParse(numero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numeroSaida);
            return isNumero;
        }
    }
}

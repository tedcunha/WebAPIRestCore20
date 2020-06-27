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
        // GET api/Somar/5/5
        [HttpGet("Somar/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Somar(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) + ConverteParaDecimal(segundoNumeroNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        // GET api/Subtrair/5/5
        [HttpGet("Subtrair/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Subtrair(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) - ConverteParaDecimal(segundoNumeroNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        // GET api/Dividir/5/5
        [HttpGet("Dividir/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Dividir(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                if (ConverteParaDecimal(segundoNumeroNumero) == 0)
                {
                    return BadRequest("Numero não pode ser dividido por zero!");
                }

                var soma = ConverteParaDecimal(primeiroNumero) / ConverteParaDecimal(segundoNumeroNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        // GET api/Multiplicar/5/5
        [HttpGet("Multiplicar/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Multiplicar(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                var soma = ConverteParaDecimal(primeiroNumero) * ConverteParaDecimal(segundoNumeroNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        // GET api/Media/5/5
        [HttpGet("Media/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult Media(string primeiroNumero, string segundoNumeroNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumeroNumero))
            {
                var soma = ((ConverteParaDecimal(primeiroNumero) + ConverteParaDecimal(segundoNumeroNumero))/2);
                return Ok(soma.ToString());
            }

            return BadRequest("Entrada de dados inválida!");
        }

        // GET api/RaizQuadrada/5/5
        [HttpGet("RaizQuadrada/{primeiroNumero}/{segundoNumeroNumero}")]
        public IActionResult RaizQuadrada(string primeiroNumero)
        {
            if (IsNumeric(primeiroNumero))
            {
                var soma = Math.Sqrt((double)ConverteParaDecimal(primeiroNumero));
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

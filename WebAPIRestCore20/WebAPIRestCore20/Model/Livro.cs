using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model.Base;

namespace WebAPIRestCore20.Model
{
    public class Livro : BaseEntity
    {
        public string QuidID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}

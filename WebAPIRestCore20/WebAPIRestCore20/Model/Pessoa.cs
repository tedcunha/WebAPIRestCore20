using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model.Base;

namespace WebAPIRestCore20.Model
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
    }
}

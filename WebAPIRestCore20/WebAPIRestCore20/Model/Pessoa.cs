using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Model
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
    }
}

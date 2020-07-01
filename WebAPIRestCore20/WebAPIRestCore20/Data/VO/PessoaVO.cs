using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Data.VO
{

    [DataContract]
    public class PessoaVO
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }
        
        [DataMember(Order = 2)]
        public string QuidID { get; set; }

        [DataMember(Order = 3)]
        public string Nome { get; set; }

        [DataMember(Order = 4,Name = "SobreNome")]
        public string SobreNome { get; set; }

        [DataMember(Order = 5)]
        public string Endereco { get; set; }

        [DataMember(Order = 6)]
        public string Genero { get; set; }
    }
}

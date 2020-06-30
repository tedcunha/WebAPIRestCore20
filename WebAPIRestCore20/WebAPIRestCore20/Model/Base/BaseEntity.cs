using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Model.Base
{
    // Contrato entre atributos
    // e a estrutura de tabela
    //[DataContract]
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}

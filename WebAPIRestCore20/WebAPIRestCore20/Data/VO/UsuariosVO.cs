using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Data.VO
{
    [DataContract]
    public class UsuariosVO
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }
        [DataMember(Order = 2)]
        public string GuidID { get; set; }
        [DataMember(Order = 3)]
        public string Login { get; set; }
        [DataMember(Order = 4)]
        public string ChaveAcesso { get; set; }
        [DataMember(Order = 5)]
        public string Email { get; set; }
    }
}

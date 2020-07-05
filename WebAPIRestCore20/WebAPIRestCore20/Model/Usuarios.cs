using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model.Base;

namespace WebAPIRestCore20.Model
{
    public class Usuarios : BaseEntity
    {
        public string GuidID { get; set; }
        public string Login { get; set; }
        public string ChaveAcesso { get; set; }
        public string Email { get; set; }
    }
}

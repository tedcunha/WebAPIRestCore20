using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIRestCore20.Security.Configuration
{
    public class TokenConfiguration
    {
        public string Audiece { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}

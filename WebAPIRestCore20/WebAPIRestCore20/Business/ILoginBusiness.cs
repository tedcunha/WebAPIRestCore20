using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(Usuarios usuario);
    }
}

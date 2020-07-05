using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Repository
{
    public interface ILoginRepository
    {
        Usuarios FindByLogin(string login);
    }
}

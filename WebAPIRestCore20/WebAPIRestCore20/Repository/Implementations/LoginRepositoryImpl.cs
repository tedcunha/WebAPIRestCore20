using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;

namespace WebAPIRestCore20.Repository.Implementations
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private readonly MySqlContext _context;

        public LoginRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public Usuarios FindByLogin(string login)
        {
            return _context.Usuarios.SingleOrDefault(u => u.Login == login);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Repository.Generic;

namespace WebAPIRestCore20.Repository.Implementations
{
    public class PessoasRepositoryImpl : GenericRepository<Pessoa>, IPessoasRepository
    {
        public PessoasRepositoryImpl(MySqlContext context) : base(context)
        {
        }

        public List<Pessoa> PesquisaPorNome(string firstname, string lastname)
        {
            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname))
            {
                return _mySqlContext.persons.Where(p => p.Nome.Contains(firstname) && p.SobreNome.Contains(lastname)).ToList();
            }
            else if (string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname))
            {
                return _mySqlContext.persons.Where(p => p.SobreNome.Contains(lastname)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname))
            {
                return _mySqlContext.persons.Where(p => p.Nome.Contains(firstname)).ToList();
            }
            else 
            {
                return _mySqlContext.persons.ToList();
            }    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Base;

namespace WebAPIRestCore20.Repository.Generic
{
    public interface IPessoasRepository : IRepository<Pessoa>
    {
        List<Pessoa> PesquisaPorNome(string firstname, string lastname);
    }
}

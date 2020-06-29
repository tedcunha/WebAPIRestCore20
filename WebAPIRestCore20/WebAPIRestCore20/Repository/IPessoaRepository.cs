using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Repository
{
    public interface IPessoaRepository
    {
        Pessoa Create(Pessoa pessoa);
        Pessoa FindByID(int Id);
        List<Pessoa> FindAll();
        Pessoa Update(Pessoa pessoa);
        void Delete(int Id);
        bool Exist(int? id);
    }
}

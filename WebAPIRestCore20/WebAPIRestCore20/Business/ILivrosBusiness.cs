using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Business
{
    public interface ILivrosBusiness
    {
        Livro Create(Livro livro);
        Livro FindByID(int Id);
        List<Livro> FindAll();
        Livro Update(Livro livro);
        void Delete(int Id);
    }
}

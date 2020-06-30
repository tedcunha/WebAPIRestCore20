using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Repository.Generic;

namespace WebAPIRestCore20.Business.Implementations
{
    public class LivrosBusinessImplem : ILivrosBusiness
    {
        private readonly IRepository<Livro> _repository;

        public LivrosBusinessImplem(IRepository<Livro> repository)
        {
            _repository = repository;
        }

        public Livro Create(Livro livro)
        {
            return _repository.Create(livro);
        }

        public void Delete(int Id)
        {
            _repository.Delete(Id);
        }

        public List<Livro> FindAll()
        {
            return _repository.FindAll();
        }

        public Livro FindByID(int Id)
        {
            return _repository.FindByID(Id);
        }

        public Livro Update(Livro livro)
        {
            return _repository.Update(livro);
        }
    }
}

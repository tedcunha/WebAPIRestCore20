using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Repository;
using WebAPIRestCore20.Repository.Generic;

namespace WebAPIRestCore20.Business.Implementations
{
    public class PessoaBusinessImplem : IPessoaBusiness
    {
        private readonly IRepository<Pessoa> _repository;

        public PessoaBusinessImplem(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            return _repository.Create(pessoa);
        }

        public void Delete(int Id)
        {
            try
            {
                _repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> FindAll()
        {
            return _repository.FindAll();
        }

        public Pessoa FindByID(int Id)
        {
            return _repository.FindByID(Id);
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return _repository.Update(pessoa);
        }
    }
}

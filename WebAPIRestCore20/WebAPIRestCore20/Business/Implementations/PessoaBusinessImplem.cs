using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Repository;

namespace WebAPIRestCore20.Business.Implementations
{
    public class PessoaBusinessImplem : IPessoaBusiness
    {
        private readonly MySqlContext _mySqlContext;
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaBusinessImplem(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            return _pessoaRepository.Create(pessoa);
        }

        public void Delete(int Id)
        {
            try
            {
                _pessoaRepository.Delete(Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pessoa> FindAll()
        {
            return _pessoaRepository.FindAll();
        }

        public Pessoa FindByID(int Id)
        {
            return _pessoaRepository.FindByID(Id);
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return _pessoaRepository.Update(pessoa);
        }
    }
}

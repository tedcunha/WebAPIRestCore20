using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;

namespace WebAPIRestCore20.Repository.Implementations
{
    public class PessoaRepositoryImplem : IPessoaRepository
    {
        private readonly MySqlContext _mySqlContext;

        public PessoaRepositoryImplem(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            try
            {
                _mySqlContext.Add(pessoa);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pessoa;
        }

        public void Delete(int Id)
        {
            var retorno = _mySqlContext.persons.SingleOrDefault(p => p.Id == Id);
            try
            {
                if (retorno != null)
                {
                    _mySqlContext.persons.Remove(retorno);
                    _mySqlContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Pessoa> FindAll()
        {
            return _mySqlContext.persons.ToList();
        }

        public Pessoa FindByID(int Id)
        {
            return _mySqlContext.persons.SingleOrDefault(p => p.Id == Id);
        }

        public Pessoa Update(Pessoa pessoa)
        {
            if (!Exist(pessoa.Id))
            {
                return new Pessoa();
            }

            var retorno = _mySqlContext.persons.SingleOrDefault(p => p.Id == pessoa.Id);
            try
            {
                _mySqlContext.Entry(retorno).CurrentValues.SetValues(pessoa);
                _mySqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pessoa;
        }
        public bool Exist(int? id)
        {
            return _mySqlContext.persons.Any(p => p.Id == id);
        }
    }
}

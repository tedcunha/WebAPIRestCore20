using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebAPIRestCore20.Data.Converters;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Model.Context;
using WebAPIRestCore20.Repository;
using WebAPIRestCore20.Repository.Generic;

namespace WebAPIRestCore20.Business.Implementations
{
    public class PessoaBusinessImplem : IPessoaBusiness
    {
        private readonly IRepository<Pessoa> _repository;

        private readonly PessoaConverter _converter;
        public PessoaBusinessImplem(IRepository<Pessoa> repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

        public PessoaVO Create(PessoaVO pessoa)
        {
            pessoa.QuidID = Guid.NewGuid().ToString();
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Create(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public void Delete(long Id)
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

        public List<PessoaVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PessoaVO FindByID(long Id)
        {
            return _converter.Parse(_repository.FindByID(Id));
        }

        public PessoaVO Update(PessoaVO pessoa)
        {
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Update(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }
    }
}

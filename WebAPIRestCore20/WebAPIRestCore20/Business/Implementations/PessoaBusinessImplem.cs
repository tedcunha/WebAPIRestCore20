using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tapioca.HATEOAS.Utils;
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
        private readonly IPessoasRepository _repository;

        private readonly PessoaConverter _converter;
        public PessoaBusinessImplem(IPessoasRepository repository)
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

        public List<PessoaVO> PesquisaPorNome(string firstname, string lastname)
        {
            return _converter.ParseList(_repository.PesquisaPorNome(firstname, lastname));
        }

        public PagedSearchDTO<PessoaVO> FindWithPagedSearch(string name,string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;
            
            // Select da Paginação
            string query = "Select * From persons p ";
            query += "Where 1 = 1 ";
            if (!string.IsNullOrEmpty(name))
            {
                query += $"and p.Nome like '%{name}%' ";
            }
            query += $"Order By p.Nome {sortDirection} limit {pageSize} offset {page}";
            var pessoa = _converter.ParseList(_repository.FindWithPagedSearch(query));

            // Pegando o Total de Registros
            string countQuery = "Select Count(*) as Qtde From persons p Where 1 = 1 ";
            if (!string.IsNullOrEmpty(name))
            {
                countQuery += $"and p.Nome like '%{name}%'";
            }
            var totalRegistros = _repository.GetCount(countQuery);

            return new PagedSearchDTO<PessoaVO>
            {
                CurrentPage = page + 1,
                List = pessoa,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalRegistros
            };
        }

        public PessoaVO Update(PessoaVO pessoa)
        {
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Update(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }
    }
}

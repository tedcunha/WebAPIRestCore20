using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.Converters;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;
using WebAPIRestCore20.Repository.Generic;

namespace WebAPIRestCore20.Business.Implementations
{
    public class LivrosBusinessImplem : ILivrosBusiness
    {
        private readonly IRepository<Livro> _repository;

        private readonly LivrosConverter _converter;

        public LivrosBusinessImplem(IRepository<Livro> repository)
        {
            _repository = repository;
            _converter = new LivrosConverter();
        }

        public LivroVO Create(LivroVO livro)
        {
            livro.QuidID = Guid.NewGuid().ToString();
            var livroEntity = _converter.Parse(livro);
            livroEntity = _repository.Create(livroEntity);
            return _converter.Parse(livroEntity);
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

        public List<LivroVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public LivroVO FindByID(long Id)
        {
            return _converter.Parse(_repository.FindByID(Id));
        }

        public LivroVO Update(LivroVO livro)
        {
            var livroEntity = _converter.Parse(livro);
            livroEntity = _repository.Update(livroEntity);
            return _converter.Parse(livroEntity);
        }
    }
}

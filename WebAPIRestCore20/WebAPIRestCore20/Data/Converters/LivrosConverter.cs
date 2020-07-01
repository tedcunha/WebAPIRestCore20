using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.Converter;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Data.Converters
{
    public class LivrosConverter : IParser<LivroVO, Livro>, IParser<Livro, LivroVO>
    {
        public Livro Parse(LivroVO origem)
        {
            if (origem == null) return null;
            return new Livro { Id = origem.Id,
                               QuidID = origem.QuidID,
                               Titulo = origem.Titulo,
                               Autor = origem.Autor,
                               Preco = origem.Preco,
                               DataLancamento = origem.DataLancamento};
        }

        public LivroVO Parse(Livro origem)
        {
            if (origem == null) return null;
            return new LivroVO
            {
                Id = origem.Id,
                QuidID = origem.QuidID,
                Titulo = origem.Titulo,
                Autor = origem.Autor,
                Preco = origem.Preco,
                DataLancamento = origem.DataLancamento
            };
        }

        // List
        public List<Livro> ParseList(List<LivroVO> origem)
        {
            if (origem == null) return new List<Livro>();
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<LivroVO> ParseList(List<Livro> origem)
        {
            if (origem == null) return new List<LivroVO>();
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}

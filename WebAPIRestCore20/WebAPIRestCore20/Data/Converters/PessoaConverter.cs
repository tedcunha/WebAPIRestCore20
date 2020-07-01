using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.Converter;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {

        public Pessoa Parse(PessoaVO origem)
        {
            if (origem == null) return null;
            return new Pessoa { Id = origem.Id,
                                QuidID = origem.QuidID,
                                Nome = origem.Nome,
                                SobreNome = origem.SobreNome,
                                Endereco = origem.Endereco,
                                Genero = origem.Genero };
        }

        public PessoaVO Parse(Pessoa origem)
        {
            if (origem == null) return null;
            return new PessoaVO { Id = origem.Id,
                                  QuidID = origem.QuidID,
                                  Nome = origem.Nome,
                                  SobreNome = origem.SobreNome,
                                  Endereco = origem.Endereco,
                                  Genero = origem.Genero };
        }

        // ---------------
        // Lista
        public List<Pessoa> ParseList(List<PessoaVO> origem)
        {
            if (origem == null) return new List<Pessoa>();
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<PessoaVO> ParseList(List<Pessoa> origem)
        {
            if (origem == null) new List<PessoaVO>();
            return origem.Select(item => Parse(item)).ToList();
       }
    }
}

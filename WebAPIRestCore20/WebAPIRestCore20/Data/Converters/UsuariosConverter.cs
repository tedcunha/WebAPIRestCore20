using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.Converter;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Data.Converters
{
    public class UsuariosConverter : IParser<UsuariosVO, Usuarios>, IParser<Usuarios, UsuariosVO>
    {
        public Usuarios Parse(UsuariosVO origem)
        {
            if (origem == null) return null;
            return new Usuarios            {
                Id = origem.Id,
                GuidID = origem.GuidID,
                Login = origem.Login,
                ChaveAcesso = origem.ChaveAcesso,
                Email = origem.Email
            };
        }

        public UsuariosVO Parse(Usuarios origem)
        {
            if (origem == null) return null;
            return new UsuariosVO
            {
                Id = origem.Id,
                GuidID = origem.GuidID,
                Login = origem.Login,
                ChaveAcesso = origem.ChaveAcesso,
                Email = origem.Email
            };
        }

        // Listas
        public List<Usuarios> ParseList(List<UsuariosVO> origem)
        {
            if (origem == null) return new List<Usuarios>();
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<UsuariosVO> ParseList(List<Usuarios> origem)
        {
            if (origem == null) return new List<UsuariosVO>();
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}

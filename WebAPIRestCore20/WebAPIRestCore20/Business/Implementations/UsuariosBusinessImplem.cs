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
    public class UsuariosBusinessImplem : IUsuariosBusiness
    {
        private readonly IRepository<Usuarios> _repository;
        private readonly UsuariosConverter _converter;

        public UsuariosBusinessImplem(IRepository<Usuarios> repository)
        {
            _repository = repository;
            _converter = new UsuariosConverter();
        }

        public UsuariosVO Create(UsuariosVO usuario)
        {
            usuario.GuidID = Guid.NewGuid().ToString();
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity = _repository.Create(usuarioEntity);
            return _converter.Parse(usuarioEntity);
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

        public List<UsuariosVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public UsuariosVO FindByID(long Id)
        {
            return _converter.Parse(_repository.FindByID(Id));
        }

        public UsuariosVO Update(UsuariosVO usuario)
        {
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity = _repository.Update(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }
    }
}

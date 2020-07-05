using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.VO;

namespace WebAPIRestCore20.Business
{
    public interface IUsuariosBusiness
    {
        UsuariosVO Create(UsuariosVO usuario);
        UsuariosVO FindByID(long Id);
        List<UsuariosVO> FindAll();
        UsuariosVO Update(UsuariosVO usuario);
        void Delete(long Id);
    }
}

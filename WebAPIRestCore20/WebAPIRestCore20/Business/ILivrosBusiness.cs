using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Business
{
    public interface ILivrosBusiness
    {
        LivroVO Create(LivroVO livro);
        LivroVO FindByID(long Id);
        List<LivroVO> FindAll();
        LivroVO Update(LivroVO livro);
        void Delete(long Id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIRestCore20.Data.VO;
using WebAPIRestCore20.Model;

namespace WebAPIRestCore20.Business
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoa);
        PessoaVO FindByID(long Id);
        List<PessoaVO> FindAll();
        List<PessoaVO> PesquisaPorNome(string firstname, string lastname);
        PessoaVO Update(PessoaVO pessoa);
        void Delete(long Id);
    }
}

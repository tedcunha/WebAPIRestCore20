using WebAPIRestCore20.Data.VO;

namespace WebAPIRestCore20.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(LoginVO usuario);
    }
}

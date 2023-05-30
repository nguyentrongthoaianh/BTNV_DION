using DION_BTVN.Models;

namespace DION_BTVN.Repositories
{
    public interface IAccountRepository
    {
        Task Register(Account obj);
        Task<bool> IsEmail(string email);
    }
}

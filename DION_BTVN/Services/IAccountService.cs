using DION_BTVN.ViewModels.Account;

namespace DION_BTVN.Services
{
    public interface IAccountService
    {
        Task RegisterWM(registerViewModel obj);
        Task<bool> IsEmailExist(string email);
    }
}

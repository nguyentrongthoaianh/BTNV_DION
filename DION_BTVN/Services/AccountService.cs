using DION_BTVN.Models;
using DION_BTVN.Repositories;
using DION_BTVN.ViewModels.Account;

namespace DION_BTVN.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task RegisterWM(registerViewModel obj)
        {
            Account ac = new Account()
            {
                Id = 0,
                Username = obj.username,
                Email = obj.email,
                Password = obj.password,
                Active = true,
                CreatedTime = DateTime.Now,
            };
            await _accountRepository.Register(ac);
        }
        public async Task<bool> IsEmailExist(string email)
        {
            return await _accountRepository.IsEmail(email);
        }
    }
}

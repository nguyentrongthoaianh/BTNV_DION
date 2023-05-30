using DION_BTVN.Models;
using Microsoft.EntityFrameworkCore;

namespace DION_BTVN.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DionThoaianhContext db;
        public AccountRepository(DionThoaianhContext _db)
        {
            db = _db;
        }
        public async Task Register(Account obj)
        {
            await db.Accounts.AddAsync(obj);
            await db.SaveChangesAsync();
        }
        public async Task<bool> IsEmail(string email)
        {
            return await db.Accounts.AnyAsync(ac => ac.Active && ac.Email.ToLower().Trim() == email.ToLower().Trim());
        }
    }
}

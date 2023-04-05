using BankWebApp.DataObjects;

namespace BankWebApp.Models.Service
{
    public class AccountService
    {
        private readonly bankdataContext _context;
        public AccountService(bankdataContext context) 
        { 
            _context = context;
        }
        public async Task Insert(Account acc)
        {
            await _context.AddAsync(acc);
            await _context.SaveChangesAsync();
        }
    }
}

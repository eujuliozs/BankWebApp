using BankWebApp.DataObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BankWebApp.Models.Service
{
    public class AccountService
    {
        private readonly bankdataContext _context;
        public AccountService(bankdataContext context) 
        { 
            _context = context;
        }
        public async Task InsertAsync(Account acc)
        {
            await _context.AddAsync(acc);
            await _context.SaveChangesAsync();
        }
        public Account CheckIfLogged(string number, string password)
        {
            var query =
                from acc in _context.Account
                where acc.Number == number
                && acc.Password == password
                select acc;

            return query.FirstOrDefault();
        }
        public Account? FindById(int id)
        { 
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var query = 
                from acc in _context.Account.Include(acc => acc.Transactions)
                where acc.Id == id 
                select acc;
            return query.SingleOrDefault();
        }
    }
}

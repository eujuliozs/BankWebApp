using BankWebApp.DataObjects;
using BankWebApp.Models.Service.Exception;
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
        public void UpdateBalance(int accountId,double amount, TransactionType transactionType)
        {
            Account acc = FindById(accountId);
            if (acc == null) 
            {
                throw new DbAccountNotFoundException("Account not found in the Database");
            }
            if(transactionType == TransactionType.Deposit)
            {
                acc.Balance += amount;
                _context.Account.Update(acc);
                _context.SaveChanges();
            }
            else if(transactionType == TransactionType.Withdraw)
            {
                acc.Balance -= amount;
                _context.Account.Update(acc);
                _context.SaveChanges();
            }
        }
        public bool CheckPassword(int id, string password)
        {
            var query =
                from acc in _context.Account
                where acc.Id.Equals(id)
                && password.Equals(password)
                select acc;
            if(query.SingleOrDefault() is null)
            {
                return false;
            }
            return true;
        }
    }
}

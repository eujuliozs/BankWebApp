using BankWebApp.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BankWebApp.Models.Services
{
    public class AccountService
    {
        private readonly BankWebAppContext _context;
        public AccountService(BankWebAppContext context)
        {
            _context = context;
        }
        public void Insert(Account acc)
        {
            _context.Add(acc);
            _context.SaveChanges();
        }
        public void InsertOwner(Owner ow)
        {
            _context.Add(ow);
            _context.SaveChanges();
        }
    }
}

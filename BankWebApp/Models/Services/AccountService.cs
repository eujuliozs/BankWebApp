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
        public Account? Login(string number, string password) 
        {
            var consulta =
                from acc in _context.Account
                where acc.Number == number ||
                acc.Password == password
                select acc;

            return consulta.SingleOrDefault();
        }
        public Account? FindByInd(int? id)
        {
            if(id == null)
            {
                return null;
            }
            var consulta =
                from Acc in _context.Account
                where Acc.Id == id
                select Acc;
            return consulta.SingleOrDefault();
        }
    }
}

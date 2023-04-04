using BankWebApp.Data;
using BankWebApp.Models.Services.Exceptions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Policy;

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

        public Account? Login(string number, string password) 
        {
            var consulta =
                from acc in _context.Account
                where acc.Number == number &&
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
        public string GetNumber(Account acc)
        {
            var account = FindByInd(acc.Id);
            return account.Number;
        }
        public Account? AccNumberExists(string Number)
        {
            return _context.Account.Where(acc => acc.Number == Number).SingleOrDefault();
        }
        public void Deposit(TransactionRecord Tr)
        {
            if(Tr is null)
            {
                throw new ApplicationException("Tr vazio");
            }

            if (Tr.Account is null)
            {
                throw new NotLoggedException("Account came null");
            }
            _context.TransactionRecord.Add(Tr);
            _context.SaveChanges();  
        }
        public Account? CheckPassword(Account acc,string password)
        {
            if(acc.Password == password)
            {
                return acc;
            }
            return null;
        }
        public Account? EagerAccount(Account acc)
        {
            return acc;
        }
    }
}

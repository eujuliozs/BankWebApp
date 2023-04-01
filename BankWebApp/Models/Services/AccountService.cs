using BankWebApp.Data;
using BankWebApp.Models.Services.Exceptions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public string GetNumber(Account acc)
        {
            var account = FindByInd(acc.Id);
            return account.Number;
        }
        public Owner GetOwner(Account acc)
        {
            var consulta = 
                from onwer in _context.Owner
                where onwer.Id == acc.OwnerId
                select onwer;
            return consulta.SingleOrDefault();
        }
        public Account AccNumberExists(string Number)
        {
            return _context.Account.Where(acc => acc.Number == Number).SingleOrDefault();
        }
        public void Deposit(TransactionRecord Tr)
        {
            var Sender = _context.Account.Where(acc => acc.Id == Tr.Account.Id).SingleOrDefault();
            var acc = new Account() { Balance = Sender.Balance, Id = Sender.Id,OwnerId=Sender.OwnerId,
            Transactions = Sender.Transactions, Number=Sender.Number, Password=Sender.Password};
            _context.Remove(Sender);
            _context.Add(acc);
            _context.SaveChanges();
        }
    }
}

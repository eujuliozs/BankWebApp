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

    }
}

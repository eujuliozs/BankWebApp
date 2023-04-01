using BankWebApp.Models;
using BankWebApp.Models.Services.Exceptions;
using BankWebApp.Models.Services;
using BankWebApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _accountService;
        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }
        // ações relacionadas a ações da conta
        public IActionResult Index(Account? acc)
        {
            if(acc is null)
            {
                throw new NotLoggedException("Você não está logado");
            }
            var accnumber = _accountService.GetNumber(acc);
            var owner = _accountService.GetOwner(acc);
            var viewmodel = new AccountMenuViewModel() {AccNumber=accnumber, Account=acc, Owner=owner};
            return View(viewmodel);
        }
        public IActionResult Deposit(AccountMenuViewModel? viewModel)
        {
            if(viewModel is null)
            {
                throw new NotLoggedException("Você não esta logado");
            }
            var Tr = new TransactionRecord() { TransactionType=0, Account=viewModel.Account};
            return View(Tr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TransactionRecord? Tr)
        {
            if(Tr.Amount == null)
            {
                return NotFound();
            }
            var Result = _accountService.Login(Tr.Account.Number, Tr.Account.Password); 
            if(Result is null)
            {
                throw new WrongPasswordException("Incorrect Password");
            }
            _accountService.Deposit(Tr);
            return RedirectToAction(nameof(Index));
            
        }
        // Ações todas relacionadas a login e a criar uma conta 
        public IActionResult Create()
        {
            var Owner = new Owner();
            return View(Owner);
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create(Owner ow) 
        {
            _accountService.InsertOwner(ow);
            return View("Created", ow);
        }
        public IActionResult Login()
        {
            var viewmodel = new LoginForm();
            return View(viewmodel);
        }
        public IActionResult Logged(LoginForm data)
        {
            Account acc = _accountService.Login(data.AccNumber, data.Password);
            if(acc is null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index), acc);
        }
    }
}
//
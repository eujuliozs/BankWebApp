using BankWebApp.Models;
using BankWebApp.Models.Services.Exceptions;
using BankWebApp.Models.Services;
using BankWebApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                return RedirectToAction(nameof(Error), "Not Logged");
            }
            var accnumber = _accountService.GetNumber(acc);
            var owner = _accountService.GetOwner(acc);
            var viewmodel = new AccountMenuViewModel{
                AccNumber=accnumber,
                Account=acc,
                Owner=owner
            };
            return View(viewmodel);
        }
        public IActionResult Deposit(Account acc)
        {
            if(acc is null)
            {
                return RedirectToAction(nameof(Error), new { Message= "Bad Request"});
            }
            var Tr = new TransactionRecord() { TransactionType=0, Account=acc};
            return View(Tr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DepositPost(TransactionRecord? Tr)
        {
            if(Tr.Amount == 0)
            {
                return RedirectToAction(nameof(Error), new { Message = "Amount not provided"});
            }
            var Result = _accountService.CheckPassword(Tr.Account, Tr.Account.Password); 
            if(Result is null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Incorrect Password" });
            }
            try
            {
                _accountService.Deposit(Tr);
            }
            catch(ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        
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
                return RedirectToAction(nameof(Error), new {Message = "Login Info doesn't match"});
            }
            return RedirectToAction(nameof(Index), acc);
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
//
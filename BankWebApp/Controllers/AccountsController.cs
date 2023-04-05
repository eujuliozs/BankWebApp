using Microsoft.AspNetCore.Mvc;
using BankWebApp.Models;
using BankWebApp.Models.Service;
using BankWebApp.Models.ViewModel;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            Account account = new Account();
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account? account)
        {
            if(!ModelState.IsValid)
            {
                return View(account);
            }
            try
            {
                await _accountService.Insert(account);
            }
            catch (Exception ex) 
            {
                RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
            return View("Created",account);

        }
        [HttpPost]
        public IActionResult Login()
        {

        }

        public IActionResult Error(string Message)
        {
            var viewModel = new ErrorViewModel {
                Message = Message,
                RequestId=Activity.Current?.Id ?? HttpContext.TraceIdentifier            
            };
            return View(viewModel);
            
        }
    }
}

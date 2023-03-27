using BankWebApp.Models;
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
        public IActionResult Index(Account acc)
        {
            return View();
        }
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
            return View("Created",ow);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logged(Account acc)
        {
            if (acc == null) 
            {
                return NotFound(); 
            }
            if (_accountService.Login != null)
            {
                return RedirectToAction(nameof(Index),acc);
            }
            return NotFound();
        }
    }
}

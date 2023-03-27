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
        public IActionResult Index()
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
    }
}

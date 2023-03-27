using BankWebApp.Models;
using BankWebApp.Models.Services;
using BankWebApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _accountService;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var viewmodel = new AccountFormViewModel();
            return View(viewmodel);
        }
    }
}

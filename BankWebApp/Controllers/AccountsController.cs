using Microsoft.AspNetCore.Mvc;
using BankWebApp.Models;
using BankWebApp.Models.Service;
using BankWebApp.Models.ViewModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BankWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountService _accountService;
        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }
        //Actions Related to account operations
        public async Task<IActionResult> Index(Account acc)
        {
            if (acc == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "You are not logged" });
            }
            return View(acc);
        }
        public IActionResult Create()
        {
            Account account = new Account() { Number=GenerateNumber()};
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account? account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            try
            {
                await _accountService.InsertAsync(account);
            }
            catch (ApplicationException ex)
            {
                RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
            return View("Created", account);

        }


        // Actions Related to login + Error
        public IActionResult Login()
        {
            return View(new LoginForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginForm viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                Account query = _accountService.CheckIfLogged(viewModel.Number, viewModel.Password);
                if (query is null)
                {
                    return RedirectToAction(nameof(Error), new { Message = "Account doesn't exist" });
                }
                return RedirectToAction(nameof(Index), query);
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }
        public IActionResult Details(int? id)
        {
            Account acc = _accountService.FindById(id.Value);
            return View(acc);
        }

        public async Task<IActionResult> Error(string Message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = Message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);

        }
        static string GenerateNumber()
        {
            string lst = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    lst += "-";
                }
                string str = random.Next(10).ToString();
                lst += str;
            }
            return lst.ToString();
        }
    }
}

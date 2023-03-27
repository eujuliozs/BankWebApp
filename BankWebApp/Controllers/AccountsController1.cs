using Microsoft.AspNetCore.Mvc;

namespace BankWebApp.Controllers
{
    public class AccountsController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

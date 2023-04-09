using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankWebApp.DataObjects;
using BankWebApp.Models;
using BankWebApp.Models.Service;
using BankWebApp.Models.ViewModel;
using System.Diagnostics;

namespace BankWebApp.Controllers
{
    public class TransactionRecordsController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly AccountService _accountService;
        public TransactionRecordsController(TransactionService transactionService, AccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }
        public IActionResult Index(int id)
        {
            var acc = _accountService.FindById(id);
            if (acc == null) 
            {
                return RedirectToAction(nameof(Error), new { Message = "Bad Request" });
            }
            IEnumerable<TransactionRecord> list = _transactionService.FindAll(acc);
            return View(list);
            
        }
        [HttpGet]
        public IActionResult Deposit(int? id)
        {
            return View(new TransactionRecord { AccountId=id.Value});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DepositConfirmed(TransactionRecord Tr)
        {
            Tr.Moment=DateTime.Now;
            Tr.TransactionType = TransactionType.Deposit;
            _transactionService.AddTransaction(Tr);
            try
            {
                _accountService.UpdateBalance(Tr.AccountId, Tr.Amount, TransactionType.Deposit);
            }
            catch(ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
            return RedirectToAction(nameof(Index),new {id=Tr.AccountId});
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
    }
}

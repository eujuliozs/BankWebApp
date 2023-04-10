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
        [ActionName("TransactionRecords")]
        public IActionResult Index(int id)
        {
            var acc = _accountService.FindById(id);
            if (acc == null) 
            {
                return RedirectToAction(nameof(Error), new { Message = "Bad Request" });
            }
            IEnumerable<TransactionRecord> list = _transactionService.FindAll(acc);
            return View("Index", list);
            
        }
        [HttpGet]
        public IActionResult Deposit(int? id)
        {
            return View(new TransactionRecord { AccountId=id.Value});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Deposit")]
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
            Account acc = _accountService.FindById(Tr.AccountId);
            return RedirectToAction(nameof(Index),"Accounts", acc);
        }
        [HttpGet]
        public IActionResult Withdraw(int? id)
        {
            TransactionRecord Tr = new() { AccountId = id.Value };
            var viewModel = new WithdrawForm {Transaction=Tr};
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("Withdraw")]
        public IActionResult WithdrawConfirmed(WithdrawForm viewModel)
        {
            bool PasswordIsRight = _accountService.CheckPassword(viewModel.Transaction.AccountId, viewModel.Password);
            if (PasswordIsRight) 
            {
                viewModel.Transaction.TransactionType = TransactionType.Withdraw;
                viewModel.Transaction.Moment = DateTime.Now;
                _transactionService.AddTransaction(viewModel.Transaction);
                try 
                { 
                    _accountService.UpdateBalance(viewModel.Transaction.AccountId, viewModel.Transaction.Amount,TransactionType.Withdraw);
                    Account acc = _accountService.FindById(viewModel.Transaction.AccountId);
                    return RedirectToAction(nameof(Index), "Accounts", acc);
                }
                catch(ApplicationException ex)
                {
                    return RedirectToAction(nameof(Error), new { Message = ex.Message });
                }
            }
            else
            {
                return RedirectToAction(nameof(Error), new { Message ="Account Info Does't match" });
            }
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

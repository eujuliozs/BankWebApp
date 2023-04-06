using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankWebApp.DataObjects;
using BankWebApp.Models;

namespace BankWebApp.Controllers
{
    public class TransactionRecordsController : Controller
    {
        private readonly bankdataContext _context;

        public TransactionRecordsController(bankdataContext context)
        {
            _context = context;
        }

        // GET: TransactionRecords
        public async Task<IActionResult> Index()
        {
              return _context.TransactionRecords != null ? 
                          View(await _context.TransactionRecords.ToListAsync()) :
                          Problem("Entity set 'bankdataContext.TransactionRecords'  is null.");
        }

        // GET: TransactionRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransactionRecords == null)
            {
                return NotFound();
            }

            var transactionRecord = await _context.TransactionRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionRecord == null)
            {
                return NotFound();
            }

            return View(transactionRecord);
        }

        // GET: TransactionRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Moment,Amount,TransactionType")] TransactionRecord transactionRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionRecord);
        }

        // GET: TransactionRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransactionRecords == null)
            {
                return NotFound();
            }

            var transactionRecord = await _context.TransactionRecords.FindAsync(id);
            if (transactionRecord == null)
            {
                return NotFound();
            }
            return View(transactionRecord);
        }

        // POST: TransactionRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Moment,Amount,TransactionType")] TransactionRecord transactionRecord)
        {
            if (id != transactionRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionRecordExists(transactionRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transactionRecord);
        }

        // GET: TransactionRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionRecords == null)
            {
                return NotFound();
            }

            var transactionRecord = await _context.TransactionRecords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transactionRecord == null)
            {
                return NotFound();
            }

            return View(transactionRecord);
        }

        // POST: TransactionRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.TransactionRecords == null)
            {
                return Problem("Entity set 'bankdataContext.TransactionRecords'  is null.");
            }
            var transactionRecord = await _context.TransactionRecords.FindAsync(id);
            if (transactionRecord != null)
            {
                _context.TransactionRecords.Remove(transactionRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionRecordExists(int? id)
        {
          return (_context.TransactionRecords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

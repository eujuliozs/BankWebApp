using BankWebApp.DataObjects;

namespace BankWebApp.Models.Service
{
    public class TransactionService
    {
        private readonly bankdataContext _context;
        public TransactionService(bankdataContext context)
        {
            _context = context;
        }
        public void AddTransaction(TransactionRecord tr)
        {          
            _context.Add(tr);
            _context.SaveChanges();
        }
        public List<TransactionRecord> FindAll(Account acc)
        {
            return _context.TransactionRecords.Where(t => t.AccountId == acc.Id).Select(x => x).ToList();
        }
    }
}

using BankWebApp.Models.Enums;
namespace BankWebApp.Models
{
    public class TransactionRecord
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; } = DateTime.Now;
        public double Amount { get; set; }
        public Account Account { get; set; }
        public string? ReceiverNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionRecord()
        {

        }
    }
}

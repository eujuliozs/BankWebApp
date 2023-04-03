using BankWebApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWebApp.Models
{
    public class TransactionRecord
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Moment { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Amount { get; set; }
        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionRecord()
        {

        }
    }
}

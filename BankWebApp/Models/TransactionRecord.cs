using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWebApp.Models
{
    public class TransactionRecord
    {
        public int Id { get; private set; }
        [DataType(DataType.Date)]
        public DateTime Moment { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(1, 10000, ErrorMessage ="Deposit Must be between 1 and 10000")]
        public double Amount { get; set; }
        public int AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionRecord()
        {

        }
    }
}

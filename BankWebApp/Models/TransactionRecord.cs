using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWebApp.Models
{
    public class TransactionRecord
    {
        public int? Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Moment { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
       // [FromRoute]
        public int AccountId { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransactionRecord()
        {

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BankWebApp.Models.ViewModel
{
    public class WithdrawForm
    {
        public TransactionRecord Transaction { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

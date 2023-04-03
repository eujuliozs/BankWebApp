using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace BankWebApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public Account Account { get; set; }
        public ICollection<TransactionRecord> Transactions = new List<TransactionRecord>();
    }
}

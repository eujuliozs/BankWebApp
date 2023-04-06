using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace BankWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Account's Holder name is required")] 
        [StringLength(100,MinimumLength =3, ErrorMessage ="Minimum of 3 characters")] 
        public string Holder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime HolderBirthDate { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set;}

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Balance { get; set; } = 0;
        public string Number { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        [StringLength(6, MinimumLength =4, ErrorMessage = "Password must be between 4 and 6 characters")]
        public string Password { get; set; }
        public List<TransactionRecord> Transactions { get; set; } = new List<TransactionRecord>();
        public Account()
        {

        }
        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }


    }
}

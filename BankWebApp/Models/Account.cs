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
        public string Number { get; set; } = GenerateNumber();

        [Required]
        [DataType(DataType.Password)]
        [StringLength(6, MinimumLength =4, ErrorMessage = "Password must be between 4 and 6 characters")]
        public string Password { get; set; }
        public ICollection<TransactionRecord> Transactions { get; set; } = new List<TransactionRecord>();
        public Account()
        {

        }
        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }
        static string GenerateNumber()
        {
            string lst = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    lst += "-";
                }
                string str = random.Next(10).ToString();
                lst += str;
            }
            return lst.ToString();

        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Number.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(!(obj is Account)) return false;

            Account other = (Account)obj;
            if (Id == other.Id && Number == other.Number) return true;

            return false;
        }



    }
}

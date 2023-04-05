using System.ComponentModel.DataAnnotations;

namespace BankWebApp.Models.ViewModel
{
    public class LoginForm
    {
        [Required]
        public string Number { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

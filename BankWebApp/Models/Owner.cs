using System.Security.Principal;

namespace BankWebApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public Account Account { get; set; }
    }
}

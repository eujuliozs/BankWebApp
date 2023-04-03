using BankWebApp.Models.Enums;
namespace BankWebApp.Models.ViewModel
{
    public class AccountMenuViewModel
    {
        public string AccNumber { get; set; }
        public Account Account { get; set; }
        public Owner Owner { get; set; }
        public List<TransactionType> Operations = Enum.GetValues(typeof(TransactionType)).Cast<TransactionType>().ToList();
    }
}

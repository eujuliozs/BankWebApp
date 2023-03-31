namespace BankWebApp.Models.Services.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
        public AccountNotFoundException(string message) : base(message) 
        {
            
        }
    }
}

namespace BankWebApp.Models.Service.Exception
{
    public class UnavalibleBalanceException : ApplicationException
    {
        public UnavalibleBalanceException(string message) : base(message)
        {
        }
    }
}

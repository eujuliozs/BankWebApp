namespace BankWebApp.Models.Services.Exceptions
{
    public class NotLoggedException : ApplicationException
    {
        public NotLoggedException(string message) : base(message)
        {

        }
    }
}

namespace BankWebApp.Models.Service.Exception
{
    public class DbAccountNotFoundException : ApplicationException
    {
        public DbAccountNotFoundException(string message) : base(message) 
        {
        }
    }
}

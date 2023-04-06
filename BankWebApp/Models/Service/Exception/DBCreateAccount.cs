namespace BankWebApp.Models.Service.Exception
{
    public class DBCreateAccount : ApplicationException
    {
        public DBCreateAccount(string message) : base(message) 
        { 
        }
    }
}

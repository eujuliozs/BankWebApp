using System.Drawing;

namespace BankWebApp.Models.Services.Exceptions
{
    public class WrongPasswordException : ApplicationException
    {
        public WrongPasswordException(string message) : base(message) 
        {
            
        }
    }
}

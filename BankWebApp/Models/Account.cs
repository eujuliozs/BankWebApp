using System.Collections.Generic;

namespace BankWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; } = 0;
        public string Number { get; private set; } = GenerateNumber();
        public int OwnerId { get; set; }
        public string Password { get; set; }
        public Account()
        {

        }
        public Account(int id, double balance, string number)
        {
            Id = id;
            Balance = balance;

        }
        static string GenerateNumber()
        {
            string lst = "";
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    lst += "-";
                }
                string str = random.Next(10).ToString();
                lst += str;
            }
            return lst.ToString();

        }

    }
}

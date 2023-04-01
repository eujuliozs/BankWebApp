using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace BankWebApp.Models
{
    public class Account 
    {
        public int Id { get; set; }
        public double? Balance { get; set; } = 0;
        public string Number { get; set; } = GenerateNumber();
        public int OwnerId { get; set; }
        public string Password { get; set; }
        public ICollection<TransactionRecord> Transactions { get; set; }
        public Account()
        {

        }
        public Account(int id, double balance)
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
        public override int GetHashCode()
        {
            return Id.GetHashCode() + Number.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(!(obj is Account)) return false;

            Account other = (Account)obj;
            if (Id == other.Id && Number == other.Number) return true;

            return false;
        }



    }
}

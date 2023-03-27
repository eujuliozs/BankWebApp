namespace BankWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Number { get; private set; } = GenerateNumber();
        public int OwnerId { get; set; }

        public Account(int id, double balance, string number, int ownerId)
        {
            Id = id;
            Balance = balance;
            Number = number;
            OwnerId = ownerId;
        }
        public static string GenerateNumber()
        {
            var rd = new Random();
            var list = new List<int>();
            for(int i = 0;i < 10; i++)
            {
                list.Add(rd.Next(10));
            }
            return list.ToString();
        }
    }
}

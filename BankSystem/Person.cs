using System.Collections.Generic;

namespace BankSystem
{
    public class Person
    {
        public string Name { get; set; }
        private string Password { get; set; }
        public int Age {get; set; }
        public int Money { get; set; } = 0;
        public int IdBankAccount { get; set; }
        private static int RN = 0;
        public List<StocksAndBonds.InfoStocks> StonksInventory = new List<StocksAndBonds.InfoStocks>();
        
        public Person()
        {
            Name = "No Data";
            Password = "No Data";
            Age = 0;
            IdBankAccount = 0;
        }

        public Person(string name, string password, int age)
        {
            Name = name;
            Password = password;
            Age = age;
            IdBankAccount = RN;
            RN++;
        }
    }
}
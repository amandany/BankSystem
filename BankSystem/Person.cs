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
        private int RN = 0;
        public readonly List<StocksAndBonds.InfoStocks> StonksInventory = new List<StocksAndBonds.InfoStocks>();

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
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            while (true)
            {
                bank.InitConsole();
                string command = Console.ReadLine();
                Console.WriteLine("Command is {0}", command);
                int com = Convert.ToInt32(command);
                if (com < 1 || com > 8)
                {
                    Console.WriteLine("You entered incorrect data");
                }
                else
                {
                    if ( com == 1)
                    {
                        bank.AddUser();
                    }
        
                    if (com == 2)
                    {
                        bank.TopUp();
                    }
                    if (com == 3)
                    {
                        bank.DeleteUser();

                    }
                    if (com == 4)
                    {
                        bank.TransferMoney();
                    }
    
                    if (com == 5)
                    {
                        bank.BuyStocks();
                    }
    
                    if (com == 6)
                    {
                        Console.WriteLine("Write your personal ID of Bank account");
                        string id = Console.ReadLine();
                        bank.ShowPersonalStocks(id);
                    }

                    if (com == 7)
                    {
                        bank.SoldStocks();
                    }
                    
                    if (com == 8)
                    {
                       bank.ShowAllUsers();
                    }
                }
            }
        }
    }
}
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
                        Console.WriteLine("Personal bank account was created!");
                    }
        
                    if (com == 2)
                    {
                        bank.TopUp();
                        Console.WriteLine("Your balance has been replenished");
                    }
                    if (com == 3)
                    {
                        bank.DeleteUser();
                        Console.WriteLine("Your account was deleted");
                    
                    }
                    if (com == 4)
                    {
                        bank.TransferMoney();
                        Console.WriteLine("Money was transferred");
                    }
    
                    if (com == 5)
                    {
                        bank.BuyStocks();
                        Console.WriteLine("You successfully bought stocks");
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
                        Console.WriteLine("You successfully sold stocks");
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
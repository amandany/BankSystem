using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    internal static class Program
    {
        static List<Person> people = new List<Person>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add New person \n" +
                                  "2. Top Up bank account \n" +
                                  "3. Delete you personal account \n" +
                                  "4. Transfer your money to another account \n" +
                                  "5. Buy Stocks and Bonds \n" +
                                  "6. List of your Stocks And Bonds \n" +
                                  "7. Sold Stocks \n" +
                                  "8. All Users of Bank System \n");
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
                        Console.WriteLine("Write your name");
                        string namePerson = Console.ReadLine();
                        Console.WriteLine("Write your password");
                        string passwordPerson = Console.ReadLine();
                        Console.WriteLine("Write your Age");
                        int agePerson = Convert.ToInt32(Console.ReadLine());
                        string status = "FALSE";
                        status = Add(namePerson, passwordPerson, agePerson);
                        if (status == "OK")
                        {
                            Console.WriteLine("Personal bank account was created!");
                        }
                        else if (status == "FALSE")
                        {
                            Console.WriteLine("ERRRRRRRRORRRRR");
                        }
                    }
        
                    if (com == 2)
                    {
                        Console.WriteLine("How much dollars top up?");
                        int reqForMoney = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write bank ID for top up");
                        int reqId = Convert.ToInt32(Console.ReadLine());
                        int idUser = people.FindIndex(x => x.IdBankAccount == reqId);
                        if (people.Exists(x => x.IdBankAccount == reqId))
                        {
                            people[idUser].Money = reqForMoney;
                        }
                        else
                        {
                            Console.WriteLine("ERROR");
                        }
                    }
                    if (com == 3)
                    {
                        Console.WriteLine("Write your Bank ID");
                        string userId = Console.ReadLine();
                        int id = Convert.ToInt32(userId);
                        Person idUser = people.Find(x => x.IdBankAccount == id);
                        if(people.Exists(x => x.IdBankAccount == id))
                        {
                            Console.WriteLine("removing {0}", idUser.IdBankAccount);
                            people.RemoveAt(idUser.IdBankAccount);
                            Console.WriteLine("END REMOVE");
                        }
                        else
                        {
                            Console.WriteLine("We didn't find your ID");
                        }
                    }
                    if (com == 4)
                    {
                        Console.WriteLine("Write your ID: ");
                        int firstId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write the recipient ID: ");
                        int secondId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How much would you send?");
                        int send = Convert.ToInt32(Console.ReadLine());
                        if (people.Exists(x => x.IdBankAccount == firstId) &&
                            people.Exists(x => x.IdBankAccount == secondId))
                        {
                            int indexFirstPerson = people.FindIndex(x => x.IdBankAccount == firstId);
                            int indexSecondPerson = people.FindIndex(x => x.IdBankAccount == secondId);
                            if (people[indexFirstPerson].Money > send)
                            {
                                people[indexFirstPerson].Money = people[indexFirstPerson].Money - send;
                                people[indexSecondPerson].Money = people[indexSecondPerson].Money + send;
                                Console.WriteLine("----TRANSACTION----");
                                Console.WriteLine("Name: {0} | Money: {1}$", people[indexFirstPerson].Name, people[indexFirstPerson].Money );
                                Console.WriteLine("Name: {0} | Money: {1}$", people[indexSecondPerson].Name, people[indexSecondPerson].Money );
                            }
                            else
                            {
                                Console.WriteLine("You dont have money for sending!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This ID didn't exist!");
                        }
                    }
    
                    if (com == 5)
                    {
                        StocksAndBonds temp = new StocksAndBonds();
                        Console.WriteLine("Number of stocks: {0}",temp.stock.Values.Count());
                        foreach (KeyValuePair<string, StocksAndBonds.InfoStocks> v in temp.stock)
                        {
                            Console.WriteLine("ID: {0} | Name: {1} | Current: {2}$ | Rise per day: {3} ", v.Value.ID ,v.Value.Name, v.Value.Current, v.Value.RisePerDay);
                        }
                        Console.WriteLine("Write ID of Stocks, which would you buy");
                        string reqOfBuyStr = Console.ReadLine();
                        int reqOfBuy = Convert.ToInt32(reqOfBuyStr);
                        if (reqOfBuyStr == "" || (reqOfBuy < 0 || reqOfBuy > 100))
                        {
                            Console.WriteLine("You entered incorrect data");
                        }
                        else
                        {
                            string reqOfBuyString = Convert.ToString(reqOfBuy);
                            if (!temp.stock.ContainsKey(reqOfBuyString))
                            {
                                Console.WriteLine("THIS ID DIDN'T EXIST ({0})", reqOfBuy);
                            }
                            else
                            {
                                Console.WriteLine("Write your personal ID of Bank account");
                                int id = Convert.ToInt32(Console.ReadLine());
                                if (people.Exists(x => x.IdBankAccount == id))
                                {
                                    if (reqOfBuy == temp.stock[reqOfBuyString].ID)
                                    {
                                        Person idUser = people.Find(x => x.IdBankAccount == id);
                                        if (idUser.Money >= temp.stock[reqOfBuyString].Current)
                                        {
                                            idUser.Money = idUser.Money - temp.stock[reqOfBuyString].Current;
                                            idUser.StonksInventory.Add(temp.stock[reqOfBuyString]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("you don't have such money in your account");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("We didn't find your ID");
                                }
                            }
                        }
                        
                    }
    
                    if (com == 6)
                    {
                        Console.WriteLine("Write your personal ID of Bank account");
                        string id = Console.ReadLine();
                        ShowPersonalStocks(id);
                    }

                    if (com == 7)
                    {
                        Console.WriteLine("Write your personal ID of Bank account");
                        string id = Console.ReadLine();
                        int idInt = Convert.ToInt32(id);
                        ShowPersonalStocks(id);
                        Console.WriteLine("Write ID of stocks which would you sold");
                        string soldIdStr = Console.ReadLine();
                        int soldId = Convert.ToInt32(soldIdStr);
                        Person idUser = people.Find(x => x.IdBankAccount == idInt);
                        StocksAndBonds temp = new StocksAndBonds();
                        idUser.Money = idUser.Money + temp.stock[soldIdStr].Current;
                        StocksAndBonds.InfoStocks soldIt = idUser.StonksInventory.Find(x => x.ID == soldId);
                        idUser.StonksInventory.Remove(soldIt);
                        ShowPersonalStocks(id);
                    }
                    
                    if (com == 8)
                    {
                        Console.WriteLine("------------------");
                        foreach (Person v in people)
                        {
                            Console.WriteLine("Name:{0}, Age:{1}, ID: {2}, Money: {3}$", v.Name, v.Age, v.IdBankAccount, v.Money);
                        }
                        Console.WriteLine("------------------");
                    }
                }
            }
        }

        static void ShowPersonalStocks(string personalId)
        {
            int id = Convert.ToInt32(personalId);
            Person idUser = people.Find(x => x.IdBankAccount == id);
            if (idUser.StonksInventory.Count == 0 )
            {
                Console.WriteLine("YOUR LIST OF STOCKS IS EMPTY!");
            }
            else
            {
                foreach (StocksAndBonds.InfoStocks v in idUser.StonksInventory)
                {                    
                    Console.WriteLine("YOUR LIST OF STOCKS");
                    Console.WriteLine("ID: {0} | Name: {1} | Current: {2}$ | Rise per day: {3}",
                        v.ID, v.Name, v.Current, v.ID);
                }
            }
        }
        
        static string Add(string name, string password, int age)
        {
            try
            {
                people.Add(new Person(name, password, age));
                return "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
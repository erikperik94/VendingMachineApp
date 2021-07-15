using System;
using System.Collections.Generic;
using VendingMachineConsoleApp.Model;

namespace VendingMachineConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool keepAlive = true;
            VendingMachine vendingMachine = new VendingMachine();
            while(keepAlive)
            {
                Console.Clear();
                ShowStore();
                Deposit(vendingMachine);
                Console.Clear();
                Purchase(vendingMachine);
                Console.Clear();
                Console.WriteLine($"Here is your \n{vendingMachine.UserMoney()}KR\nremaining.\nThank you for shopping with us!");
                keepAlive = false;
               
            }
        }
        public static void Deposit(VendingMachine vendingMachine)
        {
            bool keepAlive = true;
            bool validInt = false;
            int deposit = 0;

            Console.WriteLine("Deposit your money for the things you want to buy");
            while (keepAlive)
            {
                string userInput = Console.ReadLine();
                validInt = int.TryParse(userInput, out deposit);

                if (validInt)
                {
                    if (vendingMachine.InsertMoney(deposit))
                    {
                        Console.WriteLine("Hit enter to stop deposit or any other key to continue");
                        var stopDeposit = Console.ReadKey().Key;
                        if (stopDeposit == ConsoleKey.Enter)
                        {
                            keepAlive = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Not a valid denomination\n");
                    }
                }
                else
                {
                    Console.WriteLine("Hit enter to stop deposit");
                    var stopDeposit = Console.ReadKey().Key;
                    if (stopDeposit == ConsoleKey.Enter)
                    {
                        keepAlive = false;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
            }
        }
        public static void Purchase(VendingMachine vendingMachine)
        {
            bool keepAlive = true;
            bool validInt = false;
            int userChoice = 0;

            UserChoice();

            while (keepAlive)
            {
                UserChoice();
                ShowStore();
                Console.WriteLine($"You have {vendingMachine.UserMoney()}");
                string userInput = Console.ReadLine();
                validInt = int.TryParse(userInput, out userChoice);

                if (validInt)
                {
                    if (vendingMachine.Purchase(userChoice))
                    {
                        switch (userChoice)
                        {
                            case 1:
                                SparklingWater beverage1 = new SparklingWater(1, 5);
                                Console.WriteLine(beverage1.Use());
                                break;
                            case 2:
                                PepsiMAX beverage2 = new PepsiMAX(2,10);
                                Console.WriteLine(beverage2.Use());
                                break;
                            case 3:
                                Peanuts peanuts = new Peanuts(3, 15);
                                Console.WriteLine(peanuts.Use());
                                break;
                            default:
                                break;
                        }
                            
                        Console.WriteLine("Hit enter to buy all purchases or any other key to continue");
                        var stopPurchase = Console.ReadKey().Key;
                        if (stopPurchase == ConsoleKey.Enter)
                        {
                            keepAlive = false;
                        }
                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("Not a valid choice\n");
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid choice\n");
                    Console.WriteLine("Hit enter to stop choosing");
                    var stopDeposit = Console.ReadKey().Key;
                    if (stopDeposit == ConsoleKey.Enter)
                    {
                        keepAlive = false;
                    }
                }
            }
        }
        public static void ShowStore()
        {
            Console.WriteLine("---------PRICES--------");
            Console.WriteLine("    Sparkling Water: 5kr    ");
            Console.WriteLine("    PepsiMAX: 10kr    ");
            Console.WriteLine("    Peanuts: 15kr    ");
            Console.WriteLine("-----------------------");
        }
        public static void UserChoice()
        {
            Console.Clear();
            Console.WriteLine("Choose on item at a time");
            Console.WriteLine("  1 for Sparkling Water ");
            Console.WriteLine("  2 for PepsiMAX  ");
            Console.WriteLine("  3 for Peanuts  ");
        }
    }
}

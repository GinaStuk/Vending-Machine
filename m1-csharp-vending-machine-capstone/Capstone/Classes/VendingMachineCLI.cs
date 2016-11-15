using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        public void Run()
        {
            //stock machine
            Dictionary<string, Inventory> newStock = VMStocker.LoadStock();
            VendingMachine VendoMatic500 = new VendingMachine();
            VendoMatic500.Stock(newStock);
            Console.WriteLine("Welcome to the Vendo-Matic 500 ");
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine();
            Console.WriteLine("1.) Display Vending Machine Items");
            Console.WriteLine("2.) Purchase Item");

            //print menu
            int input = int.Parse(Console.ReadLine());
            while (input != 0)
            {
                //wait for user input
                if (input == 1)
                {
                    //print out VM menu
                    foreach (KeyValuePair<string, Inventory> kvp in VendoMatic500.GetInventory())
                    {
                        Console.WriteLine(kvp.Key + " " + kvp.Value.Item.Name + " " + kvp.Value.Item.Price + " " + kvp.Value.Quantity);
                    }
                }
                else
                {
                    //purchase
                    Console.WriteLine("Please select from the following options:");
                    Console.WriteLine("1.) Feed Money");
                    Console.WriteLine("2.)Select Product");
                    Console.WriteLine("3.)Finish Transaction");
                    int purchaseInput = int.Parse(Console.ReadLine());


                    if (purchaseInput == 1)
                    {
                        Console.WriteLine("Please insert your money.");
                        int cents = int.Parse(Console.ReadLine());
                        VendoMatic500.FeedMoney(cents);
                        Console.WriteLine("Your current balance is " + VendoMatic500.CurrentBalance);

                    }

                    //ask for slot id & dispense
                    else if (purchaseInput == 2)
                    {
                        foreach (KeyValuePair<string, Inventory> kvp in VendoMatic500.GetInventory())
                        {
                            Console.WriteLine(kvp.Key + " " + kvp.Value.Item.Name + " " + kvp.Value.Item.Price + " " + kvp.Value.Quantity);
                        }

                        Console.WriteLine("Please enter your selection.");
                        string slotID = Console.ReadLine();
                        if (newStock.ContainsKey(slotID) && newStock[slotID].Quantity > 0)
                            if (VendoMatic500.CurrentBalance > newStock[slotID].Item.Price)
                            {
                                VendoMatic500.Purchase(slotID);
                                Console.WriteLine("You purchased " + newStock[slotID].Item.Name);
                                Console.WriteLine("Your current balance is " + VendoMatic500.CurrentBalance);
                                int priorBalance = VendoMatic500.CurrentBalance + newStock[slotID].Item.Price;
                                TxWriter.Audit(newStock[slotID].Item.Name, priorBalance, VendoMatic500.CurrentBalance);
                            }
                            else
                            {
                                Console.WriteLine("Please enter more money.");
                            }
                        else
                        {
                            Console.WriteLine("Please enter another selection.");
                        }
                    }



                    //get change and print values
                    else if (purchaseInput == 3)
                    {
                        Console.WriteLine("Thank you for shopping the Vendo-Matic 500.");
                        Console.WriteLine($"Your change today in Quarters:" + " " + VendoMatic500.ReturnChange().Quarter);
                        Console.WriteLine($"Your change today in Dimes:" + " " + VendoMatic500.ReturnChange().Dimes);
                        Console.WriteLine($"Your change today in Nickles:" + " " + VendoMatic500.ReturnChange().Nickel);
                    }
                }

                    Console.WriteLine("Press any key");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Welcome to the Vendo-Matic 500 ");
                    Console.WriteLine("Please choose from one of the following options:");
                    Console.WriteLine();
                    Console.WriteLine("1.) Display Vending Machine Items");
                    Console.WriteLine("2.) Purchase Item");
                    input = int.Parse(Console.ReadLine());


                
            }

        }
    }
}

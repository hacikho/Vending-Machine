using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes.Exceptions;

namespace Capstone.Classes
{
    public class VendingMachineCLI : VendingMachine
    {
        private VendingMachine vm;
        private string Option_MakeSelection;
        private string Option_ReturnChange;
        private string Option_InsertMoney;
        private string Option_DisplayPurchaseMenu;
        private string Option_DisplayVendingMachine;
        private string Option_ReturnToPreviousMenu;
        private string Option_Quit;
        bool affordable;


        public VendingMachineCLI(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void DisplayInventory()
        {
            foreach(KeyValuePair<string, List<VendingMachineItem>> kvp in vm.inventory)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", kvp.Key, kvp.Value[0].ItemName, kvp.Value[0].PriceInCents, kvp.Value.Count);
                }
                else
                {
                    Console.WriteLine("{0} SOLD OUT", kvp.Key);
                }
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("----------Main Menu---------------");
            Console.WriteLine("Please make your selection: ");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Option_MakeSelection = Console.ReadLine();
            Console.WriteLine();

            if (Option_MakeSelection == "1")
            {
                DisplayInventory();
                Console.WriteLine();
            }
            else if(Option_MakeSelection == "2")
            {
                DisplayPurchaseMenu();
                Console.WriteLine();
            }
        }

        public void DisplayPurchaseMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("     -------------Purchase Menu--------------------");
                Console.WriteLine("     Please make your selection: ");
                Console.WriteLine("     Current Money Provided:  $" + vm.CurrentBalance);
                Console.WriteLine("     1) Feed Money");
                Console.WriteLine("     2) Select Product");
                Console.WriteLine("     3) Finish Transaction");
                Console.WriteLine("     4) Back to main menu");
                Option_MakeSelection = Console.ReadLine();
                Console.WriteLine();

                if (Option_MakeSelection == "1")
                {
                    Console.WriteLine("Please enter the number of dollars you want to feed into the vending machine: ");
                    vm.FeedMoney(int.Parse(Console.ReadLine()));
                    Console.WriteLine("     Current Money Provided:  $" + vm.CurrentBalance);
                    Console.WriteLine();
                }
                if (Option_MakeSelection == "2")
                {
                    Console.WriteLine("    Now enter a slot number to make your selection: ");
                    string check = Console.ReadLine();
                    
                    try
                    {
                        if (!inventory.ContainsKey(check))
                        {
                            throw new InvalidSlotIDException("That is not a valid slot");
                        }
                    }
                    catch(InvalidSlotIDException ex)
                    {

                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }
                    try
                    {
                        if(vm.GetQuantityRemaining(check) == 0)
                        {
                            throw new OutOfStockException(" Out of Stock");
                        }
                    }catch(OutOfStockException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }

                    try
                    {
                        affordable = vm.GetCostOfItem(check) <= vm.CurrentBalance;
                        if (!affordable)
                        {
                            throw new InsufficientFundsException("You dont have enough money");
                        }
                    }
                    catch (InsufficientFundsException ex)
                    {
                        Console.WriteLine(ex.Message);
                        DisplayPurchaseMenu();
                    }


                    vm.Purchase(check);
                    Console.WriteLine();
                }
                else if (Option_MakeSelection == "3")
                {
                    Console.WriteLine("     Thank you for your business!!!");
                    Console.WriteLine();
                    CalculateChange();
                    vm.ReturnChange();

                    Console.WriteLine();
                    for (int i=0; i< vm.consumeList.Count; i++)
                    {
                        Console.WriteLine(vm.consumeList[i]);
                        Console.WriteLine();
                    }
                    vm.consumeList.Clear();
                }
                else if (Option_MakeSelection == "4")
                {
                    flag = false;
                }
            }
        }

        public void CalculateChange()
        {
            Change result = new Change(vm.CurrentBalance);
            Console.Write($"{result.Quarters} Quarters {result.Dimes} Dimes {result.Nickels} Nickels");
        }

        public void Run()
        {
            while (true)
            {
                DisplayMainMenu();
                Console.WriteLine();
            }
        }
    }
}

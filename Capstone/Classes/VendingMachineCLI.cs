using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes.Exceptions;

namespace Capstone.Classes
{
    public class VendingMachineCLI
    {
        private VendingMachine vm;
        private string Option_MakeSelection;
        private string Option_ReturnChange;
        private string Option_InsertMoney;
        private string Option_DisplayPurchaseMenu;
        private string Option_DisplayVendingMachine;
        private string Option_ReturnToPreviousMenu;
        private string Option_Quit;
       
        public VendingMachineCLI(VendingMachine vm)
        {
            this.vm = vm;
        }

        public void DisplayInventory()
        {
            foreach(KeyValuePair<string, List<VendingMachineItem>> kvp in vm.inventory)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", kvp.Key, kvp.Value[0].ItemName, kvp.Value[0].PriceInCents, kvp.Value.Count);
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
                Console.WriteLine("     -------------Purchase Menu------");
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
                    //Console.WriteLine("     Your change is: " + vm.ReturnChange().Quarters + " quarters " + vm.ReturnChange().Dimes + " dimes " + vm.ReturnChange().Nickels + " nickels");  //need to finish
                    Console.WriteLine();
                }
                if (Option_MakeSelection == "2")
                {
                    try
                    {
                        Console.WriteLine("    Now enter a slot number to make your selection: ");
                        string check = Console.ReadLine();
                        vm.Purchase(check);
                    }
                    catch(OutOfStockException ex)
                    {
                        //OutOfStockException a = new OutOfStockException();
                        Console.WriteLine(ex.Message); 
                    }
                    
                    /*
                    if(vm.GetQuantityRemaining(check) == 0)
                    {
                        Console.WriteLine("Item is Sold Out");
                    }
                    else if(vm.GetQuantityRemaining(check) == -1)
                    {
                        
                    }
                    */
                    
                    Console.WriteLine();
                }
                else if (Option_MakeSelection == "3")
                {
                   // Console.WriteLine("Your change is $);
                    Console.WriteLine(vm.ReturnChange().Quarters + " quarters " + vm.ReturnChange().Dimes + " dimes " + vm.ReturnChange().Nickels);
                    
                    Console.WriteLine("     Thank you for your business!!!");
                    Console.WriteLine();
                    for(int i=0; i< vm.consumeList.Count; i++)
                    {
                        Console.WriteLine(vm.consumeList[i]);
                    }
                    vm.consumeList.Clear();

                }
                else if (Option_MakeSelection == "4")
                {
                    flag = false;
                }
            }
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

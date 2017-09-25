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
            Console.WriteLine("(3) Exit the Application");
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
            else if(Option_MakeSelection == "3")
            {
                SalesReport();
                Environment.Exit(0);
            }
        }

        private void SalesReport()
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            string filepath = Path.Combine(currentDirectory, "SalesReport.txt");
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            using (StreamWriter sw = new StreamWriter(filepath, true))
            { 
                sw.WriteLine("Potato Crisps     | " + (vm.inventory["A1"].Equals(null) ? 0 : vm.inventory["A1"].Count));
                sw.WriteLine("Stackers          | " + (vm.inventory["A2"].Equals(null) ? 0 : vm.inventory["A2"].Count));
                sw.WriteLine("Grain Waves       | " + (vm.inventory["A3"].Equals(null) ? 0 : vm.inventory["A3"].Count));
                sw.WriteLine("Cloud Popcorn     | " + (vm.inventory["A4"].Equals(null) ? 0 : vm.inventory["A4"].Count));
                sw.WriteLine("Moonpie           | " + (vm.inventory["B1"].Equals(null) ? 0 : vm.inventory["B1"].Count));
                sw.WriteLine("Cowtales          | " + (vm.inventory["B2"].Equals(null) ? 0 : vm.inventory["B2"].Count));
                sw.WriteLine("Wonka Bar         | " + (vm.inventory["B3"].Equals(null) ? 0 : vm.inventory["B3"].Count));
                sw.WriteLine("Crunchie          | " + (vm.inventory["B4"].Equals(null) ? 0 : vm.inventory["B4"].Count));
                sw.WriteLine("Cola              | " + (vm.inventory["C1"].Equals(null) ? 0 : vm.inventory["C1"].Count));
                sw.WriteLine("Dr.Salt           | " + (vm.inventory["C2"].Equals(null) ? 0 : vm.inventory["C2"].Count));
                sw.WriteLine("Mountain Melter   | " + (vm.inventory["C3"].Equals(null) ? 0 : vm.inventory["C3"].Count));
                sw.WriteLine("Heavy             | " + (vm.inventory["C4"].Equals(null) ? 0 : vm.inventory["C4"].Count));
                sw.WriteLine("U - Chews         | " + (vm.inventory["D1"].Equals(null) ? 0 : vm.inventory["D1"].Count));
                sw.WriteLine("Little League Chew| " + (vm.inventory["D2"].Equals(null) ? 0 : vm.inventory["D2"].Count));
                sw.WriteLine("Chiclets          | " + (vm.inventory["D3"].Equals(null) ? 0 : vm.inventory["D3"].Count));
                sw.WriteLine("Triplemint        | " + (vm.inventory["D4"].Equals(null) ? 0 : vm.inventory["D4"].Count));

                decimal totalSale = 0M;
                foreach (KeyValuePair<string, List<VendingMachineItem>> kvp in vm.inventory)
                {
                    if (kvp.Value.Count > 0)
                    {
                        totalSale += kvp.Value[0].PriceInCents * (5-kvp.Value.Count);
                    }
                    
                }
                sw.WriteLine("TOTAL SALE $" + totalSale);
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

                    InvalidSlotIDExceptionMethod(check);
                    OutOfStockExceptionMethod(check);
                    if (!(vm.GetQuantityRemaining(check) == 0))
                    {
                        InsufficienFunsExceptionMethod(check);
                    }

                    /*
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

                    */
                    if (inventory.ContainsKey(check) && !(vm.GetQuantityRemaining(check) == 0) && (vm.GetCostOfItem(check) <= vm.CurrentBalance))
                    {
                        vm.Purchase(check);
                    }
                    
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

        public void InvalidSlotIDExceptionMethod(string check)
        {
            try
            {
                if (!inventory.ContainsKey(check))
                {
                    throw new InvalidSlotIDException("That is not a valid slot");
                }
            }
            catch (InvalidSlotIDException ex)
            {

                Console.WriteLine(ex.Message);
                //DisplayPurchaseMenu();
            }
        }

        public void OutOfStockExceptionMethod(string check)
        {
            try
            {
                if (vm.GetQuantityRemaining(check) == 0)
                {
                    throw new OutOfStockException(" Out of Stock");
                }
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine(ex.Message);
                //DisplayPurchaseMenu();
            }
        }

        public void InsufficienFunsExceptionMethod(string check)
        {
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
                //DisplayPurchaseMenu();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Dictionary<string, List<VendingMachineItem>> inventory = vm.GetInventory();
            foreach(KeyValuePair<string, List<VendingMachineItem>> kvp in inventory)
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
            if(Option_MakeSelection == "1")
            {
                DisplayInventory();
            }else if(Option_MakeSelection == "2")
            {
                DisplayPurchaseMenu();
            }

        }

        public void DisplayPurchaseMenu()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("     -------------Purchase Menu------");
                Console.WriteLine("     Please make your selection: ");

                Console.WriteLine("     1) Feed Money");
                Console.WriteLine("     2) Select Product");
                Console.WriteLine("     3) Finish Transaction");
                Console.WriteLine("     4) Back to main menu");
                Option_MakeSelection = Console.ReadLine();

                if (Option_MakeSelection == "1")
                {
                    Console.WriteLine("     Please enter the amount you want to feed into the vending machine as a whole number: ");

                    vm.FeedMoney(int.Parse(Console.ReadLine()) * 100);
                    Console.WriteLine("     Current balance: " + vm.CurrentBalance);
                    Console.WriteLine("     Total change is: " + vm.ReturnChange().Quarters + " quarters " + vm.ReturnChange().Dimes + " dimes " + vm.ReturnChange().Nickels + " nickels");  //need to finish
                }
                if (Option_MakeSelection == "2")
                {
                    Console.WriteLine("     Please enter a slot number: ");
                }
                else if (Option_MakeSelection == "3")
                {
                    Console.WriteLine("     Thanks you for your business!!!");
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
            }
        }
    }
}

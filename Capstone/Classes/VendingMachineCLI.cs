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

        public void Run()
        {
            //while (true)
            //{
                DisplayInventory();
            //}
        }
    }
}

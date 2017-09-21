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
            foreach(KeyValuePair<>)
        }
    }
}

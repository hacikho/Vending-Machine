using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private decimal currentBalance;
        private Dictionary<string, List<VendingMachineItem>> inventory;
        InventoryFileDAL inventorySource;
        //private string getItemAtSlot;
        //private int feedDollars;
        //TransactionFileLog transactionLogger;

        public decimal CurrentBalance
        {
            get { return this.currentBalance; }
        }

        public string[] Slots
        {
            get { return this.inventory.Keys.ToArray(); }
        }

        public VendingMachine()
        {
            this.inventorySource = new InventoryFileDAL("vendingmachine.csv");
            this.inventory = this.inventorySource.GetInventory();
        }

        public VendingMachine(Dictionary<string, List<VendingMachineItem>> inventory)
        {
            this.inventory = inventory;
        }

        public void FeedMoney(int dollars)
        {
            this.currentBalance += dollars;
        }

        public Change ReturnChange()
        {
            int x = Convert.ToInt32(this.currentBalance);
            return new Change(x);

        }


        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            return this.inventory;
        }


        public VendingMachineItem Purchase(string slotID)
        {
            if (inventory.ContainsKey(slotID))
            {
                if(inventory[slotID].Count >=1 && this.currentBalance > inventory[slotID][0].PriceInCents)
                {
                    VendingMachineItem x = inventory[slotID][0];
                    inventory[slotID].RemoveAt(0);
                    return x;
                }
            }
            return null;
        }

        //public VendingMachineItem GetItemAtSlot(string slotId)
        //{
        //    return inventory[slotId].;
        //}
        //public VendingMachineItem GetItemAtSlot(string slotID)
        //{
        //    return ;
        //}








    }
}

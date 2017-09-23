﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Capstone.Classes.Exceptions;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private decimal currentBalance;
        public Dictionary<string, List<VendingMachineItem>> inventory;
        InventoryFileDAL inventorySource;
        //private string getItemAtSlot;
        //private int feedDollars;
        //TransactionFileLog transactionLogger;
        //consume message
        public List<string> consumeList = new List<string>();
        //

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
            this.currentBalance = 0;
            return new Change(x);

        }


        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            return this.inventory;
        }


        public VendingMachineItem Purchase(string slotID)
        {
            try
            {
                if (inventory.ContainsKey(slotID))
                {
                    if (inventory[slotID].Count() >= 1 && this.currentBalance >= inventory[slotID][0].PriceInCents)
                    {
                        consumeList.Add(inventory[slotID][0].Consume());

                        VendingMachineItem x = inventory[slotID][0];
                        this.currentBalance -= inventory[slotID][0].PriceInCents;
                        inventory[slotID].RemoveAt(0);
                        return x;
                    }
                }
              
                
            }
            catch(Exception ex)
            {
                InvalidSlotIDException x = new InvalidSlotIDException();
                //x.message;

            }
            
            return null;
        }

        public int GetQuantityRemaining(string slotId)
        {
            if (inventory.ContainsKey(slotId))
            {
                int remainingQuantity = inventory[slotId].Count;
                return remainingQuantity;
            }
            else
            {
                return -1;
            }
        }

        
     
        
    }
}

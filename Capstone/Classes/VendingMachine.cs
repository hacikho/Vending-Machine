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
        TransactionFileLog transactionLogger = new TransactionFileLog("Log.txt");
        public List<string> consumeList = new List<string>();
        public List<decimal> saleResportList = new List<decimal>();
        

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
            this.transactionLogger.RecordDeposit(dollars, this.currentBalance);
            
        }

        public Change ReturnChange()
        {
            //int x = Convert.ToInt32(this.currentBalance);
            Change a = new Change(this.currentBalance);
            
            transactionLogger.RecordCompleteTransaction(this.currentBalance);
            this.currentBalance = 0;
            return a;
        }


        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            return this.inventory;
        }


        public VendingMachineItem Purchase(string slotID)
        {
          
                if (inventory.ContainsKey(slotID))
                {
                    if (inventory[slotID].Count() >= 1 && this.currentBalance >= inventory[slotID][0].PriceInCents)
                    {
                        saleResportList.Add(inventory[slotID][0].PriceInCents);
                        this.transactionLogger.RecordPurchase(inventory[slotID][0].ItemName, slotID, this.currentBalance, this.currentBalance -= inventory[slotID][0].PriceInCents);
                        
                        consumeList.Add(inventory[slotID][0].Consume());
                        VendingMachineItem x = inventory[slotID][0];
                        inventory[slotID].RemoveAt(0);
                        return x;
                    }
                }
                else
                {
                    throw new InvalidSlotIDException(" is not a valid choice");
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

        public decimal GetCostOfItem(string slotID)
        {
            return inventory[slotID][0].PriceInCents;
        }
     
        
    }
}

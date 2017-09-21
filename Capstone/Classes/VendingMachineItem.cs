using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingMachineItem
    {
        //Fields
        private string itemName;
        private decimal priceInCents;

        //Properties
        public string ItemName
        {
            get { return this.itemName; }
        }

        public decimal PriceInCents
        {
            get { return this.priceInCents; }
        }

        //constructor
        public VendingMachineItem(string itemName, decimal price)
        {
            this.itemName = itemName;
            this.priceInCents = price;
        }

        //abstract method
        public abstract string Consume();

    }
}

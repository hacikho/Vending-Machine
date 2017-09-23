
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int dimes;
        private int nickels;
        private int quarters;
        //private double totalChange;

        public int Dimes
        {
            get { return this.dimes; }
        }

        public int Nickels
        {
            get { return this.nickels; }
        }

        public int Quarters
        {
            get { return this.quarters; }
        }

        public decimal TotalChange
        {
            get { return (decimal)(this.quarters * 25 + this.dimes * 10 + this.nickels * 5); }
        }

        public Change(decimal amountInDollars)
        {
            if(amountInDollars>= 0.25M)
            {
                this.quarters = (int)(amountInDollars / 0.25M);
                amountInDollars = amountInDollars % 0.25M;
            }
            if(amountInDollars >= 0.10M)
            {
                this.dimes = (int)(amountInDollars / 0.10M);
                amountInDollars = amountInDollars % 0.10M;
            }
            if(amountInDollars >= 0.05M)
            {
                this.nickels = (int)(amountInDollars / 0.05M);
                amountInDollars = amountInDollars % 0.05M;
            }
            
        }
    }
}

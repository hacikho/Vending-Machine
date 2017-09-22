
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

        public Change(decimal amountInDollar)
        {
            if(amountInDollar>= 0.25M)
            {
                this.quarters = (int)(amountInDollar / 0.25M);
                amountInDollar = amountInDollar % 0.25M;
            }
            if(amountInDollar >= 0.10M)
            {
                this.dimes = (int)(amountInDollar / 0.10M);
                amountInDollar = amountInDollar % 0.10M;
            }
            if(amountInDollar >= 0.05M)
            {
                this.nickels = (int)(amountInDollar / 0.05M);
                amountInDollar = amountInDollar % 0.05M;
            }
            
        }
    }
}

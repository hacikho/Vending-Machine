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

        public double TotalChange
        {
            get { return (this.quarters * 25 + this.dimes * 10 + this.nickels * 5); }
        }

        public Change(decimal amountInDollars)
        {
            amountInDollars = amountInDollars * 100;
            while(amountInDollars >= 25)
            {
                this.quarters++;
                amountInDollars = amountInDollars - 25;
            }

            while(amountInDollars >= 10)
            {
                this.dimes++;
                amountInDollars = amountInDollars - 10;
            }

            if(amountInDollars >= 5)
            {
                this.nickels++;
                amountInDollars = amountInDollars - 5;
            }
        }

        public Change(int amountInCents)
        {
            //amountInDollars = amountInDollars * 100;
            while (amountInCents >= 25)
            {
                this.quarters++;
                amountInCents = amountInCents - 25;
            }

            while (amountInCents >= 10)
            {
                this.dimes++;
                amountInCents = amountInCents - 10;
            }

            if (amountInCents >= 5)
            {
                this.nickels++;
                amountInCents = amountInCents - 5;
            }
        }
    }
}

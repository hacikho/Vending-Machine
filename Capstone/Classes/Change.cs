﻿
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

        public Change(int amountInCents)
        {
            if(amountInCents>= 25)
            {
                this.quarters = amountInCents / 25;
                amountInCents = amountInCents % 25;
            }
            if(amountInCents >= 10)
            {
                this.dimes = amountInCents / 10;
                amountInCents = amountInCents % 10;
            }
            if(amountInCents >= 5)
            {
                this.nickels = amountInCents / 5;
                amountInCents = amountInCents % 5;
            }
            
        }
    }
}

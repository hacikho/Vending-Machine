
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
        private double totalChange;

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
            get { return this.totalChange; }
        }

        public Change(decimal amountInDollars, int amountInCents)
        {
           
        }

        public Change(decimal amountInDollars, int amountInCents)
        {

        }

        ////We need to check into this one
        //public void Equals(Change amountInDollars, Change amountInCents)
        //{

        //}

    }
}

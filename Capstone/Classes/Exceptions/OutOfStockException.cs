﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes.Exceptions
{
    public class OutOfStockException : VendingMachineException
    {
        private string message;

        public override string Message
        {
            get { return "Out of Stock"; }
        }

    }
}

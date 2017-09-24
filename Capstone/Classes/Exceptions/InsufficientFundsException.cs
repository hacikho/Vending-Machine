using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes.Exceptions
{
    class InsufficientFundsException: VendingMachineException
    {
        public InsufficientFundsException(string message)
            :base (message)
        {

        }
    }
}

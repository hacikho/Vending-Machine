﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            //InventoryFileDAL newInventory = new InventoryFileDAL("vendingmachine.csv");
            //Dictionary<string, List<VendingMachineItem>> inventory = newInventory.GetInventory
            VendingMachine vm = new VendingMachine();
            VendingMachineCLI x = new VendingMachineCLI(vm);
            x.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    class InventoryFileDAL
    {
        private int Cost;
        private string filepath;
        private int InitialQuantity;
        private int Product;
        private int SlotId;

        private int myVar;

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            filepath = Path.Combine(Directory.GetCurrentDirectory(), "vendingmachine.csv");
            List<VendingMachineItem> vmList = new List<VendingMachineItem>();
            Dictionary<string, List<VendingMachineItem>> vmDictionary = new Dictionary<string, List<VendingMachineItem>>();
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] slotArray = line.Split('|');

                    ChipItem chipOne = new ChipItem(slotArray[1], Decimal.Parse(slotArray[2]));
                    vmList.Add(chipOne);
                    ChipItem chipTwo = new ChipItem(slotArray[1], Decimal.Parse(slotArray[2]));
                    vmList.Add(chipTwo);
                    ChipItem chipThree = new ChipItem(slotArray[1], Decimal.Parse(slotArray[2]));
                    vmList.Add(chipThree);
                    ChipItem chipFour = new ChipItem(slotArray[1], Decimal.Parse(slotArray[2]));
                    vmList.Add(chipFour);
                    ChipItem chipFive = new ChipItem(slotArray[1], Decimal.Parse(slotArray[2]));
                    vmList.Add(chipFive);




                    vmDictionary[slotArray[0]] = vmList;
                }
            }
        }

     





    }
}

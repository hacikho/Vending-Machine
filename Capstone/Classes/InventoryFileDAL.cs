using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class InventoryFileDAL
    {
        private int Cost;
        private string fpath;
        private int InitialQuantity;
        private int Product;
        private int SlotId;
        private int myVar;

        public InventoryFileDAL(string filePath)
        {
            this.fpath = filePath;
        }

        public Dictionary<string, List<VendingMachineItem>> GetInventory()
        {
            fpath = Path.Combine(Directory.GetCurrentDirectory(), fpath);
            Dictionary<string, List<VendingMachineItem>> vmDictionary = new Dictionary<string, List<VendingMachineItem>>();
            using (StreamReader sr = new StreamReader(fpath))
            {
                int lineCounter = 1;
                while (!sr.EndOfStream)
                {
                    List<VendingMachineItem> vmList = new List<VendingMachineItem>();

                    
                    string line = sr.ReadLine();
                    string[] slotArray = line.Split('|');

                    if (lineCounter >= 1 && lineCounter <= 4)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            vmList.Add(new ChipItem(slotArray[1], Decimal.Parse(slotArray[2])));
                        }
                        vmDictionary[slotArray[0]] = vmList;
                    }
                    else if(lineCounter > 4 && lineCounter <= 8)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            vmList.Add(new CandyItem(slotArray[1], Decimal.Parse(slotArray[2])));
                        }
                        vmDictionary[slotArray[0]] = vmList;
                    }
                    else if(lineCounter > 8 && lineCounter <= 12)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            vmList.Add(new BeverageItem(slotArray[1], Decimal.Parse(slotArray[2])));
                        }
                        vmDictionary[slotArray[0]] = vmList;
                    }
                    else if(lineCounter > 12 && lineCounter <= 16)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            vmList.Add(new GumItem(slotArray[1], Decimal.Parse(slotArray[2])));
                        }
                        vmDictionary[slotArray[0]] = vmList;
                    }
                    lineCounter++;
                }
                return vmDictionary;
            }
        }
    }
}

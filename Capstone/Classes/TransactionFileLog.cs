using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class TransactionFileLog 
    {
        string filepath;


        public TransactionFileLog(string filePath)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            filepath = Path.Combine(currentDirectory, filePath);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

        }        


        public void RecordCompleteTransaction(decimal initialAmount)
        {
            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}  GIVE CHANGE:  ${initialAmount}  $0.00");
            }
        }

        public void RecordDeposit(decimal depositAmount, decimal finalBalance)
        {
            using(StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}  FEED MONEY:         ${depositAmount}  ${finalBalance}");
            }
        }

        public void RecordPurchase(string productName, string slotId, decimal initialBalance, decimal finalBalance)
        {
            using (StreamWriter sw = new StreamWriter(filepath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow}  {productName}  {slotId}  ${initialBalance}  ${finalBalance}");
            }
        }
       
    }
}

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
        string fullPath;
        //public DateTime DateTimeStamp
        //{
           // string timestamp = new DateTime.Now;

        //    get { return timestamp; }
        //    set { timestamp = value; }
        //}

        public void RecordCompleteTransaction(decimal initialAmount)
        {
            //get { .initialAmount; }
        }

        public void RecordDeposit(decimal depositAmount, decimal finalBalance)
        {
            WriteTransaction("this is " + depositAmount + " something" + finalBalance);

            //get { .depositAmount; }
            //get { .finalBalance; }
        }

        public void RecordPurchase(string productName, string slotId, decimal initialBalance, decimal finalBalance)
        {
            //get { .productName; }
            //get { .slotId; }
            //get { .initialBalance; }
            //get { .finalBalance; }
        }

        public void WriteTransaction(string message)
        {
            using(StreamWriter sw = new StreamWriter(fullPath))
            {
                sw.WriteLine(message);
            }      
        }

        public TransactionFileLog(string filepath)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filename = "Log.txt";
            this.fullPath = Path.Combine(currentDirectory, filename);

            //try
            //{
            //    using (StreamWriter sw = new StreamWriter(fullPath))
            //    {

            //        for (int i = 1; i < ; i++)
            //        {
            //            if ()
            //            {
            //                sw.WriteLine("");
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("" + ex.Message);
            //}
            
        }

    }
}

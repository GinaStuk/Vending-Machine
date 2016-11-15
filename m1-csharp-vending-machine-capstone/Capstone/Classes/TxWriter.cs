using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class TxWriter
    {
        public static void Audit(string item, double balance, double change)
        {
            string directory = Environment.CurrentDirectory;
            string filePath = "TransactionLog.txt";
            string fullPath = Path.Combine(directory, filePath);
            string currentTime = DateTime.Now.ToString();

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(currentTime + "|" + item + "|" + balance + "|" + change);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


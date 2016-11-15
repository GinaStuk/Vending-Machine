using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VMStocker
    {
        public static Dictionary<string, Inventory> LoadStock()
        {
            Dictionary<string, Inventory> fullInventory = new Dictionary<string, Inventory>();
            string directory = Environment.CurrentDirectory;
            string filePath = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, filePath);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split('|');
                        VMItem item = new VMItem(parts[1],(int)(double.Parse(parts[2])*100));
                        Inventory inventory = new Inventory(item, 5);
                        fullInventory.Add(parts[0], inventory);

                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }
            return fullInventory;
        }

    }
}

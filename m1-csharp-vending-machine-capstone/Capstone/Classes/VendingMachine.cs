using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine

    {
        //properties
      
        private Dictionary<string, Inventory> fullInventory= new Dictionary<string, Inventory>();
        private int currentBalance;

        public int CurrentBalance
        {
            get { return currentBalance; }
            
        }
        //Methods
        public void Stock(Dictionary<string, Inventory> newStock)
        {
            fullInventory = newStock;


        }
        public void FeedMoney(int cents)
        {
            currentBalance += cents ;
            
        }
        public Change ReturnChange()
        {
            Change returnedChange = new Change(currentBalance);
            currentBalance = 0;
            return returnedChange;
        }
        public Dictionary<string, Inventory> GetInventory()
        {
            return fullInventory;
        }

        public VMItem Purchase(string slotID)
        {
            Inventory product = fullInventory[slotID];
            VMItem item = product.Item;
            int price = item.Price;

            product.Quantity -= 1;
            currentBalance -= price;


            return item;
        }

        public VendingMachine()
        {
            
        }
    }
}

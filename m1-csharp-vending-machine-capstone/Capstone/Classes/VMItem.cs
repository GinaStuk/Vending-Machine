using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class VMItem
    {
        private string name;

        public string Name
        {
            get { return name; }
            
        }
        private int price;

        public int Price
        {
            get { return price; }
            
        }
        public VMItem (string itemName , int itemPrice)
        {
            name = itemName;
            price = itemPrice;
        }
    }
}

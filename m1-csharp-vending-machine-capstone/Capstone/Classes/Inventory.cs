﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Inventory
    {
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
            //check if setter needed
        }
        private VMItem item;
        public VMItem Item
        {
            get { return item; }
        }
        public Inventory (VMItem listItem , int itemQuantity)
        {
            quantity = itemQuantity;
            item = listItem;
            
        }
    }
}

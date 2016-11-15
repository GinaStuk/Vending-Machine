using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int quarter;

        public int Quarter
        {
            get { return quarter; }
            
        }
        private int dime;

        public int Dimes
        {
            get { return dime; }
            
        }
        private int nickel;

        public int Nickel
        {
            get { return nickel; }
            
        }

        public Change (int amountInCents)
        {
            while(amountInCents > 0)
            {
                if(amountInCents >= 25)
                {
                    amountInCents -= 25;
                    quarter += 1;
                }
                else if (amountInCents < 25 && amountInCents >= 10)
                {
                    amountInCents -= 10;
                    dime += 1;
                }
                else
                {
                    amountInCents -= 5;
                    nickel += 1;
                }
            }
            
        }
        public Change()
        {
            ;
        }

    }
}

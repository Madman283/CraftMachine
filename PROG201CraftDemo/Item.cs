using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG201CraftDemo
{
    internal class Item
    {

        public string Name { get; set; }    
        public double Amount { get; set; }
        public string AmountType = "cup(s)";
        public int Cost = 0;

        public List<Item> MustR { get; set; }

        public string ShowItemDetails()
        {
            string output = $"{Name}";
            int number = 1;
            foreach (Item i in MustR)
            {
                output += $"         {number}) {i.Amount} {i.AmountType} of {i.Name}\n";
                number++;
            }
            return output;
        }

    }
}

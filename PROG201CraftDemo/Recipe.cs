using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG201CraftDemo
{
    internal class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Item> Requirements { get; set; }

        public string ShowRecipeDetails()
        {
            string output = $"{Name}: {Description}\n     Ingredients: \n";
            int number = 1;
            foreach (Item i in Requirements)
            {
                output += $"         {number}) {i.Amount} {i.AmountType} of {i.Name}\n";
                number++;
            }
            return output;
        }

    }
}

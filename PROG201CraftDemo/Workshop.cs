using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG201CraftDemo
{
    internal class Workshop
    {
        public List<Recipe> Recipes = new List<Recipe>();
       

        public Player player = new Player() {Inventory = new List<Item> 
        { 
            new Item() {Name="Chocolate", Amount = 3, AmountType = "pound(s)"},
            new Item() {Name="Water", Amount = 10, AmountType = "cup(s)"},
            new Item() {Name = "Powdered Sugar", Amount = 1, AmountType="cup" },
            new Item() {Name = "Vanilla Extract", Amount = 1.5, AmountType="tsp" },
            new Item() {Name = "Milk", Amount = 2, AmountType="tbsp" },
            new Item() {Name = "Flour", Amount = 3, AmountType="cup"},
            new Item() {Name = "Eggs", Amount = 3, AmountType="unit"}
             } };
        
        public Player vendor = new Player()
        {
            Inventory = new List<Item>
        {
            new Item() {Name="Chocolate", Amount = 3, AmountType = "pound(s)", Cost = 2},
            new Item() {Name="Water", Amount = 10, AmountType = "cup(s)", Cost = 2},
            new Item() {Name = "Powdered Sugar", Amount = 1, AmountType="cup", Cost = 2 },
            new Item() {Name = "Vanilla Extract", Amount = 1.5, AmountType="tsp", Cost = 2 },
            new Item() {Name = "Milk", Amount = 2, AmountType="tbsp", Cost = 2 },
            new Item() {Name = "Sugar", Amount = 4, AmountType="cup", Cost= 2 },
            new Item(){Name = "Flour", Amount = 3, AmountType="cup", Cost= 2 },
            new Item(){Name = "Eggs", Amount = 2, AmountType="unit", Cost= 2 }
             }
        };

        public Workshop()
        {
          SetPlayerName("Anonymous Player");
            Recipes.Add(
                new Recipe()
                {
                    Name = "Powdered Sugar Icing",
                    Description = "Tasty icing that can be used with many recipes.",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Powdered Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Vanilla Extract", Amount = 1.5, AmountType="tsp" },
                        new Item(){Name = "Milk", Amount = 2, AmountType="tbsp" }
                    },

                }
                ) ;

            Recipes.Add(
                new Recipe()
                {
                    Name = "Whipped Cream",
                    Description = "Tasty whipped cream that can be used with many recipes.",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Milk", Amount = 2, AmountType="tbsp" }
                    },

                }
                );

            Recipes.Add(
                new Recipe()
                {
                    Name = "Cake Batter",
                    Description = "Batter that can be used to make cake.",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Flour", Amount = 3, AmountType="cup" },
                        new Item(){Name = "Eggs", Amount = 2, AmountType="unit" }
                    },

                }
                );
            Recipes.Add(
                new Recipe()
                {
                    Name = "Chocolate Milk",
                    Description = "Tasty milk!",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Flour", Amount = 3, AmountType="cup" },
                        new Item(){Name = "Eggs", Amount = 2, AmountType="unit" }
                    },

                }
                );
            Recipes.Add(
                new Recipe()
                {
                    Name = "Ice Cream",
                    Description = "What a tasty treat!",
                    Requirements = new List<Item>()
                    {
                        new Item(){Name = "Sugar", Amount = 1, AmountType="cup" },
                        new Item(){Name = "Flour", Amount = 3, AmountType="cup" },
                        new Item(){Name = "Eggs", Amount = 2, AmountType="unit" }
                    },

                }
                );
        }
        public string CreateNewItem()
        {
            string output = "What would you like to craft?\n";
            
            output += ShowRecipeNames();
      
            return output;

            

        }
        //public string Trade()
        //{
        //    return "\nTrade is not yet functional.\n";
        //}
        public string ShowRecipes()
        {
            string output = "Recipes:\n";
            foreach (Recipe r in Recipes)
            {
                output += $"  * {r.ShowRecipeDetails()}\n";
            }
            return output;
        }
        //ShowPlayerInventory looks a lot like ShowRecipes
        //Can you refactor so that there is less redundent code?
        public string ShowPlayerInventory()
        {
            string output = $"Current inventory:\n";
            foreach (Item i in player.Inventory)
            {
                output += $"  * {i.Name} ({i.Amount})\n";
            }
            return output;
        }

        public string ShowRecipeNames()
        {
            int number = 1;
            string output = "Recipes:\n";
            foreach (Recipe r in Recipes)
            {
                output += $"  {number} {r.Name}\n";
                number++;
            }
            return output;
        }

        public string AllowCrafting()
        {
            string output = "What would you like to craft?\n";
            output += ShowRecipeNames();
           
            return output;
        }

        public string AllowTrade()
        {
            int number = 1;
            string output = "Items:\n";
            foreach (Item i in vendor.Inventory)
            {
                if (i.Amount > 0)
                {
                    output += $"  {number} {i.Name} {i.Amount} {i.Cost.ToString("c")}\n";
                    number++;
                }
                
            }
            return output;
        }

        public string ShowPlayerName() => player.Name;
        public string ShowPlayerNameAndCurrency() => $"{player.Name} {player.Currency.ToString("c")}";
        public void SetPlayerName(string name) { player.Name = name; }

    }
}

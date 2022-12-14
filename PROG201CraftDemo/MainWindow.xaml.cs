using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG201CraftDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /* Craft Project made by Brandon Figueroa.
     * 11/6/22
     * 
     * Credit to Jenell Baxter AKA my teacher, helped me create most of the coding done in this project.
     * Credit to Duncan McDonald, helped me create a button for the player to be able to go back to the main menu.
     */
  
    public partial class MainWindow : Window
    {
        Workshop workshop = new Workshop();
        bool SetUp = true;
        bool Crafting = false;
        bool Trading = false;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            GetPlayerName();
            
        }
        private void RefreshInformationDisplays()
        {
            PlayerInventory.Text = workshop.ShowPlayerInventory();
            PlayerName.Text = workshop.ShowPlayerNameAndCurrency();
        }
        private void GetPlayerName()
        {
            ConsoleOutput.Text = "Hello!\nPlease enter your name in the box below and then click the submit button.";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (SetUp)
            {
                if (ConsoleInput.Text != "")
                workshop.SetPlayerName(ConsoleInput.Text);

                SetUp = false;
                ConsoleOutput.Text ="";
                ShowMenu();
                RefreshInformationDisplays();
                ConsoleInput.Text = "";
                return;
            }
            else if (Trading)
            {


                string n = ConsoleInput.Text;

                if (!Int32.TryParse(n, out int i)) return;

                int itemNumber = --i;

                if (workshop.player.Currency >= workshop.vendor.Inventory[itemNumber].Cost)
                {
                    foreach (var merch in workshop.player.Inventory)
                    {
                        if (workshop.vendor.Inventory[itemNumber].Name == merch.Name)
                        {
                            if (workshop.vendor.Inventory[itemNumber].Amount >= 1)
                            {
                                merch.Amount++;
                                workshop.vendor.Inventory[itemNumber].Amount--;
                                workshop.player.Currency -= workshop.vendor.Inventory[itemNumber].Cost;
                                workshop.vendor.Currency += workshop.vendor.Inventory[itemNumber].Cost;
                            }
                            
                            
                        }
                    }
                }

                RefreshInformationDisplays();
                ConsoleOutput.Text = workshop.AllowTrade();


            }
            else if (Crafting)
            {
                //get player input
                string n = ConsoleInput.Text;
                //Convert string to int
                //int i = Convert.ToInt32(n);

                if(!Int32.TryParse(n, out int i)) return;


                //-1 from the int
                int recipeNumber = --i;

                //get recipe from that number
                Recipe recipe = new Recipe();
                //get recipe requirements
                bool hasR = false;
                recipe = workshop.Recipes[recipeNumber];
                //check player inventory for required items
                foreach (var ingredient in recipe.Requirements)
                {
                    foreach (var item in workshop.player.Inventory)
                    {
                        if (ingredient.Name == item.Name)
                        {
                            if (item.Amount >= ingredient.Amount)
                            {
                                hasR = true;

                            }
                            else
                            {
                                hasR = false;
                            }
                            


                        }
                        else
                        {
                            //hasR = false;
                        }
                    }
                }
                //check if player has equal or greater amount for each requirement
                //if player meets requirements, allow craft
                if (hasR == true)
                {
                    foreach (var ingredient in recipe.Requirements)
                    {
                        foreach (var item in workshop.player.Inventory)
                        {
                            if (ingredient.Name == item.Name)
                            {
                                item.Amount = item.Amount - ingredient.Amount;
                            }
                        }
                    }
                    ConsoleOutput.Text = $"{workshop.player.Name} has created {recipe.Name}";
                    workshop.player.Inventory.Add(new Item() { Name = recipe.Name, Amount = 1});
                    RefreshInformationDisplays();
                }
                else
                {
                    ConsoleOutput.Text = "Hey!\nYou do not have the items you need..";
                    //what would happen if they did not have items needed.
                }
                //when crafted, subtract the amount of required materials from player inventory
                
                //place crafted item into player inventory
                //Print to the player they have crafted
                //Print how much materials they have left
            }
            else
            {
                switch (ConsoleInput.Text)
                {
                    case "1":
                        Crafting = true;
                        ConsoleOutput.Text = workshop.AllowCrafting();

                        
                        //allow player to go back to the menu
                        Pause();
                        break;
                    case "2":
                        Trading = true;
                        ConsoleOutput.Text = workshop.AllowTrade();
                        Pause();
                        break;
                    case "3":
                        ConsoleOutput.Text = workshop.ShowRecipes();
                        Pause();
                        break;
                    case "m":
                        ShowMenu();
                        break;
                    default:
                        ConsoleOutput.Text += "Please enter only 1, 2, or 3.\n";
                        break;

                }

            }
            
            

            ConsoleInput.Text = "";
        }
        private void Pause()
        {
            ConsoleOutput.Text += "Enter m in the box below to return to the main menu.";
        }
        private void ShowMenu()
        {
            string output = $"{workshop.ShowPlayerName()}, what would you like to do?\n1) Create a new item\n2) Trade\n3) See all recipes\n";
            output += "Please enter 1, 2, or 3 in the box below and then click the submit button\n\n";
            ConsoleOutput.Text = output;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Crafting = false;
            Trading = false;
            ShowMenu();
        }
    }
}

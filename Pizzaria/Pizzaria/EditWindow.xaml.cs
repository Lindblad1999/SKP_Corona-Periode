using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pizzaria.Enums;

namespace Pizzaria
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Pizza pizza;

        public EditWindow(Pizza pizza)
        {
            InitializeComponent();
            //sets the local pizza to be the pizza passed in the constructor
            this.pizza = pizza;
            //sets the pizza label to be the name of the pizza passed in the constructor
            lblPizzaName.Content = pizza.Name;

            UpdateListBoxes();
            //sets the price label to be the price of the current pizzas price
            lblPrice.Content = $"Price: {pizza.CurrentPrice}";

            //sets the selected item of both list boxes to the first item as default
            listBoxAllIngredients.SelectedIndex = 0;
            listBoxCurrentIngredients.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds the selected ingredient, to the current pizzas ingredient list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //adds the selected ingredient to the current pizzas ingredients
            pizza.Ingredients.Add((Ingredients)listBoxAllIngredients.SelectedIndex);
            //adds the ingredients price to the total price
            pizza.CurrentPrice += IngredientPrices.prices[listBoxAllIngredients.SelectedIndex];
            UpdateListBoxes();
            //updates the price label to the pizzas current price
            lblPrice.Content = $"Price: {pizza.CurrentPrice}";

            //sets the selected item of both list boxes to the first item as default
            listBoxCurrentIngredients.SelectedIndex = 0;
            listBoxAllIngredients.SelectedIndex = 0;
        }

        /// <summary>
        /// Removes the selected ingredient, from the current pizzas ingredient list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //checks if the pizza has ingredients in it already
            if (listBoxCurrentIngredients.Items.Count > 0)
            {
                //removes the value of the selected ingredient form the total price
                pizza.CurrentPrice -= int.Parse(listBoxCurrentIngredients.SelectedItem.ToString().Split(' ')[1]);
                //removes the ingredient selected
                pizza.Ingredients.RemoveAt(listBoxCurrentIngredients.SelectedIndex);
                UpdateListBoxes();
                //updates the price label to the pizzas current price
                lblPrice.Content = $"Price: {pizza.CurrentPrice}";

                //sets the selected item of both list boxes to the first item as default
                listBoxCurrentIngredients.SelectedIndex = 0;
                listBoxAllIngredients.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Updates the content of the 2 list boxes.
        /// </summary>
        private void UpdateListBoxes()
        {
            //Clears the content of both list boxes
            listBoxAllIngredients.Items.Clear();
            listBoxCurrentIngredients.Items.Clear();

            //loops through all the ingredients in the Ingrediets enum, and adds them to the all ingredients listbox
            int counter = 0;
            foreach (string s in Enum.GetNames(typeof(Ingredients)))
            {
                listBoxAllIngredients.Items.Add($"{s} {IngredientPrices.prices[counter]} kr.");
                counter++;
            }
            counter = 0;
            //loops through all the ingredients in current pizzas list of ingredients and adds them to the current 
            //ingredients listbox
            foreach (Ingredients s in pizza.Ingredients)
            {
                listBoxCurrentIngredients.Items.Add($"{s.ToString()} {IngredientPrices.prices[(int)s]} kr.");
            }
        }

        /// <summary>
        /// Adds the current pizza to the basket list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            //adds the pizza to the basket list and closes the window
            Basket.basket.Add(pizza);
            this.Close();
        }

        /// <summary>
        /// Closes the Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //closes the window
            this.Close();
        }
    }
}

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
    /// Interaction logic for BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        //double that holds the total price
        private double totalPrice = 0;
        //boolean that holds whether or not the discount has been activated
        private bool discount = false;

        public BasketWindow()
        {
            InitializeComponent();

            //Sets the selected item in all the listboxes to be the 
            listBoxPizzas.SelectedIndex = 0;
            listBoxIngredients.SelectedIndex = 0;
            listBoxDrinks.SelectedIndex = 0;

            //Loops through all the pizzas in the basket
            foreach (Pizza pizza in Basket.basket)
            {
                //Adds the current pizzas name to to the pizza list box
                listBoxPizzas.Items.Add($"{pizza.Name} {pizza.CurrentPrice} kr.");
                //adds the current pizzas price to the total price
                totalPrice += pizza.CurrentPrice;
            }

            //loops through all the drinks in the drinks basket
            foreach (Drink drink in Basket.drinkBasket)
            {
                //adds the name of the current drinks name to the drinks list box
                listBoxDrinks.Items.Add($"{drink.Name} {drink.CurrentPrice} kr.");
                //adds the current drinks price to the total price
                totalPrice += drink.CurrentPrice;
            }

            Discount();
            //Sets the content of the total price label to the total price
            lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
        }

        /// <summary>
        /// This checks for, and applies or removes the discount
        /// </summary>
        private void Discount()
        {
            //checks if there is at least 2 pizzas and drinks in the basket, and if a discount has already been applied
            if (Basket.basket.Count >= 2 && Basket.drinkBasket.Count >= 2 && !discount)
            {
                //removes a value of 15 from the total price
                totalPrice -= 15;
                //updates the content of the discount label
                lblDiscount.Content = "Discount added!";
                //sets the discount boolean to true, since the discount has been applied
                discount = true;
            }

            //checks if there are less than 2 pizzas and 2 drinks, and if the discount has already been applied
            if (Basket.basket.Count < 2 || Basket.drinkBasket.Count < 2 && discount)
            {
                //adds a value of 15 to the total price, to remove the discount
                totalPrice += 15;
                //removes the content of the discount label
                lblDiscount.Content = "";
                //sets the discount boolean to false, since the discount is not applied
                discount = false;
            }
        }

        /// <summary>
        /// Displays the ingredients og the currently selected pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPizzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //clears the content from the ingredients listbox
            listBoxIngredients.Items.Clear();
            //checks if there is any pizzas in the listbox
            if (listBoxPizzas.Items.Count > 0)
            {
                //loop that goes through all the ingredients in the currently selected pizza 
                foreach (Ingredients s in Basket.basket[listBoxPizzas.SelectedIndex].Ingredients)
                {
                    //adds the ingredient to the ingredients listbox
                    listBoxIngredients.Items.Add(s);
                }

                //updates the current pizza price label, to the currently selected pizzas price
                lblCurrentPizzaPrice.Content = $"Price: {Basket.basket[listBoxPizzas.SelectedIndex].CurrentPrice}";

            }
            //updates the content of the total price label, to the total price
            lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";

        }

        /// <summary>
        /// Button that removes the selected item in the pizzas listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //checks if there is any pizzas in the listbox
            if (listBoxPizzas.Items.Count > 0)
            {
                //removes the selected pizza, from the basket
                Basket.basket.RemoveAt(listBoxPizzas.SelectedIndex);

                //Clears all the items from both listboxes
                listBoxPizzas.Items.Clear();
                listBoxDrinks.Items.Clear();
                //Sets the total price to 0
                totalPrice = 0;
                //loops through all the pizzas in the basket
                foreach (Pizza pizza in Basket.basket)
                {
                    //adds the name of the current pizza to the pizza listbox
                    listBoxPizzas.Items.Add($"{pizza.Name} {pizza.CurrentPrice} kr.");
                    //adds the current pizzas price to the total price
                    totalPrice += pizza.CurrentPrice;
                }
                //loops through all the drinks in the drinks basket
                foreach (Drink drink in Basket.drinkBasket)
                {
                    //adds the name of the drink, to the drinks listbox
                    listBoxDrinks.Items.Add($"{drink.Name} {drink.CurrentPrice} kr.");
                    //adds the price of the current drink to the total price
                    totalPrice += drink.CurrentPrice;
                }

                //Checks if there is no pizzas in the pizza listbox
                if (listBoxPizzas.Items.Count == 0)
                    //sets the current pizza price label to 0
                    lblCurrentPizzaPrice.Content = "Price: 0";
                else
                {
                    //Sets the selected item in the pizza listbox to the first item as default
                    listBoxPizzas.SelectedIndex = 0;
                    //Sets the content of the current pizza price label to the price of the currently selected pizza
                    lblCurrentPizzaPrice.Content = $"Price: {Basket.basket[listBoxPizzas.SelectedIndex].CurrentPrice}";
                }
                //Sets the content of the total price label to the total price
                lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
                Discount();
            }
        }

        /// <summary>
        /// Updates the price label according to the selected drinks price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxDrinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //checks if there is any drinks in the drinks listbox
            if (listBoxDrinks.Items.Count > 0)
                //sets the current drink price label to the currently selected drinks price
                lblCurrentDrinkPrice.Content = $"Price: {Basket.drinkBasket[listBoxDrinks.SelectedIndex].CurrentPrice}";
            //Sets the content of the total price label to the total price
            lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
        }

        /// <summary>
        /// Button that removes the selected item in the drinks listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveDrink_Click(object sender, RoutedEventArgs e)
        {
            //checks if there is any drinks in the listbox
            if (listBoxDrinks.Items.Count > 0)
            {
                //removes the selected drink, from the basket
                Basket.drinkBasket.RemoveAt(listBoxDrinks.SelectedIndex);
                //Clears all the items from both listboxes
                listBoxPizzas.Items.Clear();
                listBoxDrinks.Items.Clear();
                //Sets the total price to 0
                totalPrice = 0;
                //loops through all the drinks in the basket
                foreach (Pizza pizza in Basket.basket)
                {
                    //adds the name of the current drink to the drink listbox
                    listBoxPizzas.Items.Add($"{pizza.Name} {pizza.CurrentPrice} kr.");
                    //adds the current drinks price to the total price
                    totalPrice += pizza.CurrentPrice;
                }
                //loops through all the drinks in the drinks basket
                foreach (Drink drink in Basket.drinkBasket)
                {
                    //adds the name of the drink, to the drinks listbox
                    listBoxDrinks.Items.Add($"{drink.Name} {drink.CurrentPrice} kr.");
                    //adds the price of the current drink to the total price
                    totalPrice += drink.CurrentPrice;
                }

                //Checks if there is no drinks in the drinks listbox
                if (listBoxDrinks.Items.Count == 0)
                    //sets the current drink price label to 0
                    lblCurrentDrinkPrice.Content = "Price: 0";
                else
                {
                    //Sets the selected item in the drink listbox to the first item as default
                    listBoxDrinks.SelectedIndex = 0;
                    //Sets the content of the current drink price label to the price of the currently selected drink
                    lblCurrentDrinkPrice.Content = $"Price: {Basket.drinkBasket[listBoxDrinks.SelectedIndex].CurrentPrice}";
                }
                //Sets the content of the total price label to the total price
                lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
                Discount();
            }
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            Basket.basket.Clear();
            Basket.drinkBasket.Clear();
            totalPrice = 0;
            discount = false;
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

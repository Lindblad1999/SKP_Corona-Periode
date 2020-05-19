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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Pizzaria.Enums;

namespace Pizzaria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pizza> menu = Menu.menu;

        public MainWindow()
        {
            InitializeComponent();
            //Goes through all the pizzas in the menu List, and displays them in the pizza listbox
            foreach (Pizza pizza in menu)
            {
                listBoxPizzas.Items.Add(pizza.Name);
            }
            //Goes through all the drinks in the drink menu list, and displays them in the drinks listbox
            foreach (Drink drink in Menu.drinkMenu)
            {
                listBoxDrinks.Items.Add(drink.Name);
            }

            //resets the selected indexes in the list box to first item, and checks the medium options as defaults
            listBoxPizzas.SelectedIndex = 0;
            listBoxDrinks.SelectedIndex = 0;
            checkBox_MediumDrink.IsChecked = true;
            checkBox_Medium.IsChecked = true;
        }

        /// <summary>
        /// Method is called when a selection has changed in the menu window.
        /// It updates the ingeredients window.
        /// </summary>
        private void listBoxPizzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clears all the items in the ingredients listbox
            listBoxIngredients.Items.Clear();
            //Goes through all the ingredients in the ingredients enum of the selected pizza
            foreach (Ingredients s in menu[listBoxPizzas.SelectedIndex].Ingredients)
            {
                //Adds the the current ingredient to the listbox
                listBoxIngredients.Items.Add(s.ToString());
            }
            SetPriceLabel();
        }

        /// <summary>
        /// Changes the label that displays price, according to which size has been set
        /// and which pizza is selected
        /// </summary>
        private void SetPriceLabel()
        {
            //checks which checkbox has been checked
            if (checkBox_Small.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].SmallPrice}";
            else if (checkBox_Medium.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].MediumPrice}";
            else if(checkBox_Large.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].LargePrice}";

        }

        #region Checkboxes Pizza
        //In here we uncheck all other checkboxes except for the one that the user has checked
        private void checkBox_Small_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Small.IsEnabled = false;
            checkBox_Medium.IsEnabled = true;
            checkBox_Large.IsEnabled = true;

            checkBox_Medium.IsChecked = false;
            checkBox_Large.IsChecked = false;
            SetPriceLabel();
        }

        private void checkBox_Medium_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Small.IsEnabled = true;
            checkBox_Medium.IsEnabled = false;
            checkBox_Large.IsEnabled = true;

            checkBox_Small.IsChecked = false;
            checkBox_Large.IsChecked = false;
            SetPriceLabel();
        }

        private void checkBox_Large_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_Small.IsEnabled = true;
            checkBox_Medium.IsEnabled = true;
            checkBox_Large.IsEnabled = false;

            checkBox_Small.IsChecked = false;
            checkBox_Medium.IsChecked = false;
            SetPriceLabel();
        }
        #endregion

        /// <summary>
        /// Adds the selected pizza to the basket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            double currentPrice;
            //checks which size has been selected, and sets the current price to be the selected pizzas size price
            if (checkBox_Small.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].SmallPrice;
            else if (checkBox_Medium.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].MediumPrice;
            else
                currentPrice = menu[listBoxPizzas.SelectedIndex].LargePrice;

            //Adds a new instance of Pizza, to the basket list, and passes the selected pizzas ingredients, current price, 
            //and name as arguments
            Basket.basket.Add(new Pizza(
                menu[listBoxPizzas.SelectedIndex].Ingredients.GetRange(0, menu[listBoxPizzas.SelectedIndex].Ingredients.Count)
                , currentPrice, menu[listBoxPizzas.SelectedIndex].Name));
        }

        /// <summary>
        /// Creates and opens a new instance of the edit pizza window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditPizza_Click(object sender, RoutedEventArgs e)
        {
            //Checks which size has been checked and, and sets the current price to be the selected pizzas size price
            double currentPrice;
            if (checkBox_Small.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].SmallPrice;
            else if (checkBox_Medium.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].MediumPrice;
            else
                currentPrice = menu[listBoxPizzas.SelectedIndex].LargePrice;

            //Creates a new instance of EditWindow and passes a new Instance of Pizza and passes the selected pizzas ingredients
            //, it's current price, and it's name.
            EditWindow ew = new EditWindow(new Pizza(
                menu[listBoxPizzas.SelectedIndex].Ingredients.GetRange(0, menu[listBoxPizzas.SelectedIndex].Ingredients.Count), 
                currentPrice, menu[listBoxPizzas.SelectedIndex].Name));

            //Opens the instance of the editWindow that was created just above
            ew.ShowDialog();
        }

        /// <summary>
        /// Opens a new instance of the basket window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewBasket_Click(object sender, RoutedEventArgs e)
        {
            //Creates a new instance of basketWindow and shows that window
            BasketWindow bw = new BasketWindow();
            bw.ShowDialog();
        }

        /// <summary>
        /// Adds the selected drink to the basket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brnAddDrinkToBasket_Click(object sender, RoutedEventArgs e)
        {
            //Checks which price has been currently selected and sets the currentPrice to be the selected pizzas current price
            double currentPrice;
            if (checkBox_SmallDrink.IsChecked == true)
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].SmallPrice;
            else if (checkBox_MediumDrink.IsChecked == true)
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].MediumPrice;
            else
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].LargePrice;

            //Adds a new instance of Drink to the basket List, and passes the name and current price as arguments
            Basket.drinkBasket.Add(new Drink(Menu.drinkMenu[listBoxDrinks.SelectedIndex].Name, currentPrice));
        }

        #region Checkboxes drinks
        //In here we uncheck all other checkboxes except for the one that the user has checked

        private void checkBox_SmallDrink_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_SmallDrink.IsEnabled = false;
            checkBox_MediumDrink.IsEnabled = true;
            checkBox_LargeDrink.IsEnabled = true;

            checkBox_MediumDrink.IsChecked = false;
            checkBox_LargeDrink.IsChecked = false;
            SetPriceLabelDrink();
        }

        private void checkBox_MediumDrink_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_SmallDrink.IsEnabled = true;
            checkBox_MediumDrink.IsEnabled = false;
            checkBox_LargeDrink.IsEnabled = true;

            checkBox_SmallDrink.IsChecked = false;
            checkBox_LargeDrink.IsChecked = false;
            SetPriceLabelDrink();
        }

        private void checkBox_LargeDrink_Checked(object sender, RoutedEventArgs e)
        {
            checkBox_SmallDrink.IsEnabled = true;
            checkBox_MediumDrink.IsEnabled = true;
            checkBox_LargeDrink.IsEnabled = false;

            checkBox_SmallDrink.IsChecked = false;
            checkBox_MediumDrink.IsChecked = false;
            SetPriceLabelDrink();
        }
        #endregion

        private void listBoxDrinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetPriceLabel();
        }

        /// <summary>
        /// Changes the drink price label according to which size has been chosen
        /// </summary>
        private void SetPriceLabelDrink()
        {
            //Updates the price label according to whic size has been checked off
            if (checkBox_SmallDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].SmallPrice}";
            else if (checkBox_MediumDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].MediumPrice}";
            else if(checkBox_LargeDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].LargePrice}";
        }
    }
}

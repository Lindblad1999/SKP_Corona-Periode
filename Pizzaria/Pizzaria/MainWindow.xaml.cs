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
            ///Displays all pizzas, in the menu window
            foreach (Pizza pizza in menu)
            {
                listBoxPizzas.Items.Add(pizza.Name);
            }

            foreach (Drink drink in Menu.drinkMenu)
            {
                listBoxDrinks.Items.Add(drink.Name);
            }

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
            listBoxIngredients.Items.Clear();
            foreach (Ingredients s in menu[listBoxPizzas.SelectedIndex].Ingredients)
            {
                listBoxIngredients.Items.Add(s.ToString());
            }
            SetPriceLabel();
        }

        /// <summary>
        /// Changes the label that displays price, according to which size has been set
        /// and which pizzaq is selected
        /// </summary>
        private void SetPriceLabel()
        {
            if (checkBox_Small.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].SmallPrice}";
            else if (checkBox_Medium.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].MediumPrice}";
            else if(checkBox_Large.IsChecked == true)
                lblPrice.Content = $"Price: {menu[listBoxPizzas.SelectedIndex].LargePrice}";

        }

        #region Checkboxes Pizza
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

        private void brnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            double currentPrice;
            if (checkBox_Small.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].SmallPrice;
            else if (checkBox_Medium.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].MediumPrice;
            else
                currentPrice = menu[listBoxPizzas.SelectedIndex].LargePrice;

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
            double currentPrice;
            if (checkBox_Small.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].SmallPrice;
            else if (checkBox_Medium.IsChecked == true)
                currentPrice = menu[listBoxPizzas.SelectedIndex].MediumPrice;
            else
                currentPrice = menu[listBoxPizzas.SelectedIndex].LargePrice;
            EditWindow ew = new EditWindow(new Pizza(
                menu[listBoxPizzas.SelectedIndex].Ingredients.GetRange(0, menu[listBoxPizzas.SelectedIndex].Ingredients.Count), 
                currentPrice, menu[listBoxPizzas.SelectedIndex].Name));

            ew.Show();
        }

        private void btnViewBasket_Click(object sender, RoutedEventArgs e)
        {
            BasketWindow bw = new BasketWindow();
            bw.Show();
        }

        private void brnAddDrinkToBasket_Click(object sender, RoutedEventArgs e)
        {
            double currentPrice;
            if (checkBox_SmallDrink.IsChecked == true)
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].SmallPrice;
            else if (checkBox_MediumDrink.IsChecked == true)
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].MediumPrice;
            else
                currentPrice = Menu.drinkMenu[listBoxDrinks.SelectedIndex].LargePrice;

            Basket.drinkBasket.Add(new Drink(Menu.drinkMenu[listBoxDrinks.SelectedIndex].Name, currentPrice));
        }

        #region Checkboxes drinks
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

        private void SetPriceLabelDrink()
        {
            if (checkBox_SmallDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].SmallPrice}";
            else if (checkBox_MediumDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].MediumPrice}";
            else if(checkBox_LargeDrink.IsChecked == true)
                lblDrinkPrice.Content = $"Price: {Menu.drinkMenu[listBoxDrinks.SelectedIndex].LargePrice}";
        }
    }
}

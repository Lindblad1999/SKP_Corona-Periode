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
        private double totalPrice = 0;

        public BasketWindow()
        {
            InitializeComponent();

            listBoxPizzas.SelectedIndex = 0;
            listBoxIngredients.SelectedIndex = 0;

            foreach (Pizza pizza in Basket.basket)
            {
                listBoxPizzas.Items.Add(pizza.Name);
                totalPrice += pizza.CurrentPrice;
            }

            lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
        }

        /// <summary>
        /// Displays the ingredients og the currently selected pizza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxPizzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBoxIngredients.Items.Clear();
            if (listBoxPizzas.Items.Count > 0)
            {
                foreach (Ingredients s in Basket.basket[listBoxPizzas.SelectedIndex].Ingredients)
                {
                    listBoxIngredients.Items.Add(s);
                }

                lblCurrentPizzaPrice.Content = $"Price: {Basket.basket[listBoxPizzas.SelectedIndex].CurrentPrice}";

            }
                lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxPizzas.Items.Count > 0)
            {
                Basket.basket.RemoveAt(listBoxPizzas.SelectedIndex);

                listBoxPizzas.Items.Clear();
                totalPrice = 0;
                foreach (Pizza pizza in Basket.basket)
                {
                    listBoxPizzas.Items.Add(pizza.Name);
                    totalPrice += pizza.CurrentPrice;
                }

                if (listBoxPizzas.Items.Count == 0)
                    lblCurrentPizzaPrice.Content = "Price: 0";
                else
                {
                    listBoxPizzas.SelectedIndex = 0;
                    lblCurrentPizzaPrice.Content = $"Price: {Basket.basket[listBoxPizzas.SelectedIndex].CurrentPrice}";
                }
                lblTotalPrice.Content = $"Total Price: {totalPrice.ToString()}";
            }
        }
    }
}

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
            this.pizza = pizza;
            lblPizzaName.Content = pizza.Name;

            UpdateListBoxes();

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
            pizza.Ingredients.Add((Ingredients)listBoxAllIngredients.SelectedIndex);
            UpdateListBoxes();
        }

        /// <summary>
        /// Removes the selected ingredient, from the current pizzas ingredient list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            pizza.Ingredients.RemoveAt(listBoxCurrentIngredients.SelectedIndex);
            UpdateListBoxes();
        }

        /// <summary>
        /// Updates the content of the 2 list boxes.
        /// </summary>
        private void UpdateListBoxes()
        {
            listBoxAllIngredients.Items.Clear();
            listBoxCurrentIngredients.Items.Clear();

            foreach (string s in Enum.GetNames(typeof(Ingredients)))
            {
                listBoxAllIngredients.Items.Add(s);
            }

            foreach (Ingredients s in pizza.Ingredients)
            {
                listBoxCurrentIngredients.Items.Add(s.ToString());
            }
        }

        /// <summary>
        /// Adds the current pizza to the basket list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
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
            this.Close();
        }
    }
}

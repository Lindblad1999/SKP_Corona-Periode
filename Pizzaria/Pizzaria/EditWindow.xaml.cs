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
        
        public EditWindow(string currentPizzaName, Pizza pizza)
        {
            InitializeComponent();
            this.pizza = new Pizza(pizza.Ingredients, pizza.MediumPrice, pizza.Name);
            lblPizzaName.Content = pizza.Name;

            UpdateListBoxes();

            listBoxAllIngredients.SelectedIndex = 0;
            listBoxCurrentIngredients.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            pizza.Ingredients.Add((Ingredients)listBoxAllIngredients.SelectedIndex);
            UpdateListBoxes();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            pizza.Ingredients.RemoveAt(listBoxCurrentIngredients.SelectedIndex);
            UpdateListBoxes();
        }

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
    }
}

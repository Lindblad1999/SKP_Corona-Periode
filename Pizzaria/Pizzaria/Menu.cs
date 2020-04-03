using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Enums;

namespace Pizzaria
{
    public static class Menu
    {
        /// <summary>
        /// List of all the pizzas, that make up the Menu
        /// </summary>
        public static List<Pizza> menu = new List<Pizza>()
        {
            new Pizza(new List<Ingredients> {Ingredients.Tomato, Ingredients.Ham, Ingredients.Cheese}, 70, "Labralicious"),
            new Pizza(new List<Ingredients> {Ingredients.Tomato, Ingredients.Ham, Ingredients.Pinapple}, 60, "Hawaiiii"),
            new Pizza(new List<Ingredients> {Ingredients.Tomato, Ingredients.Beef, Ingredients.Jalapeno, Ingredients.Corn}, 80, "SoundsNasty"),
            new Pizza(new List<Ingredients> {Ingredients.Cheese, Ingredients.Chicken, Ingredients.Mushroom, Ingredients.Pepper}, 65, "YouGonnaPuke"),
            new Pizza(new List<Ingredients> {Ingredients.Cheese, Ingredients.Corn, Ingredients.Jalapeno, Ingredients.Mushroom
            , Ingredients.Olives, Ingredients.Pinapple, Ingredients.Tomato}, 15, "PlsDontBeVegan")
        };

        /// <summary>
        /// List of all the drinks, that make up the Drinks menu
        /// </summary>
        public static List<Drink> drinkMenu = new List<Drink>()
        {
            new Drink("Coca Cola", 0),
            new Drink("Sprite", 0),
            new Drink("Fanta", 0),
            new Drink("7Up", 0),
            new Drink("Milk", 0),
            new Drink("Water", 0),
            new Drink("Salty Water", 0)
        };
    }
}

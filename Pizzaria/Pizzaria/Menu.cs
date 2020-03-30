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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria.Enums
{
    public enum Ingredients
    {
        Tomato,
        Cheese,
        Pinapple,
        Ham,
        Beef,
        Mushroom,
        Jalapeno,
        Chicken,
        Olives,
        Pepper,
        Corn
    }
    
    public static class IngredientPrices
    {
        public static int[] prices = { 5, 5, 6, 3, 4, 5, 3, 4, 6, 5, 5 };
    }
}

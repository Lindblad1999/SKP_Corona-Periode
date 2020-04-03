using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzaria
{
    public static class Basket
    {
        /// <summary>
        /// The two lists that contain items added to the basket
        /// </summary>
        public static List<Pizza> basket = new List<Pizza>();
        public static List<Drink> drinkBasket = new List<Drink>();
    }
}

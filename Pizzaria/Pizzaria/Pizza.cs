using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Enums;

namespace Pizzaria
{
    public class Pizza
    {
        private List<Ingredients> ingredients;
        private string size;
        private string name;
        private double smallPrice;
        private double mediumPrice;
        private double largePrice;
        private double currentPrice;

        public List<Ingredients> Ingredients { get { return this.ingredients; } set { this.ingredients = value; } }
        public string Size { get { return this.size; } set { this.size = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public double SmallPrice { get { return this.smallPrice; } set { this.smallPrice = value; } }
        public double MediumPrice { get { return this.mediumPrice; } set { this.mediumPrice = value; } }
        public double LargePrice { get { return this.largePrice; } set { this.largePrice = value; } }
        public double CurrentPrice { get { return this.currentPrice; } set { this.currentPrice = value; } }

        public Pizza(List<Ingredients> ingredients, double defaultPrice, string name)
        {
            this.Ingredients = ingredients;
            this.Name = name;
            GetPrice(defaultPrice);
            currentPrice = defaultPrice;
        }

        /// <summary>
        /// Calculates the prices of the various sizes, from the default price
        /// </summary>
        private void GetPrice(double defaultPrice)
        {
            this.SmallPrice = defaultPrice * 0.8;
            this.MediumPrice = defaultPrice;
            this.largePrice = defaultPrice * 1.2;
        }
    }
}

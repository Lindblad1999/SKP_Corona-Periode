using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzaria.Enums;

namespace Pizzaria
{
    public class Drink
    {
        private string name;
        private double smallPrice;
        private double mediumPrice;
        private double largePrice;
        private double currentPrice;

        public string Name { get => name; set => name = value; }
        public double SmallPrice { get => smallPrice; set => smallPrice = value; }
        public double MediumPrice { get => mediumPrice; set => mediumPrice = value; }
        public double LargePrice { get => largePrice; set => largePrice = value; }
        public double CurrentPrice { get => currentPrice; set => currentPrice = value; }

        public Drink(string name, double currentPrice)
        {
            SmallPrice = 10;
            MediumPrice = 15;
            LargePrice = 20;
            this.Name = name;
            this.CurrentPrice = currentPrice;
        }
    }
}

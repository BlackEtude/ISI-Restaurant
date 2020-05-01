using System;
using System.Collections.Generic;
using System.Linq;

namespace ISI_Restaurant.Shared.Models
{
    public class Pizza
    {
        public const int DefaultSize = 30;
        public const int MinimumSize = 20;
        public const int MaximumSize = 40;

        public Pizza(Product product)
            => (Product, Size, Toppings) = (product, DefaultSize, new List<Topping>());

        public Product Product { get; set; }
        public int Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public decimal BasePrice => Product.Price;

        public int GetBasePrice() => (int)((decimal)Size / DefaultSize * Product.Price);

        public decimal GetTotalPrice() => GetBasePrice() + Toppings.Sum(t => t.Price);

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("00.00");

        public string GetFormattedBasePrice() => GetBasePrice().ToString("00.00");
    }
}

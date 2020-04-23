using System.Collections.Generic;
using System.Linq;

namespace ISI_Restaurant.Shared.Models
{
    public class Pizza
    {
        public Product Product { get; set; }
        public int Size { get; set; }
        public List<Topping> Toppings { get; set; }

        public double BasePrice => Product.Price;

        public double GetTotalPrice() => BasePrice + Toppings.Sum(t => t.Price);

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("00.00");
    }
}

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ISI_Restaurant.Shared.Models
{
    public partial class OrderItem
    {
        public OrderItem(Product product)
            => (Product, Size, Toppings) = (product, Product.DefaultSize, new List<Topping>());

        [JsonIgnore]
        public decimal BasePrice => Product.Price;

        public int GetBasePrice() => (int)((decimal)Size / Product.DefaultSize * Product.Price);

        public decimal GetTotalPrice() => GetBasePrice() + Toppings.Sum(t => t.Price);

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("00.00");

        public string GetFormattedBasePrice() => GetBasePrice().ToString("00.00");
    }
}

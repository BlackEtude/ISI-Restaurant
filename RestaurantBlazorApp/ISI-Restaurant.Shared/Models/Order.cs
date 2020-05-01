using System.Collections.Generic;
using System.Linq;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public decimal GetTotalPrice() => Items.Sum(p => p.GetTotalPrice());

        public string GetFormattedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}

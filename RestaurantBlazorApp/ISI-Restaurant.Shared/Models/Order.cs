using System.Collections.Generic;
using System.Linq;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
            CustomerData = new CustomerData();
            DeliveryPoint = new DeliveryPoint();
        }

        public decimal GetCalculatedPrice() => Items.Sum(p => p.GetTotalPrice());

        public string GetFormattedCalculatedPrice() => GetCalculatedPrice().ToString("0.00");

        public string GetFormattedTotalPrice() => TotalPrice.ToString("0.00");
    }
}

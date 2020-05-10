using Newtonsoft.Json;
using System.Collections.Generic;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Order
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customerData")]
        public CustomerData CustomerData { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }

        [JsonProperty("deliveryType")]
        public string DeliveryType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("orderItems")]
        public List<OrderItem> Items { get; set; }

        [JsonProperty("deliveryPoint")]
        public DeliveryPoint DeliveryPoint { get; set; }
    }
}

using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Order
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("customer_data")]
        public CustomerData CustomerData { get; set; }

        [JsonProperty("total_price")]
        public double Totalprice { get; set; }

        [JsonProperty("delivery_type")]
        public string DeliveryType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

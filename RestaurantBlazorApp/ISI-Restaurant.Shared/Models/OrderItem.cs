using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class OrderItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("product")]
        public Product product { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}

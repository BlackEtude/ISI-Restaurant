using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public string GetFormattedPrice() => Price.ToString("0.00");
    }
}

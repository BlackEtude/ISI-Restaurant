using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Topping
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public string GetFormattedPrice() => Price.ToString("0.00");
    }
}

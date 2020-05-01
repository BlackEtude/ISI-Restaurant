using Newtonsoft.Json;
using System.Collections.Generic;

namespace ISI_Restaurant.Shared.Models
{
    public partial class OrderItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("toppings")]
        public List<Topping> Toppings { get; set; }
    }
}

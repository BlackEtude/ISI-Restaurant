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

        [JsonIgnore]
        public int Size { get; set; }

        [JsonProperty("productSize")]
        public string ProductSize { get; set; }

        [JsonProperty("toppings")]
        public List<Topping> Toppings { get; set; }

        public string MapProductSize()
        {
            return Size switch
            {
                Product.MinimumSize => "SMALL",
                Product.MaximumSize => "BIG",
                _ => "MEDIUM"  // default
            };
        }
    }
}

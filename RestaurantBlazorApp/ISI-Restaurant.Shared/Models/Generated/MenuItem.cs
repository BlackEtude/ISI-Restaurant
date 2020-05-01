using Newtonsoft.Json;
using System.Collections.Generic;

namespace ISI_Restaurant.Shared.Models
{
    public class MenuItem
    {
        [JsonProperty("product")]
        public Product Product { get; set; }
        
        [JsonProperty("toppings")]
        public List<Topping> Toppings { get; set; }

        [JsonProperty("imagepath")]
        public string ImagePath { get; set; }
    }
}

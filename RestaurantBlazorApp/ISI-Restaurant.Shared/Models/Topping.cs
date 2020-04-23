﻿using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Topping
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}

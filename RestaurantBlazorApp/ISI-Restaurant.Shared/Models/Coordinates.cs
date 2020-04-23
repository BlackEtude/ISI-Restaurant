using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Coordinates
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}

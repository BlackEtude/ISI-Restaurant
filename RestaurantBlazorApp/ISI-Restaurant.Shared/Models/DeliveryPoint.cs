using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class DeliveryPoint
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("openingHours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("coordinates")]
        public Coordinates Coordinates { get; set; }
    }
}

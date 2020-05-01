using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Address
    {
        [JsonProperty("address_street")]
        public string Street { get; set; }

        [JsonProperty("address_city")]
        public string City { get; set; }

        [JsonProperty("address_postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("address_country")]
        public string Country { get; set; }
    }
}

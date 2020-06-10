using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Address
    {
        [JsonProperty("street")]
        [Required]
        public string Street { get; set; }

        [JsonProperty("city")]
        [Required]
        public string City { get; set; }

        [JsonProperty("postalCode")]
        [Required]
        public string PostalCode { get; set; }
    }
}

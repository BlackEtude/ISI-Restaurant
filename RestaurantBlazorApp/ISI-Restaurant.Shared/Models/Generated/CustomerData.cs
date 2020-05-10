using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ISI_Restaurant.Shared.Models
{
    public partial class CustomerData
    {
        [JsonProperty("firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        public string LastName { get; set; }

        [JsonProperty("emailAddress")]
        [Required]
        public string EmailAddress { get; set; }

        [JsonProperty("phoneNumber")]
        [Required]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}

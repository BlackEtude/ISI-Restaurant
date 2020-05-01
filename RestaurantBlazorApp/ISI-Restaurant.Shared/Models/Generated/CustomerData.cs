using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class CustomerData
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}

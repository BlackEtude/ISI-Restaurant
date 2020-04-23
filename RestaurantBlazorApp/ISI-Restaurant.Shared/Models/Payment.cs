using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class Payment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

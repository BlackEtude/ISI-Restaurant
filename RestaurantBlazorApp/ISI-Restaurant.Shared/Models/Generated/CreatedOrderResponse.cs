using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class CreatedOrderResponse
    {
        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("orderResult")]
        public string OrderResult { get; set; }

        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }
    }
}
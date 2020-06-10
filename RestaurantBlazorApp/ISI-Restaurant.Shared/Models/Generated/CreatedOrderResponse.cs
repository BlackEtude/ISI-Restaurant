using Newtonsoft.Json;

namespace ISI_Restaurant.Shared.Models
{
    public partial class CreatedOrderResponse
    {
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("notifyUrl")]
        public string NotifyUrl { get; set; }

        [JsonProperty("redirectUri")]
        public string RedirectUri { get; set; }
    }
}
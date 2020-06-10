using Newtonsoft.Json;
using System;

namespace ISI_Restaurant.Shared.Models
{
    public partial class OpeningHours
    {
        [JsonProperty("openingHour")]
        public string OpeningHour { get; set; }

        [JsonProperty("closingHour")]
        public string ClosingHour { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace ISI_Restaurant.Shared.Models
{
    public partial class OpeningHours
    {
        [JsonProperty("open_date_time")]
        public DateTime OpeningHour { get; set; }

        [JsonProperty("close_date_time")]
        public DateTime ClosingHour { get; set; }
    }
}

using System;
using Newtonsoft.Json;

namespace SmartFlow.DTO.PurpleWifi
{
    public class PurpleWifiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
    }
}
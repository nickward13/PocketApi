using System.Text.Json.Serialization;

namespace PocketApi.Models
{
    public class RequestToken
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("state")]
        public object State { get; set; }
    }
}

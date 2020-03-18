using System.Text.Json.Serialization;

namespace PocketApi
{
    class ObtainRequestTokenBody
    {
        [JsonPropertyName("consumer_key")]
        public string ConsumerKey { get; set; }
        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; set; }
    }
}
